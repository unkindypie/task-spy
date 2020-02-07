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
        public ProcessTab(Process process)
        {
            InitializeComponent();

            this.process = process;
            lbProcessName.Text = process.ProcessName;
            tbBinPath.Text = process.BinPath;
            tbCpuLoad.Text = process.CPU + " %";
            tbMemLoad.Text = process.Mem.ToString("N0") + " Кб";

        }
        bool loaded = false;
        bool _isActive = false;
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
            //if (!loaded)
            //{
            //    LoadProcesses(true);
            //    return;
            //}
            //if ((DateTime.Now - lastLoad) > new TimeSpan(0, 0, 0, 10))
            //{
            //    LoadProcesses(true);
            //}
        }

        private void ProcessTab_Load(object sender, EventArgs e)
        {

        }
    }
}
