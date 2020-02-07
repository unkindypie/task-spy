using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Collections.Specialized;

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
            if (!(textBox1.Text != "" && textBox3.Text.Length > 1 && textBox4.Text.Length > 1
                && textBox5.Text.Length > 3))
            {
                MessageBox.Show("Все поля должны быть заполнены!(IP можно оставить пустым)");
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
                //установка
                tbLog.Text += $"Конфиг файл сериализован по пути {textBox1.Text}"+ Environment.NewLine;
                string serviceName = "TaskSpyService";
                tbLog.Text = "Пошла установка."+ Environment.NewLine;
                var installer = new ServiceProcessInstaller
                {
                    Account = ServiceAccount.LocalSystem
                };
                var serviceInstaller = new ServiceInstaller();
                String[] cmdline = { @"/assemblypath=" + textBox1.Text + "\\TaskSpy.exe" };
                var context = new InstallContext("service_install.log", cmdline);
                serviceInstaller.Context = context;
                serviceInstaller.DisplayName = serviceName;
                serviceInstaller.ServiceName = serviceName;
                serviceInstaller.Description = "Big Brother is watching you.";
                serviceInstaller.StartType = ServiceStartMode.Automatic;
                serviceInstaller.Parent = installer;
                serviceInstaller.Install(new ListDictionary());
                tbLog.Text += "Готово. Служба успешно установлена и прописана в автозапуск." + Environment.NewLine;
            } catch(Exception ex)
            {
                MessageBox.Show("Установка успешно не удалась!" + ex.ToString());
                Close();
                return;
            }
            try
            {
                ServiceController controller = new ServiceController("TaskSpyService");
                if (controller.Status != ServiceControllerStatus.Running)
                {
                    controller.Start();
                }
                tbLog.Text += "Служба запущена. Теперь за вами следят.";
            }
            catch
            {

            }
          
            //MessageBox.Show("Служба успешно установлена, добавлена в автозапуск. Теперь за вами следят.");
           
        }
    }
}
