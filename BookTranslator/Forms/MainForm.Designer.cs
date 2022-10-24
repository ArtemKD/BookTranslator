namespace BookTranslator.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.translateProgress = new System.Windows.Forms.ProgressBar();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.currentFileLabel = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.midPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.toLang = new System.Windows.Forms.ComboBox();
            this.fromLang = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.translateButton = new System.Windows.Forms.Button();
            this.pathFilesLabel = new System.Windows.Forms.Label();
            this.chooseFilesButton = new System.Windows.Forms.Button();
            this.chooseFilesLabel = new System.Windows.Forms.Label();
            this.pathDirLabel = new System.Windows.Forms.Label();
            this.chooseDirButton = new System.Windows.Forms.Button();
            this.chooseDirLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.resultLabel = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.titlePanel.SuspendLayout();
            this.midPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // translateProgress
            // 
            this.translateProgress.Location = new System.Drawing.Point(329, 12);
            this.translateProgress.Name = "translateProgress";
            this.translateProgress.Size = new System.Drawing.Size(355, 23);
            this.translateProgress.TabIndex = 0;
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.titlePanel.Controls.Add(this.currentFileLabel);
            this.titlePanel.Controls.Add(this.title);
            this.titlePanel.Controls.Add(this.translateProgress);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(800, 48);
            this.titlePanel.TabIndex = 1;
            // 
            // currentFileLabel
            // 
            this.currentFileLabel.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentFileLabel.Location = new System.Drawing.Point(685, 12);
            this.currentFileLabel.Name = "currentFileLabel";
            this.currentFileLabel.Size = new System.Drawing.Size(103, 23);
            this.currentFileLabel.TabIndex = 2;
            this.currentFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // title
            // 
            this.title.Dock = System.Windows.Forms.DockStyle.Left;
            this.title.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(323, 48);
            this.title.TabIndex = 1;
            this.title.Text = "Переводчик";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // midPanel
            // 
            this.midPanel.Controls.Add(this.label6);
            this.midPanel.Controls.Add(this.toLang);
            this.midPanel.Controls.Add(this.fromLang);
            this.midPanel.Controls.Add(this.label5);
            this.midPanel.Controls.Add(this.cancelButton);
            this.midPanel.Controls.Add(this.translateButton);
            this.midPanel.Controls.Add(this.pathFilesLabel);
            this.midPanel.Controls.Add(this.chooseFilesButton);
            this.midPanel.Controls.Add(this.chooseFilesLabel);
            this.midPanel.Controls.Add(this.pathDirLabel);
            this.midPanel.Controls.Add(this.chooseDirButton);
            this.midPanel.Controls.Add(this.chooseDirLabel);
            this.midPanel.Location = new System.Drawing.Point(0, 51);
            this.midPanel.Name = "midPanel";
            this.midPanel.Size = new System.Drawing.Size(800, 127);
            this.midPanel.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(479, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 28);
            this.label6.TabIndex = 12;
            this.label6.Text = "На язык";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toLang
            // 
            this.toLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toLang.FormattingEnabled = true;
            this.toLang.Location = new System.Drawing.Point(563, 91);
            this.toLang.Name = "toLang";
            this.toLang.Size = new System.Drawing.Size(121, 23);
            this.toLang.TabIndex = 11;
            this.toLang.SelectedIndexChanged += new System.EventHandler(this.toLang_SelectedIndexChanged);
            // 
            // fromLang
            // 
            this.fromLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromLang.FormattingEnabled = true;
            this.fromLang.Location = new System.Drawing.Point(366, 91);
            this.fromLang.Name = "fromLang";
            this.fromLang.Size = new System.Drawing.Size(107, 23);
            this.fromLang.TabIndex = 9;
            this.fromLang.SelectedIndexChanged += new System.EventHandler(this.fromLang_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(282, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 28);
            this.label5.TabIndex = 8;
            this.label5.Text = "С языка";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.Location = new System.Drawing.Point(108, 87);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 28);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // translateButton
            // 
            this.translateButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.translateButton.Location = new System.Drawing.Point(12, 87);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(90, 28);
            this.translateButton.TabIndex = 6;
            this.translateButton.Text = "Перевод";
            this.translateButton.UseVisualStyleBackColor = true;
            this.translateButton.Click += new System.EventHandler(this.translateButton_Click);
            // 
            // pathFilesLabel
            // 
            this.pathFilesLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pathFilesLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pathFilesLabel.Location = new System.Drawing.Point(282, 54);
            this.pathFilesLabel.Name = "pathFilesLabel";
            this.pathFilesLabel.Size = new System.Drawing.Size(506, 19);
            this.pathFilesLabel.TabIndex = 5;
            // 
            // chooseFilesButton
            // 
            this.chooseFilesButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chooseFilesButton.Location = new System.Drawing.Point(201, 46);
            this.chooseFilesButton.Name = "chooseFilesButton";
            this.chooseFilesButton.Size = new System.Drawing.Size(75, 35);
            this.chooseFilesButton.TabIndex = 4;
            this.chooseFilesButton.Text = "Обзор";
            this.chooseFilesButton.UseVisualStyleBackColor = true;
            this.chooseFilesButton.Click += new System.EventHandler(this.chooseFilesButton_Click);
            // 
            // chooseFilesLabel
            // 
            this.chooseFilesLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chooseFilesLabel.Location = new System.Drawing.Point(12, 54);
            this.chooseFilesLabel.Name = "chooseFilesLabel";
            this.chooseFilesLabel.Size = new System.Drawing.Size(183, 19);
            this.chooseFilesLabel.TabIndex = 3;
            this.chooseFilesLabel.Text = "Файлы для перевода";
            this.chooseFilesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pathDirLabel
            // 
            this.pathDirLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pathDirLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pathDirLabel.Location = new System.Drawing.Point(282, 13);
            this.pathDirLabel.Name = "pathDirLabel";
            this.pathDirLabel.Size = new System.Drawing.Size(506, 19);
            this.pathDirLabel.TabIndex = 2;
            // 
            // chooseDirButton
            // 
            this.chooseDirButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chooseDirButton.Location = new System.Drawing.Point(201, 5);
            this.chooseDirButton.Name = "chooseDirButton";
            this.chooseDirButton.Size = new System.Drawing.Size(75, 35);
            this.chooseDirButton.TabIndex = 1;
            this.chooseDirButton.Text = "Обзор";
            this.chooseDirButton.UseVisualStyleBackColor = true;
            this.chooseDirButton.Click += new System.EventHandler(this.chooseDirButton_Click);
            // 
            // chooseDirLabel
            // 
            this.chooseDirLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chooseDirLabel.Location = new System.Drawing.Point(12, 13);
            this.chooseDirLabel.Name = "chooseDirLabel";
            this.chooseDirLabel.Size = new System.Drawing.Size(183, 19);
            this.chooseDirLabel.TabIndex = 0;
            this.chooseDirLabel.Text = "Директория переводов";
            this.chooseDirLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.panel1);
            this.bottomPanel.Controls.Add(this.resultBox);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 184);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(800, 106);
            this.bottomPanel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.resultLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 34);
            this.panel1.TabIndex = 5;
            // 
            // resultLabel
            // 
            this.resultLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultLabel.Location = new System.Drawing.Point(0, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(800, 34);
            this.resultLabel.TabIndex = 4;
            this.resultLabel.Text = "Результат:";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // resultBox
            // 
            this.resultBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultBox.Location = new System.Drawing.Point(0, 37);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(800, 69);
            this.resultBox.TabIndex = 0;
            this.resultBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 290);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.midPanel);
            this.Controls.Add(this.titlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.titlePanel.ResumeLayout(false);
            this.midPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgressBar translateProgress;
        private Panel titlePanel;
        private Label title;
        private Panel midPanel;
        private Label pathDirLabel;
        private Button chooseDirButton;
        private Label chooseDirLabel;
        private Panel bottomPanel;
        private RichTextBox resultBox;
        private Label label6;
        private ComboBox toLang;
        private ComboBox fromLang;
        private Label label5;
        private Button cancelButton;
        private Button translateButton;
        private Label pathFilesLabel;
        private Button chooseFilesButton;
        private Label chooseFilesLabel;
        private Label resultLabel;
        private Panel panel1;
        private Label currentFileLabel;
    }
}