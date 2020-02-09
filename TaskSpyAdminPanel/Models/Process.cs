using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSpyAdminPanel.Models
{
    public class Process
    {

        public Process()
        {

        }
        public long Id
        {
            get; set;
        }
        public bool IsSystem
        {
            get; set;
        }
        public bool InWhitelist
        {
            get; set;
        }
        public Report Report
        {
            get; set;
        }
        public float CPU
        {
            get; set;
        }
        public long Mem
        {
            get; set;
        }
        public string ProcessName
        {
            get; set;
        }
        public int PID
        {
            get; set;
        }
        public int ParentPID
        {
            get; set;
        }
        public User User
        {
            get; set;
        }
        public string BinPath
        {
            get; set;
        }
        public long ReportId
        {
            get; set;
        }
        public Machine Machine
        {
            get; set;
        }
       

    }
}
