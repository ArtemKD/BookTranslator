using System.Transactions;

namespace FileTranslator
{
    internal class FileTranslator
    {
        private YandexCloud.TranslatorYC translatorYC;

        private List<String> pathFiles;
        private String pathSavingFiles;

        private String fromLang;
        private String toLang;

        private ProgressBar progressBar;
        private Label currentFileLabel;

        private Task<Reply>? currentTranslateTask;
        private CancellationTokenSource? cts;


        public FileTranslator(String iamToken, ProgressBar progressBar, Label currentFileLabel)
        {
            translatorYC = new YandexCloud.TranslatorYC(iamToken);

            pathFiles = new List<String>();
            pathSavingFiles = String.Empty;

            fromLang = String.Empty;
            toLang = String.Empty;

            this.progressBar = progressBar;
            this.currentFileLabel = currentFileLabel;
        }

        public async Task<List<Reply>> Translate()
        {
            Reply requirements = CheckRequirements();
            if(requirements.Code != 200)
            {
                return new List<Reply>() { requirements };
            }

            cts = new CancellationTokenSource();
            List<Reply> replyList = new List<Reply>();

            foreach(String pathFile in pathFiles)
            {
                currentFileLabel.Invoke(() => currentFileLabel.Text = Path.GetFileName(pathFile));
                if (!File.Exists(pathFile))
                {
                    replyList.Add(new Reply()
                    {
                        Code = -1,
                        Message = $"Файл: {Path.GetFileName(pathFile)} не существует или перемещен"
                    });
                    continue;
                }
                var splitPath = pathFile.Split('.');
                String fileType = splitPath[splitPath.Length - 1];


                Reply translationStatus;
                if (fileType == "docx")
                    //translationStatus = await WordTranslator.Translate(TranslateTest, pathFile, pathSavingFiles, fromLang, toLang, cts.Token, progressBar);
                    translationStatus = await WordTranslator.Translate(translatorYC.Translate, pathFile, pathSavingFiles, fromLang, toLang, cts.Token, progressBar);
                else if (fileType == "xlsx")
                    //translationStatus = await ExcelTranslator.Translate(TranslateTest, pathFile, pathSavingFiles, fromLang, toLang, cts.Token, progressBar);
                    translationStatus = await ExcelTranslator.Translate(translatorYC.Translate, pathFile, pathSavingFiles, fromLang, toLang, cts.Token, progressBar);
                else
                    translationStatus = new Reply
                    {
                        Code = -111,
                        Message = ""
                    };

                Reply currentFileReply = new Reply
                {
                    Code = translationStatus.Code
                };
                switch(translationStatus.Code)
                {
                    case 200:
                        currentFileReply.Message = $"Файл: {Path.GetFileName(pathFile)} Ok";
                        break;
                    case -11:
                        currentFileReply.Message = $"Файл: {Path.GetFileName(pathFile)} Отмена";
                        break;
                    case -111:
                        currentFileReply.Message = $"Файл {Path.GetFileName(pathFile)}, Ошибка: этот тип фалов не переводится";
                        break;
                    case 401:
                        currentFileReply.Message = $"Файл {Path.GetFileName(pathFile)}, Ошибка: проблемы авторизации yandex cloud";
                        break;
                    case 403:
                        currentFileReply.Message = $"Файл {Path.GetFileName(pathFile)}, Ошибка: не достаточно прав yandex cloud";
                        break;
                    case 429:
                        currentFileReply.Message = $"Файл {Path.GetFileName(pathFile)}, Ошибка: превышен лимит запросов к серверу";
                        break;
                    case 500:
                        currentFileReply.Message = $"Файл {Path.GetFileName(pathFile)}, Ошибка: внутренняя ошибка сервера yandex cloud";
                        break;
                    case 503:
                        currentFileReply.Message = $"Файл {Path.GetFileName(pathFile)}, Ошибка: сервис yandex cloud translate в данный момент не доступен";
                        break;
                    default:
                        currentFileReply.Message = $"Файл: {Path.GetFileName(pathFile)} Ошибка: {translationStatus.Message}";
                        break;
                }

                replyList.Add(currentFileReply);
            }

            //refresh task and cancel token
            currentTranslateTask?.Dispose();
            currentTranslateTask = null;
            cts.Dispose();
            cts = null;
            return replyList;
        }

        private Reply CheckRequirements()
        {
            if (pathSavingFiles == String.Empty)
            {
                return new Reply
                {
                    Code = -2,
                    Message = "Не выбрана папка для перевода"
                };
            }
            else if (pathFiles.Count < 1)
            {
                return new Reply
                {
                    Code = -1,
                    Message = "Не выбраны файлы для перевода"
                };
            }
            else if (toLang == String.Empty)
            {
                return new Reply
                {
                    Code = -3,
                    Message = "Не выбран язык перевода"
                };
            }
            else
            {
                return new Reply
                {
                    Code = 200,
                    Message = "Ok"
                };
            }
        }

        private async Task<Reply> TranslateTest(String text, String fromLang, String toLang, CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
            {
                return new Reply
                {
                    Code = -11,
                    Message = "Отмена"
                };
            }
            text = text.ToUpper();
            await Task.Run(() => Thread.Sleep(2));
            return new Reply
            {
                Code = 200,
                Message = text
            };
        }

        public void SetPathFiles(List<String> pathFiles)
        {
            this.pathFiles = pathFiles;
        }
        public List<String> GetPathFiles()
        {
            return this.pathFiles;
        }
        public void SetPathSavingFiles(String pathSavingFiles)
        {
            this.pathSavingFiles = pathSavingFiles;
        }
        public String GetPathSavingFiles()
        {
            return this.pathSavingFiles;
        }

        public void SetFromLang(String fromLang)
        {
            this.fromLang = fromLang;
        }

        public void SetToLang(String toLang)
        {
            this.toLang = toLang;
        }

        public void Cancel()
        {
            if (cts != null)
            {
                cts.Cancel();
            }
        }
        public void Close()
        {
            Cancel();
        }
    }
}
