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
        public string OwnerName
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

    }
}
