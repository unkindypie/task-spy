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

namespace TaskSpyAdminPanel
{
    public partial class ReportView : UserControl
    {
        Report report;
        public ReportView(Report report)
        {
            InitializeComponent();

            this.report = report;
        }

        void fill()
        {
            tbCreated.Text = report.Created.ToString();
            lCpu.Text = "CPU: " + report.CPU.ToString();
            lMem.Text = "Память: " + report.Mem.ToString();
            lIp.Text = report.IP.ToString();
            chbInWhitelist.Checked = report.InWhitelist;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
