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
    public partial class ReportSelectorTab : UserControl, ControllableTab
    {
        User user;
        Action<User> openProcessesTab;

        public ReportSelectorTab(User user, Action<User> openProcessesTab)
        {
            InitializeComponent();

            this.user = user;
            this.openProcessesTab = openProcessesTab;
            flpReports.VerticalScroll.Maximum = 0;
        }
        bool loaded = false;
        bool loading = false;
        bool _isActive = false;

        //для обчисления количества отчетов на экран
        //(это размеры формы отчета)
        const int reportWidth = 177;
        const int reportHeight = 183;

        public bool IsActive
        {
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
                //LoadProcess();
            }

        }
        //dummy loading...
        private void button1_Click(object sender, EventArgs e)
        {
            flpReports.Controls.Add(new ReportView(new Report()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
       
     
        }
        //dummy loading check...
        private void flpReports_Scroll(object sender, ScrollEventArgs e)
        {
            if (flpReports.VerticalScroll.Visible)
            {  
                //если мы внизу, то нужно качать новые отчеты
                var scrollDelta = flpReports.VerticalScroll.Maximum - 
                    (flpReports.VerticalScroll.Value + reportHeight);
                button1.Text = (scrollDelta / flpReports.ClientRectangle.Height).ToString();
                if ((scrollDelta / flpReports.ClientRectangle.Height) == 0)
                {
                    //количество панелек репортов на экран
                    var reportsPerScreen = (flpReports.ClientRectangle.Width / reportWidth) * (flpReports.ClientRectangle.Height / reportHeight);
                    //MessageBox.Show($"Time to load {reportsPerScreen} reports");
                }

            }
        }
    }
}
