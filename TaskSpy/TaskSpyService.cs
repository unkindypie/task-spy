using System;
using System.Diagnostics;
using System.Net;
using System.ServiceProcess;
using System.Timers;
using System.Xml.Serialization;
using System.IO;
using TaskSpy.Monitoring;

namespace TaskSpy
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
    public partial class TaskSpyService : ServiceBase
    {
        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public TaskSpyService()
        {
            InitializeComponent();
            eventLog1 = new EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {
            ServiceConfig config;
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(ServiceConfig));
                config = (ServiceConfig)formatter.Deserialize(
                    new FileStream(
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml"
                        ), FileMode.Open
                    ));

            } catch(Exception e)
            {
                eventLog1.WriteEntry("Config haven't been readed!");
                eventLog1.WriteEntry(e.ToString());
                return;
            }
            eventLog1.WriteEntry($"Config was readed with the " +
                $"folowing fields: ip:{config.ip}, servername: {config.servername},"+
                $"username:{config.username}, password:{config.password}");

            DBConnector.SetCredentials(config.servername, config.ip, config.username, config.password);
            var machineName = Environment.MachineName;
            var userName = Environment.UserName;
            string ip = GetLocalIPAddress();

            eventLog1.WriteEntry("TaskSpyService is started.");
            Timer timer = new Timer();
            timer.Interval = 10000;
            timer.Elapsed += new ElapsedEventHandler((object obj, ElapsedEventArgs e)=> {
                //сканирую запущенные процессы
                var processes = Monitor.ScanProcesses();
                //если есть подключение к бд и сканнер отработал 3 раза (необходимо для
                //корректного вычисления нагрузки на процессор), то начинаем слать отчеты
                if (DBConnector.Self.Connect() && Monitor.ScanCounter > 3)
                {
                    long reportID = DBConnector.Self.createReport(
                        Monitor.TotalMemoryUsage,
                        Monitor.TotalCpuUsage,
                        machineName,
                        ip
                        );
                    
                    foreach (ProcessModel p in processes)
                    {
                        DBConnector.Self.sendProcess(reportID, p);
                    }
                } else
                {
                    eventLog1.WriteEntry("[ERR]TaskSpyService is not connected to db.");
                }
            });
            timer.Start();

        }

        protected override void OnStop()
        {
            
            eventLog1.WriteEntry("TaskSpyService is stoped.");
            
        }
    }
}
