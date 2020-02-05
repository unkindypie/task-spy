using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TaskSpyAdminPanel.DB;

namespace TaskSpyAdminPanel
{
    public partial class LoginForm : Form
    {
        public string serverName = "";
        public string ip = "";
        public string userName = "";
        public string password = "";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                DBWorker.SetCredentials(textBox4.Text, textBox1.Text, textBox2.Text, textBox3.Text);
                if (!DBWorker.Self.Connect())
                {
                    MessageBox.Show("Невреный логин или пароль. А может сервер упал?");
                }
                else
                {
                    serverName = textBox4.Text;
                    ip = textBox1.Text;
                    userName = textBox2.Text;
                    password = textBox3.Text;

                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Все поля кроме IP должны быть заполнены.");
            }
        }

        private void textBox3_TextChange(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
