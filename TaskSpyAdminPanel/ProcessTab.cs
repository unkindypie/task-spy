using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using TaskSpyAdminPanel.Models;
using TaskSpyAdminPanel.DB;

namespace TaskSpyAdminPanel
{
    public partial class ProcessTab : UserControl, ControllableTab
    {
        Process process;
        Process parentProcess;
        Machine machine;
        User user;
        List<ProcessHistoryItem> history;
        long reportId;
        bool canDraw = false;
        bool dynamic = true;
        static public Action<Process, User, long> AddProcessTab;

        public ProcessTab(Process process, User user, long reportId = -1)
        {
            InitializeComponent();

            this.process = process;
            machine = new Machine() { Id = process.Machine.Id, Name = process.Machine.Name };
            this.user = user;
            
            if(reportId != -1)
            {
                this.reportId = reportId;
                this.dynamic = false;
            }

            chbIsSytem.ForeColor = ColorPalette.FontColor;
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
                if (dynamic)
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
                }
                else
                {
                    this.process = await DBWorker.Self.fetchHistoryProcessAsync(process.PID, reportId);
                }
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
                if (dynamic)
                {
                    parentProcess = await DBWorker.Self.fetchProcessAsync(process.ParentPID, machine.Id);
                }
                else
                {
                    parentProcess = await DBWorker.Self.fetchHistoryProcessAsync(process.ParentPID, reportId);
                }
               
                linkParentProc.Enabled = true;
            }
            catch
            {
                linkParentProc.Enabled = false;
            }
            if(history == null)
            {
                try
                {
                    history = await DBWorker.Self.getProcessHistory(user.Id, process.Id, machine.Id);
                    backgroundWorker1.RunWorkerAsync();
                }
                catch { }

           
                //canDraw = true;
            }
           
        }
        string ProperEnd(int number)
        {
            if (((number % 100) > 10) && ((number % 100) < 20))
                return "часов";
            if (number % 10 == 1)
                return "час";
            if ((number % 10 == 2) || (number % 10 == 3) || (number % 10 == 4))
                return "часа";
            return "часов";
        }
        string minText = "";
        string maxText = "";
        float xStep = 10.0f;
        float scrollScaler = 25;
        public void DrawGraphic(Graphics g = null)
        {
            if (!canDraw || history == null || history.Count == 0) return;
            if (g == null) g = graphicGroupBox.CreateGraphics();
            g.Clear(this.BackColor);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //бордер
            g.DrawRectangle(Pens.LightGray, new Rectangle(0, 3, graphicGroupBox.Width - 2, graphicGroupBox.Height - 2));

            float max = history.Select(x => x.CPU).Max();
            float min = history.Select(x => x.CPU).Min() - 1f;
            if(minText == "" || maxText == "")
            {
                maxText = max.ToString("F") + "%";
                minText = history.Select(x => x.CPU).Where(cpu => cpu != -1).Min().ToString("F") + "%";
            }
     

            float height = graphicGroupBox.Height + 5 - graphicScroll.Height;
            //рисую минимумы/максимумы
            g.DrawString(
               maxText,
               new Font("HelveticaNeueCyr", 9.25f, FontStyle.Bold
               ),
               new SolidBrush(ColorPalette.Selected),
               new PointF(20, height * 0.12f)
               );

            g.DrawString(
                minText,
                new Font("HelveticaNeueCyr", 9.25f, FontStyle.Bold
                ),
                new SolidBrush(ColorPalette.Selected),
                new PointF(20, height * 0.9f)
            );

            //высчитываю шаг по y для правильного масштаба
            float yStep = height / (max - min);


            float lastX = 0;
            float lastY = 0;

            float startCord = 0;
            if(graphicScroll.Value != 0)
                startCord = (graphicScroll.Value * scrollScaler) / xStep;

            float xOffset = 0;
            DateTime offBegin = new DateTime();
            DateTime offEnd = new DateTime();
            int offStringOffset = 1;
            for (int i = (int)Math.Round(startCord);
                i < startCord + (graphicGroupBox.Width) / xStep; i++)
            {
                if (i >= history.Count) break;

                //сам график
                if (i > 0)
                {
                    var pen = history[i].CPU == -1 ? new Pen(ColorPalette.Red) : Pens.CornflowerBlue;
                    g.DrawLine(
                        pen,
                        new PointF(lastX, height - (lastY * yStep)),
                        new PointF(xOffset, height - (history[i].CPU * yStep)));
                    //время, когда не было отчетов процесса
                    if(i > 0 && history[i].CPU == -1 && history[i - 1].CPU != -1)
                    {
                        offBegin = history[i].Created;
                    } 
                    else if (i < history.Count && history[i].CPU == -1 && history[i + 1].CPU != -1 && offBegin != new DateTime())
                    {
                        offEnd = history[i + 1].Created;
                        double hours = (offEnd - offBegin).TotalHours;
                        g.DrawString(
                           "Процесс был мертв "+ hours.ToString("F") + " " + ProperEnd((int)hours), 
                           new Font("HelveticaNeueCyr", 9.25f, FontStyle.Bold
                           ),
                           new SolidBrush(ColorPalette.Red),
                           new PointF(xOffset - xStep * 20,  height * 0.5f + offStringOffset * 10)
                           );
                        offStringOffset++;
                    }
                }
                //даты
                if(i % 40 == 0)
                {
                    g.DrawString(
                        history[i].Created.ToString(),
                        new Font("HelveticaNeueCyr", 9.25f, FontStyle.Bold
                        ),
                        new SolidBrush(ColorPalette.FontColor),
                        new PointF(xOffset, height * 0.2f)
                        );
                }
                lastX = xOffset;
                lastY = history[i].CPU;
                xOffset += xStep;
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
            if (dynamic)
            {
                AddProcessTab(parentProcess, user, -1);
            }
            else
            {
                AddProcessTab(parentProcess, user, reportId);
            }
            
        }

        private void chbWhitelisted_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chbWhitelisted_MouseUp(object sender, MouseEventArgs e)
        {
            DBWorker.Self.whitelistProcess(process.Id, chbWhitelisted.Checked);

        }

        public void Refresh()
        {
            canDraw = false;
            history = null;
            LoadProcess();
        }

        public void OnTabClose()
        {
            updateTimer.Stop();
        }

        private void chbIsSytem_Click(object sender, EventArgs e)
        {

        }

        private void graphicGroupBox_Paint(object sender, PaintEventArgs e)
        {
            DrawGraphic(e.Graphics);
        }

        private void graphicScroll_Scroll(object sender, ScrollEventArgs e)
        {
            DrawGraphic();
        }
        private void enableScroll()
        {
            if (history == null) return;
            graphicScroll.Enabled = true;
            graphicScroll.Maximum =
            (int)(((history.Count - 1) * xStep - graphicScroll.ClientRectangle.Width) / scrollScaler);
            graphicScroll.Value = graphicScroll.Maximum - 1;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int oldSize = history.Count();
            int historyCount = history.Count;
            for (int i = 0; i < historyCount; i++)
            {
                //System.Diagnostics.Debug.WriteLine(history[i].Created.ToString());
                int insertionCounter = 0;
                while (i + 1 < historyCount &&
                    history[i + 1].Created - history[i].Created > new TimeSpan(0, 0, 0, 20, 500)
                    && insertionCounter < 25)
                {
                    history.Insert(i + 1, new ProcessHistoryItem()
                    {
                        Created = history[i].Created + new TimeSpan(0, 0, 11),
                        CPU = -1
                        //Memory = -1
                    });
                    historyCount++;
                    //System.Diagnostics.Debug.WriteLine(history[i + 1].Created.ToString() + " fake");
                    i++;
                    insertionCounter++;
                }
            }
            canDraw = true;
            this.BeginInvoke(new MethodInvoker(() => DrawGraphic()));
            this.BeginInvoke(new MethodInvoker(() => enableScroll()));
            //InvokePaint(graphicGroupBox, new PaintEventArgs(CreateGraphics(), graphicGroupBox.ClientRectangle));
            //DrawGraphic();
        }

        private void graphicGroupBox_SizeChanged(object sender, EventArgs e)
        {
            enableScroll();
        }

        private void ProcessTab_Scroll(object sender, ScrollEventArgs e)
        {
            DrawGraphic();
        }
    }
}
