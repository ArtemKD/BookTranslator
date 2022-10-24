using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace FileTranslator
{
    static class ExcelTranslator
    {
        public delegate Task<Reply> TranslateFunc(String text, String fromLang, String toLang, CancellationToken ct);

        public static async Task<Reply> Translate(TranslateFunc Translator, String pathFile, String pathSavingFiles, String fromLang, String toLang,
                                                    CancellationToken ct, ProgressBar progressBar)
        {
            String pathNewFile = Path.Combine(pathSavingFiles, toLang + "_" + Path.GetFileName(pathFile));
            File.Copy(pathFile, pathNewFile, true); // IOException

            SpreadsheetDocument doc = SpreadsheetDocument.Open(pathNewFile, true);

            WorkbookPart? wbPart = doc.WorkbookPart;
            if (wbPart == null)
            {
                doc.Close();
                return new Reply
                {
                    Code = -1,
                    Message = "WorkbookPart не известна(null)"
                };
            }

            SharedStringTablePart? sharedStringTablePart = wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
            if (sharedStringTablePart == null)
            {
                doc.Close();
                return new Reply
                {
                    Code = -2,
                    Message = "SharedStringTablePart не известна(null)"
                };
            }

            SharedStringTable? sharedStringTable = sharedStringTablePart.SharedStringTable;
            if (sharedStringTable == null)
            {
                doc.Close();
                return new Reply
                {
                    Code = -2,
                    Message = "sharedStringTable не известна(null)"
                };
            }


            Reply reply = new Reply
            {
                Code = 200,
                Message = "Документ успешно переведен"
            };

            progressBar.Invoke(() => progressBar.Maximum = sharedStringTable.Count());
            progressBar.Invoke(() => progressBar.Value = 0);

            foreach (SharedStringItem sharedStringItem in sharedStringTable)
            {
                Console.WriteLine($"Value: [{sharedStringItem.InnerText}]");
                Console.WriteLine("-----------------------------------------------");

                Reply translateReply = await Translator(sharedStringItem.InnerText, fromLang, toLang, ct);
                if (translateReply.Code != 200)
                {
                    progressBar.Invoke(() => progressBar.Value = progressBar.Maximum);
                    doc.Close();
                    return new Reply
                    {
                        Code = translateReply.Code,
                        Message = translateReply.Message
                    };
                }

                String innerText = translateReply.Message;
                Console.WriteLine($"Translate: [{innerText}]");

                sharedStringItem.RemoveAllChildren();

                Text text = new Text();
                text.Text = innerText;

                sharedStringItem.AddChild(text);

                progressBar.Invoke(() => progressBar.Increment(1));
            }

            doc.Save();
            doc.Close();
            return reply;
        }
    }
}
