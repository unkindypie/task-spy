using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TaskSpyAdminPanel.Models;
using TaskSpyAdminPanel.DB;

namespace TaskSpyAdminPanel
{
    public partial class ToolStripTextControl : UserControl
    {
        public User user;
        public ToolStripTextControl()
        {
            InitializeComponent();

            //tbPseudonym.SetPlaceholder("Ввод");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DBWorker.Self.Connect() && tbPseudonym.Text != "")
            {

            }
        }
    }
}
