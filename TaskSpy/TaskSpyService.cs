using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TaskSpy
{
    public partial class TaskSpyService : ServiceBase
    {
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
            eventLog1.WriteEntry("TaskSpyService is in OnStart.");
            Timer timer = new Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler((object obj, ElapsedEventArgs e)=> {
                eventLog1.WriteEntry("Timer is working");
            });
            timer.Start();

        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("TaskSpyService is in OnStop.");
        }
    }
}
