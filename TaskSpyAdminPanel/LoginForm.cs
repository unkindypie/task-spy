using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

using TaskSpyAdminPanel.DB;
using TaskSpyAdminPanel.Config;

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

            textBox4.Text = ConfigManager.Config.server;
            textBox1.Text = ConfigManager.Config.ip;
            textBox2.Text = ConfigManager.Config.username;
            textBox3.Text = ConfigManager.Config.password;
            if (textBox4.Text != "")
            {
                checkBox1.Checked = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //валидация ip
            bool isIpValid = false;
            if(textBox1.Text == "")
            {
                isIpValid = true;
            } else
            {
                try
                {
                    IPAddress.Parse(textBox1.Text);
                    isIpValid = true;
                }
                catch { }
            }
 

            if(isIpValid && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                DBWorker.SetCredentials(textBox4.Text, textBox1.Text, textBox2.Text, textBox3.Text);
                bool connected = false;
                try
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    connected = await DBWorker.Self.ConnectAsync(false);
                } catch
                {
                   
                }
                if(!connected) MessageBox.Show($"Невозможно подключится к серверу {textBox4.Text}. Проверьте данные, которые вы ввели.");

                else
                {
                    serverName = textBox4.Text;
                    ip = textBox1.Text;
                    userName = textBox2.Text;
                    password = textBox3.Text;

                    if (checkBox1.Checked)
                    {
                        ConfigManager.Config.server = textBox4.Text;
                        ConfigManager.Config.ip = textBox1.Text;
                        ConfigManager.Config.username = textBox2.Text;
                        ConfigManager.Config.password = textBox3.Text;
                    }

                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                if (!isIpValid)
                {
                    MessageBox.Show("IP не валидный!");
                }
                else
                {
                    MessageBox.Show("Все должны обязательно быть заполннеными. IP может быть оставлен пустым, если сервер в нем не нуждается.");
                }
               
            }
        }

        private void textBox3_TextChange(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
