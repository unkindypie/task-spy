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
    public partial class ReportView : UserControl
    {
        public Report report;
        User user;
        Machine machine;
        Action<User, Report, Machine> openProcessesTab;
        public ReportView(Report report, User user, Machine machine, Action<User, Report, Machine> openProcessesTab)
        {
            InitializeComponent();

            if (report == null) throw new Exception("we are here bro");

            this.report = report;
            this.user = user;
            this.machine = machine;
            this.openProcessesTab = openProcessesTab;
            fill();

            foreach(Control c in Controls)
            {
                c.MouseMove += ReportView_MouseMove;
                c.MouseLeave += ReportView_MouseLeave;
                c.MouseDoubleClick += ReportView_MouseDoubleClick;
                c.MouseClick += ReportView_MouseUp;
            }
        }


        void fill()
        {
            tbCreated.Text = report.Created.ToString();
            lCpu.Text = "CPU: " + report.CPU.ToString() + "%";
            lMem.Text = "Память: " + report.Mem.ToString("N0") + " Кб";
            lProcesses.Text = "Процессов: " + report.ProcessCount.ToString();
            lIp.Text = report.IP.ToString();
            chbInWhitelist.Checked = !report.HasUnwhitelisted;
            lbMachine.Text = "Машина: " + report.MachineName;
            if(report.HasUnwhitelisted)
            {
                BackColor = ColorPalette.Red;
            }
            else
            {
                BackColor = ColorPalette.Light;
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ReportView_MouseLeave(object sender, EventArgs e)
        {
            if (report.HasUnwhitelisted)
            {
                BackColor = ColorPalette.Red;
               
            }
            else
            {
                BackColor = ColorPalette.Light;
            }
        }

        private void ReportView_MouseMove(object sender, MouseEventArgs e)
        {
            BackColor = Color.CornflowerBlue;
        }

        private void ReportView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                openProcessesTab(user, report, machine);
            }
        }

        private void ReportView_Load(object sender, EventArgs e)
        {

        }

        private void ReportView_MouseUp(object sender, MouseEventArgs e)
        {
            //if(e.Button == MouseButtons.Right)
            //{
            //    contextMenuStrip1.Show(Cursor.Position);
            //}
        }

        private void chbInWhitelist_Click(object sender, EventArgs e)
        {
            if(!report.HasUnwhitelisted != chbInWhitelist.Checked)
            {
                report.HasUnwhitelisted = !chbInWhitelist.Checked;
                fill();
                DBWorker.Self.setWhitelistReport(report.Id, chbInWhitelist.Checked);
            }
        }
    }
}
