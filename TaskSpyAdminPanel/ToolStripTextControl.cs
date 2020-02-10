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
        private User user;
        public Action Refresh;
        public ToolStripTextControl()
        {
            InitializeComponent();

            tbPseudonym.Focus();
            //tbPseudonym.SetPlaceholder("Ввод");
        }
        
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                tbPseudonym.Text = user.Pseudonym;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DBWorker.Self.Connect() && tbPseudonym.Text.Length < 15 && user != null)
            {
                DBWorker.Self.setPseudonym(user.Id, tbPseudonym.Text);
                Refresh();
            }
        }
    }
}
