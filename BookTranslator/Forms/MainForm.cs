
namespace BookTranslator.Forms
{
    public partial class MainForm : Form
    {
        FileTranslator.FileTranslator fileTranslator;
        Dictionary<String, String> availableLanguages;
        Form parrentForm;
        public MainForm(Form parrentForm, String iamToken)
        {
            InitializeComponent();
            this.parrentForm = parrentForm;

            fileTranslator = new FileTranslator.FileTranslator(iamToken, translateProgress, currentFileLabel);

            availableLanguages = new Dictionary<String, String>()
            {
                {"Русский", "ru" },
                {"Английский", "en" },
                {"Французский", "fr" },
                {"Португальский", "pt" },
                {"Китайский", "zh" }
            };

            foreach(var language in availableLanguages)
            {
                fromLang.Items.Add(language.Key);
                toLang.Items.Add(language.Key);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fileTranslator.Cancel();
            parrentForm.Show();
        }

        private void chooseDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowseDialog = new FolderBrowserDialog();
            folderBrowseDialog.Description = "Выберите папку для переводов";
            if (folderBrowseDialog.ShowDialog() == DialogResult.OK)
            {
                fileTranslator.SetPathSavingFiles(folderBrowseDialog.SelectedPath);
                pathDirLabel.Text = fileTranslator.GetPathSavingFiles();
            }
        }

        private void chooseFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect=true};
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileTranslator.SetPathFiles(openFileDialog.FileNames.ToList());
                List<String> files = fileTranslator.GetPathFiles();
                pathFilesLabel.Text = String.Empty;
                foreach (String file in files)
                {
                    pathFilesLabel.Text += Path.GetFileName(file) + " ";
                }
            }
        }

        private async void translateButton_Click(object sender, EventArgs e)
        {
            resultBox.Text = String.Empty;
            List<Reply> replyList = await fileTranslator.Translate();

            resultBox.Text = String.Empty;
            foreach (Reply reply in replyList)
            {
                resultBox.Text += reply.Message + "\n";
            }
        }

        private void fromLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectLang = this.fromLang.SelectedItem.ToString();
            if(selectLang != String.Empty)
            {
                fileTranslator.SetFromLang(availableLanguages[selectLang]);
            }
        }

        private void toLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectLang = this.toLang.SelectedItem.ToString();
            if (selectLang != String.Empty)
            {
                fileTranslator.SetToLang(availableLanguages[selectLang]);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            fileTranslator.Cancel();
        }
    }
}
