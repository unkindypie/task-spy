using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;
using System.ServiceProcess;

namespace daemon_installer
{
    public partial class Form1 : Form
    {
        [Serializable]
        public class ServiceConfig
        {
            public string ip;
            public string servername;
            public string username;
            public string password;
            public ServiceConfig()
            {

            }
            public ServiceConfig(string ip, string servername, string username, string password)
            {
                this.ip = ip;
                this.servername = servername;
                this.username = username;
                this.password = password;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fd = new FolderBrowserDialog();
            var result = fd.ShowDialog();
            if(result == DialogResult.OK)
            {
                if (!Directory.Exists(fd.SelectedPath))
                {
                    Directory.CreateDirectory(fd.SelectedPath);
                }
                textBox1.Text = fd.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text != "" && textBox2.Text.Length > 4
                && textBox3.Text.Length > 1 && textBox4.Text.Length > 1
                && textBox5.Text.Length > 3))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }
            try
            {
                //записываю бинарники службы в папку для установки службы
                File.WriteAllBytes(textBox1.Text + "\\TaskSpy.exe", Properties.Resources.TaskSpy);
                //создаю конфиг файл с настройками авторизации на sql server
                XmlSerializer formatter = new XmlSerializer(typeof(ServiceConfig));
                var config = new ServiceConfig(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                using (FileStream fs = new FileStream(textBox1.Text + "\\config.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, config);
                }

                //запускаю процесс, инпут которого будет отпрвляться в cmd
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                //ставлю службу с помощью InstallUtil
                p.StandardInput.WriteLine(@"cd " + textBox1.Text.Replace(@"\\", @"\"));
                p.StandardInput.WriteLine(@"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil TaskSpy.exe");
                //MessageBox.Show(p.StandardOutput.ReadToEnd());
                p.StandardInput.Flush();
                p.StandardInput.Close();
                p.Close();
                //запускаю службу
                ServiceController controller = new ServiceController("TaskSpyService");
                if (controller.Status != ServiceControllerStatus.Running)
                    controller.Start();

            } catch(Exception ex)
            {
                MessageBox.Show("Установка не удалась!", ex.ToString());
            }
            MessageBox.Show("Служба успешно установлена, добавлена в автозапуск и запущена. Теперь за вами следят.");
            Close();
        }
    }
}
