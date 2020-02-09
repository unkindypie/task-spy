using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using TaskSpyAdminPanel.Models;

namespace TaskSpyAdminPanel
{

    public class UserPseudonymMenuItem : ToolStripControlHost
    {
        public ToolStripTextControl control;

        public UserPseudonymMenuItem(User user) : base(new ToolStripTextControl())
        {
            this.control = this.Control as ToolStripTextControl;
            control.user = user;
        }

    }
}
