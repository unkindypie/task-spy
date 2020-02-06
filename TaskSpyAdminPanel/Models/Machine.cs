using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSpyAdminPanel.Models
{
    public class Machine
    {
        public string Name
        {
            get;
            set;
        }
        public long Id
        {
            get;
            set;
        }
        public DateTime LastReport
        {
            get;
            set;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
