using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookTranslator.Forms
{
    public partial class AuthForm : Form
    {
        MainForm? mainForm;
        CancellationTokenSource? cts;

        public AuthForm()
        {
            InitializeComponent();
        }

        private async void enterButton_Click(object sender, EventArgs e)
        {
            String oAuth = this.oAuthTextBox.Text;
            if (oAuth != String.Empty)
            {
                cts = new CancellationTokenSource();
                Reply iamTokenReply = await YandexCloud.IamToken.Get(oAuth, cts.Token);
                if (iamTokenReply.Code != 200)
                {
                    MessageBox.Show($"{iamTokenReply.Message} Code: {iamTokenReply.Code}");
                }
                else
                {
                    this.Hide();
                    mainForm = new MainForm(this, iamTokenReply.Message);
                    mainForm.Show();
                }
            } else
            {
                MessageBox.Show("Введите oAuth токен");
            }
        }
    }
}
