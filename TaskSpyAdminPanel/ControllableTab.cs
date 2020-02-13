using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskSpyAdminPanel
{
    interface ControllableTab
    {
        bool IsActive
        {
            get;
            set;
        }
        void TabOpenned();
        void Refresh();
        void OnTabClose();
    }
}
