using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace FileTranslator
{
    static class WordTranslator
    {
        public delegate Task<Reply> TranslateFunc(String text, String fromLang, String toLang, CancellationToken ct);
        public static async Task<Reply> Translate(TranslateFunc Translator, String pathFile, String pathSavingFiles, String fromLang, String toLang,
                                                    CancellationToken ct, ProgressBar progressBar)
        {
            String pathNewFile = Path.Combine(pathSavingFiles, toLang + "_" + Path.GetFileName(pathFile));
            File.Copy(pathFile, pathNewFile, true); // IOException

            WordprocessingDocument doc = WordprocessingDocument.Open(pathNewFile, true);
            MainDocumentPart? mainDocumentPart = doc.MainDocumentPart;
            if (mainDocumentPart == null)
            {
                doc.Close();
                return new Reply
                {
                    Code = -1,
                    Message = "MainDocumentPart не известна(null)"
                };
            }
            Body? body = mainDocumentPart.Document.Body;
            if (body == null)
            {
                doc.Close();
                return new Reply
                {
                    Code = -2,
                    Message = "Body не известен(null)"
                };
            }

            Reply reply = new Reply
            {
                Code = 200,
                Message = "Документ успешно переведен"
            };

            progressBar.Invoke(() => progressBar.Maximum = CountParagraphs(body));
            progressBar.Invoke(() => progressBar.Value = 0);

            Reply replyParagraphsTranslate = await TranslateParagraphs(Translator, body, fromLang, toLang, ct, progressBar);
            if (replyParagraphsTranslate.Code != 200)
            {
                progressBar.Invoke(() => progressBar.Value = progressBar.Maximum);
                reply = replyParagraphsTranslate;
            }
            else
            {
                Reply replyTablesTranslate = await TranslateTables(Translator, body, fromLang, toLang, ct, progressBar);
                if (replyTablesTranslate.Code != 200)
                {
                    progressBar.Invoke(() => progressBar.Value = progressBar.Maximum);
                    reply = replyTablesTranslate;
                }
            }

            doc.Save();
            doc.Close();
            return reply;
        }

        private static async Task<Reply> TranslateParagraphs(TranslateFunc Translator, Body body, String fromLang, String toLang, CancellationToken ct, ProgressBar progressBar)
        {
            foreach (Paragraph par in body.Elements<Paragraph>().ToList())
            {
                if (par.InnerText.Length > 0)
                {
                    Reply translateReply = await Translator(par.InnerText, fromLang, toLang, ct);
                    if (translateReply.Code != 200)
                    {
                        return new Reply
                        {
                            Code = translateReply.Code,
                            Message = translateReply.Message
                        };
                    }

                    String innerText = translateReply.Message;

                    par.RemoveAllChildren<Run>();

                    Text text = new Text();
                    text.Text = innerText;

                    Run newRun = new Run();
                    newRun.AddChild(text);

                    par.AddChild(newRun);
                }
                progressBar.Invoke(() => progressBar.Increment(1));
            }
            return new Reply
            {
                Code = 200,
                Message = "Параграфы успешно переведены"
            };
        }

        private static async Task<Reply> TranslateTables(TranslateFunc Translator, Body body, String fromLang, String toLang, CancellationToken ct, ProgressBar progressBar)
        {
            foreach (Table table in body.Elements<Table>().ToList())
            {
                foreach (TableRow row in table.Elements<TableRow>().ToList())
                {
                    foreach (TableCell cell in row.Elements<TableCell>().ToList())
                    {
                        foreach (Paragraph par in cell.Elements<Paragraph>().ToList())
                        {
                            if (par.InnerText.Length > 0)
                            {
                                Reply translation = await Translator(par.InnerText, fromLang, toLang, ct);

                                if (translation.Code != 200)
                                {
                                    return new Reply
                                    {
                                        Code = translation.Code,
                                        Message = translation.Message
                                    };
                                }

                                String innerText = translation.Message;

                                par.RemoveAllChildren<Run>();

                                Text text = new Text();
                                text.Text = innerText;


                                Run newRun = new Run();
                                newRun.AddChild(text);

                                par.AddChild(newRun);
                            }
                            progressBar.Invoke(() => progressBar.Increment(1));
                        }
                    }
                }
            }
            return new Reply
            {
                Code = 200,
                Message = "Таблицы успешно переведены"
            };
        }

        static int CountParagraphs(Body body)
        {
            int counter = 0;
            counter += body.Elements<Paragraph>().ToList().Count;


            foreach (Table table in body.Elements<Table>().ToList())
            {
                foreach (TableRow row in table.Elements<TableRow>().ToList())
                {
                    foreach (TableCell cell in row.Elements<TableCell>().ToList())
                    {
                        counter += cell.Elements<Paragraph>().ToList().Count;
                    }
                }
            }
            return counter;
        }
    }
}
