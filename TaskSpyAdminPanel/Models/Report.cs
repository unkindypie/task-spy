using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSpyAdminPanel.Models
{
    public class Report
    {
        public long Id
        {
            get; set;
        }
        public DateTime Created
        {
            get; set;
        }
        public long Mem
        {
            get; set;
        }
        public int CPU
        {
            get; set;
        }
        public bool InWhitelist
        {
            get; set;
        }
        public int ProcessCount
        {
            get; set;
        }
        public string IP
        {
            get; set;
        }
    }
}
