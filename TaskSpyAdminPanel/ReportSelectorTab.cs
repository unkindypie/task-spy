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
    public partial class ReportSelectorTab : UserControl, ControllableTab
    {
        User user;
        Action<User, Report, Machine> openProcessesTab;

        //основная коллекция элемента управления
        ControlCollection reports;

        public ReportSelectorTab(User user, Action<User, Report, Machine> openProcessesTab)
        {
            InitializeComponent();

            this.user = user;
            this.openProcessesTab = openProcessesTab;
            flpReports.VerticalScroll.Maximum = 0;
            flpReports.MouseWheel += flpReports_Scroll;

            reports = flpReports.Controls;
            
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
        //высчитывает количество элементов матрицы flow layout, которое влазит в экран
        private int CalculateReportsCount()
        {
            return (flpReports.ClientRectangle.Width / reportWidth) * (flpReports.ClientRectangle.Height / reportHeight);
        }
        //перевод из моделей отчетов в их графический элемент
        private Control[] modelToView(List<Report> reports)
        {
            var views = new List<ReportView>();
            foreach(Report r in reports)
            {
                views.Add(new ReportView(r, user, (cbMachine.SelectedItem as Machine), openProcessesTab));
            }
            return views.ToArray();
        }
        
        public async void LoadReports(int length = -1, bool loadMachines = true, bool loadDates = false)
        {
            if (loading) return;
            loading = true;
            dtpTo.Enabled = dtpFrom.Enabled =
                cbMachine.Enabled = сhbOnlyUnwhitelisted.Enabled = button1.Enabled = false;
            
            if(loadDates)
            {
                var maxTime = await DBWorker.Self.lastReport(user.Id);

                dtpFrom.MaxDate = maxTime;
                dtpTo.MaxDate = maxTime - (new TimeSpan(0, 0, 30));
                if (!loaded)
                {
                    var minTime = await DBWorker.Self.firstReport(user.Id);

                    dtpFrom.MinDate = minTime + (new TimeSpan(0, 0, 30));
                    dtpTo.MinDate = minTime;
                    dtpTo.Value = minTime;
                }
            }

            if (loadMachines)
            {
                //загружаю список пк пользователя
                var machines = await DBWorker.Self.fetchUserMachines(user.Id);
                if (cbMachine.Items.Count > 0)
                {
                    foreach (Machine m in machines)
                    {
                        bool exists = false;
                        foreach (Machine cm in cbMachine.Items)
                        {
                            if (cm.Id == m.Id)
                            {
                                exists = true;
                            }
                        }
                        if (!exists)
                            cbMachine.Items.Add(m);
                    }
                }
                else
                {
                    cbMachine.Items.AddRange(machines.ToArray());
                    cbMachine.SelectedItem = cbMachine.Items[0];
                }
            }


            DateTime from;
            int listLength;
            if (reports.Count == 0)
            {
                from = dtpFrom.Value;
                listLength = length == -1 ? CalculateReportsCount() + (flpReports.ClientRectangle.Width / reportWidth) : length;
            }
            else
            {
                from = (reports[reports.Count - 1] as ReportView).report.Created;
                listLength = length == -1 ? CalculateReportsCount() : length;
            }
            var loadedReports = await DBWorker.Self.getReportList(from, user.Id, listLength, true, dtpTo.Value, сhbOnlyUnwhitelisted.Checked);

            if(loadedReports != null)
            {
                reports.AddRange(modelToView(loadedReports));
               
            }
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

            dtpTo.Enabled = dtpFrom.Enabled = cbMachine.Enabled = 
                сhbOnlyUnwhitelisted.Enabled = button1.Enabled = true;
            if (!loaded) loaded = true;
            loading = false;
        }

        void ControllableTab.Refresh()
        {
            if (!loaded) return;

            reports.Clear();
            LoadReports(-1, true, true);
        }
        public void TabOpenned()
        {
            IsActive = true;
            updateTimer.Start();
            if (!loaded)
            {
                LoadReports(-1, true, true);
            }

        }

        private void flpReports_Scroll(object sender, EventArgs e)
        {
            if (flpReports.VerticalScroll.Visible)
            {  
                //если мы внизу, то нужно качать новые отчеты
                var scrollDelta = flpReports.VerticalScroll.Maximum - 
                    (flpReports.VerticalScroll.Value + reportHeight);
                //button1.Text = (scrollDelta / flpReports.ClientRectangle.Height).ToString();
                if ((scrollDelta / flpReports.ClientRectangle.Height) == 0)
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    LoadReports(-1, false);
                    
                }

            }
        }

        private void flpReports_MouseClick(object sender, MouseEventArgs e)
        {
            //flpReports.Focus();
        }

        private void flpReports_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void сhbOnlyUnwhitelisted_CheckedChanged(object sender, EventArgs e)
        {
            if (!loaded) return;

            reports.Clear();
            LoadReports(-1, false, false);
        }

        private void cbMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                reports.Clear();
                LoadReports(-1, true, false);
            }
        }

        private void flpReports_Resize(object sender, EventArgs e)
        {
      
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpTo.MaxDate = dtpFrom.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dtpFrom.MinDate = dtpTo.Value;
        }

        private void dtpFrom_CloseUp(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loaded && !loading)
            {
                reports.Clear();
                LoadReports(-1, false, false);
            }
        }

        private void ReportSelectorTab_SizeChanged(object sender, EventArgs e)
        {
            if (!loaded) return;


            var expectedCount = CalculateReportsCount() + (flpReports.ClientRectangle.Width / reportWidth) * 2;
            if (reports.Count < expectedCount)
            {
                LoadReports(expectedCount - reports.Count);
            }
        }

        void ControllableTab.OnTabClose()
        {
            updateTimer.Stop();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {

        }

        private void сhbOnlyUnwhitelisted_Click(object sender, EventArgs e)
        {
        }
    }
}
