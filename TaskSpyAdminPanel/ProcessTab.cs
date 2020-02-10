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
    public partial class ProcessTab : UserControl, ControllableTab
    {
        Process process;
        Process parentProcess;
        Machine machine;

        static public Action<Process> AddProcessTab;

        public ProcessTab(Process process)
        {
            InitializeComponent();

            this.process = process;
            machine = new Machine() { Id = process.Machine.Id, Name = process.Machine.Name };

         

            fillForm();
        }
        bool loaded = false;
        bool loading = false;
        bool _isActive = false;
        public async void LoadProcess()
        {
            if (loading) return;
            if (!loaded)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            }
            loading = true;
            if (DBWorker.Self.Connect())
            {
                var newProcess = await DBWorker.Self.fetchProcessAsync(process.PID, machine.Id);
                if (process.Report != null && newProcess.Report.Created < process.Report.Created)
                {
                    loading = false;
                    if (!loaded) loaded = true;
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                    return;
                }
                this.process = newProcess;
                fillForm();    
            }
            chbWhitelisted.Enabled = true;
            loading = false;
            if (!loaded)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                loaded = true;
            }
            try
            {
                parentProcess = await DBWorker.Self.fetchProcessAsync(process.ParentPID, machine.Id);
                linkParentProc.Enabled = true;
            }
            catch
            {
                linkParentProc.Enabled = false;
            }
        }
        void fillForm()
        {
            lbProcessName.Text = process.ProcessName;
            tbBinPath.Text = process.BinPath;
            tbCpuLoad.Text = process.CPU + " %";
            tbMemLoad.Text = process.Mem.ToString("N0") + " Кб";
            tbPid.Text = process.PID.ToString();
            chbWhitelisted.Checked = process.InWhitelist;
            chbIsSytem.Checked = process.IsSystem;
            tbUser.Text = process.User.Name;
        }
        public bool IsActive {
            get
            {
                return _isActive;
            }
            set
            {
                if (value == false)
                {
                    updateTimer.Stop();
                }
                _isActive = value;
            }
        }

        public void TabOpenned()
        {
            IsActive = true;
            updateTimer.Start();
            if (!loaded)
            {
                LoadProcess();
            }

        }

        private void ProcessTab_Load(object sender, EventArgs e)
        {

        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (_isActive)
            {
                LoadProcess();
            }
        }

        private void linkParentProc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            parentProcess.Machine = new Machine() { Id = machine.Id, Name = machine.Name };
            parentProcess.User = new User() { Name = process.User.Name };
            AddProcessTab(parentProcess);
        }

        private void chbWhitelisted_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chbWhitelisted_MouseUp(object sender, MouseEventArgs e)
        {
            DBWorker.Self.whitelistProcess(process.Id, chbWhitelisted.Checked);

        }
    }
}
