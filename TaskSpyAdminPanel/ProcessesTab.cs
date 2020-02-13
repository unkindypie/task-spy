using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TaskSpyAdminPanel.Config;
using TaskSpyAdminPanel.Models;
using TaskSpyAdminPanel.DB;
using System.Data.SqlClient;

namespace TaskSpyAdminPanel
{

    public partial class ProcessesTab : UserControl, ControllableTab
    {
        public class FieldsHider
        {
            public long Id
            {
                get; set;
            }
            public bool IsSystem
            {
                get; set;
            }
        }
        User user;
        public bool loaded = false;
        bool loading = false;
        DateTime lastLoad;
        Dictionary<KeyValuePair<int, int>, Process> pidsToProcess = new Dictionary<KeyValuePair<int, int>, Process>();
        DateTime lastReport = new DateTime();
        static public Action<Process> AddProcessTab;

        static Dictionary<string, string> dbNamesToUI = new Dictionary<string, string>();
        static ProcessesTab()
        {
            dbNamesToUI.Add("procname", "Имя процесса");
            dbNamesToUI.Add("username", "Пользователь");
            dbNamesToUI.Add("cpu_load", "Загрузка процессора");
            dbNamesToUI.Add("mem_load", "Физическая память");
            dbNamesToUI.Add("pid", "PID");
            dbNamesToUI.Add("parent_pid", "Материнский PID");
            dbNamesToUI.Add("is_system", "Системный");
        }
        bool _isActive = false;
    

        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                if(value == false)
                {
                    updateTimer.Stop();
                }
                _isActive = value;
            }
        }
        public void TabOpenned()
        {
            IsActive = true;

            //включаю автоподгрузку
            if (dynamic)
            {
                updateTimer.Start();
            }  
          
            if (!loaded)
            {

                LoadProcesses(true);
            }

        }

        public async Task<DataTable> GetProcessesWithAutoload(bool loadMachines, bool checkTime = true)
        {
            //загружаю список пк пользователя
            var machines = await DBWorker.Self.fetchUserMachines(user.Id);
            if (cbCurMachine.Items.Count > 0)
            {
                foreach (Machine m in machines)
                {
                    bool exists = false;
                    foreach (object cm in cbCurMachine.Items)
                    {
                        if ((cm as Machine).Id == m.Id)
                        {
                            exists = true;
                        }
                    }
                    if (!exists)
                        cbCurMachine.Items.Add(m);
                }
            }
            else
            {
                cbCurMachine.DataSource = machines;
            }
            var newReportTime = await DBWorker.Self.lastReport(user.Id,
                (cbCurMachine.SelectedItem as Machine).Id);

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

            tbLastReportTime.Text = newReportTime.ToString();

            //если нет свежего отчета, то ничего не обновляю
            if (checkTime && lastReport != new DateTime() && lastReport >= newReportTime)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                loading = false;
                return null;
            }
            lastReport = newReportTime;
            //загружаю новый отчет
            return await DBWorker.Self.fetchProcessesTableAsync(
                user.Id,
                (cbCurMachine.SelectedItem as Machine).Id,
                chbShowEveryUser.Checked
                );
            
        }

        public async void LoadProcesses(bool loadMachines, bool checkTime = true)
        {
            if (loading) return;
            loading = true;
            System.Diagnostics.Debug.WriteLine("Load processes call from " + user.Name);
            DataTable table;
            if (dynamic)
            {
                try
                {
                    table = await GetProcessesWithAutoload(loadMachines, checkTime);
                } catch (SqlException ex)
                {
                    if (ex.Number == -2)
                    {
                        MessageBox.Show("Кажется, что сервер плохо справляется с нагрузкой.");
                    }
                    return;
                }
                
            } else
            {
                table = await DBWorker.Self.getReport(user.Id, staticReport.Id, staticMachine.Id, chbShowEveryUser.Checked);
                tbLastReportTime.Text = staticReport.Created.ToString();
                if(cbCurMachine.Items.Count == 0) cbCurMachine.Items.Add(staticReport.MachineName);
            }
           
            if (table == null) return;
            //прячу идентификаторы
            pidsToProcess.Clear();
            foreach (DataRow r in table.Rows)
            {
                pidsToProcess.Add(
                    new KeyValuePair<int, int>(
                        int.Parse(r["pid"].ToString()),
                        int.Parse(r["parent_pid"].ToString())
                        ),
                    new Process() {
                        Id = int.Parse(r["id"].ToString()),
                        Mem = long.Parse(r["mem_load"].ToString()),
                        CPU = float.Parse(r["cpu_load"].ToString()),
                        ProcessName = r["procname"].ToString(),
                        User = new User() { Name = r["username"].ToString() },
                        PID = int.Parse(r["pid"].ToString()),
                        BinPath = "Загрузка...",
                        //ActualUserID = long.Parse(r["user_id"].ToString()),
                        Machine = cbCurMachine.SelectedItem as Machine,
                        InWhitelist = bool.Parse(r["in_whitelist"].ToString())
                    }
                    );
            }
            table.Columns.Remove("in_whitelist");
            //перевожу столбцы
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (dbNamesToUI.ContainsKey(table.Columns[i].ColumnName))
                {
                    table.Columns[i].ColumnName = dbNamesToUI[table.Columns[i].ColumnName];
                }
            }
            //фильтрую системные процессы
            if (!chbShowSysProc.Checked)
            {
                List<DataRow> deleteThem = new List<DataRow>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if ((bool)table.Rows[i][dbNamesToUI["is_system"]])
                    {
                        deleteThem.Add(table.Rows[i]);
                    }
                }
                foreach (DataRow r in deleteThem)
                {
                    table.Rows.Remove(r);
                }
            }

            lbProcessCount.Text = "Процессов: " + table.Rows.Count.ToString();

            //запоминаю параметры сортировки до обновления
            //string sortBy = "Загрузка процессора";
            string sortBy = dbNamesToUI["cpu_load"];
            ListSortDirection sortOrder = ListSortDirection.Descending;
            //запоминаю позицию скролла
            int scroll = processesGridView.FirstDisplayedScrollingRowIndex;
            if (scroll == -1) scroll = 0;
   
            if (processesGridView.SortedColumn != null)
            {
                sortBy = processesGridView.SortedColumn.Name;
                sortOrder = (processesGridView.SortOrder == System.Windows.Forms.SortOrder.Ascending ? ListSortDirection.Ascending
                    : ListSortDirection.Descending);
            }

            //применяю таблицу
            processesGridView.DataSource = table;
            
            //foreach(DataGridViewRow r in processesGridView.Rows)
            //{
            //    r.Cells[dbNamesToUI["mem_load"]].Value = DBNull.Value;
            //    r.Cells[dbNamesToUI["mem_load"]].ValueType = typeof(String);
            //    r.Cells[dbNamesToUI["mem_load"]].Value = long.Parse(r.Cells[dbNamesToUI["mem_load"]].Value.ToString()).ToString("N0");
            //}

            //применяю сортировку
            if (sortBy != "")
            {
                processesGridView.Sort(processesGridView.Columns[sortBy], sortOrder);
            }
            if (processesGridView.FirstDisplayedScrollingRowIndex != -1 && processesGridView.VerticalScrollingOffset > scroll)
            {
                processesGridView.FirstDisplayedScrollingRowIndex = scroll;
            }
            //processesGridView.AutoResizeColumns();
            processesGridView.AutoResizeRows();

            processesGridView.Columns.Remove("id");

            //прячу id записи и is_system в FieldsHider, который записываю в поле имени, так что
            //пользователю не заметен id в бд, но он все еще привязан к строке
           
            lastLoad = DateTime.Now;
            loading = false;
            if (!loaded)
            {
                loaded = true;
            };
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        void hightlightUnwightlisted()
        {
            foreach (DataGridViewRow r in processesGridView.Rows)
            {
                
                var pair = new KeyValuePair<int, int>(
                  int.Parse(processesGridView[dbNamesToUI["pid"], r.Index].Value.ToString()),
                  int.Parse(processesGridView[dbNamesToUI["parent_pid"], r.Index].Value.ToString())
                  );

                if (!pidsToProcess[pair].InWhitelist)
                {
                    r.DefaultCellStyle.BackColor = Color.FromArgb(245, 159, 183);
                    r.DefaultCellStyle.ForeColor = Color.Black;
                   // r.DefaultCellStyle.Font = new Font(r.InheritedStyle.Font, FontStyle.Bold);
                } else
                {
                    r.DefaultCellStyle.ForeColor = Color.Black;
                    r.DefaultCellStyle.BackColor = Control.DefaultBackColor;
                    r.DefaultCellStyle.Font = new Font(r.InheritedStyle.Font, FontStyle.Regular);
                }
            }
        }
        bool dynamic;
        Report staticReport;
        Machine staticMachine;
        public ProcessesTab(User user, Report report, Machine machine)
        {
            InitializeComponent();
            this.dynamic = true;
            this.user = user;
            lbProcessCount.ForeColor = Color.Black;
            //гружу конфиг
            ConfigManager.Load();

            //применяю конфиг
            chbShowSysProc.Checked = ConfigManager.Config.showSystemProcesses;
            chbHighlightUnwhitelisted.Checked = ConfigManager.Config.highlightUnwhitelisted;
            chbShowEveryUser.Checked = ConfigManager.Config.showEveryUser;
            //ивент хэндлер контекстного меню
            contextMenuStrip1.Items[1].Click += (object o, EventArgs e_) =>
            {
                whitelistSelectedProcesses(true);
                hightlightUnwightlisted();
            };
            contextMenuStrip1.Items[2].Click += (object o, EventArgs e_) =>
            {
                whitelistSelectedProcesses(false);
                hightlightUnwightlisted();
            };

            if(report != null && machine != null)
            {
                this.dynamic = false;
                this.staticReport = report;
                this.staticMachine = machine;
                cbCurMachine.Items.Add(machine);
                cbCurMachine.SelectedIndex = 0;
                cbCurMachine.Enabled = false;
            }
        }

        private void ProcessesTab_Load(object sender, EventArgs e)
        {
        
        }
       
        private void chbShowSysProc_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                ConfigManager.Config.showSystemProcesses = chbShowSysProc.Checked;
                LoadProcesses(false, false);
            }
          
        }

        private void chbHighlightUnwhitelisted_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.highlightUnwhitelisted = chbHighlightUnwhitelisted.Checked;
            if(chbHighlightUnwhitelisted.Checked)
            {
                hightlightUnwightlisted();
            }
            else
            {
                foreach (DataGridViewRow r in processesGridView.Rows)
                {

                    r.DefaultCellStyle.ForeColor = Color.Black;
                    r.DefaultCellStyle.BackColor = Control.DefaultBackColor;
                    r.DefaultCellStyle.Font = new Font(r.InheritedStyle.Font, FontStyle.Regular);
                }
            }
        }

        private void cbCurMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                lastReport = new DateTime();
                LoadProcesses(false, false);
            }
        }

        private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ConfigManager.Config.sortBy = cbSortBy.SelectedIndex;
        }
        private void chbShowEveryUser_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                ConfigManager.Config.showEveryUser = chbShowEveryUser.Checked;
                LoadProcesses(false, false);
            }
          
        }

        private void ProcessesTab_Enter(object sender, EventArgs e)
        {
            
        }

        private void ProcessesTab_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void processesGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            //пара pid/материнский pid для поиска процесса в словаре
            var pair = new KeyValuePair<int, int>(
                int.Parse(processesGridView[dbNamesToUI["pid"], e.RowIndex].Value.ToString()),
                int.Parse(processesGridView[dbNamesToUI["parent_pid"], e.RowIndex].Value.ToString())
                );
            if(AddProcessTab != null)
            {
                //открываю вкладку процесса
                AddProcessTab(pidsToProcess[pair]);
            }


        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            //если вкладка активна, обновляю данные
            if (IsActive && (DateTime.Now - lastLoad) > new TimeSpan(0, 0, 0, 3))
            {
                LoadProcesses(true);
            }
        }

        private void processesGridView_Sorted(object sender, EventArgs e)
        {
            if (chbHighlightUnwhitelisted.Checked)
            {
                hightlightUnwightlisted();
            }
        }

        async void whitelistSelectedProcesses(bool mode)
        {
            HashSet<int> rowIndexes = new HashSet<int>();

            foreach (DataGridViewCell c in processesGridView.SelectedCells)
            {
                rowIndexes.Add(c.RowIndex);
            }

            foreach (int index in rowIndexes)
            {
                var pair = new KeyValuePair<int, int>(
                    int.Parse(processesGridView[dbNamesToUI["pid"], index].Value.ToString()),
                    int.Parse(processesGridView[dbNamesToUI["parent_pid"], index].Value.ToString())
                );
                var process = pidsToProcess[pair];


                //единожды меняю все в бд
                if (mode && !process.InWhitelist)
                {
                    DBWorker.Self.whitelistProcess(process.Id, true);
                    process.InWhitelist = true;
                }
                else if (!mode && process.InWhitelist)
                {
                    DBWorker.Self.whitelistProcess(process.Id, false);
                    process.InWhitelist = false;
                }

                //меняю цвет процессов с одинаковыми путями и названиями
                foreach (Process p in pidsToProcess.Values) {
                    if(p.BinPath == process.BinPath && p.ProcessName == process.ProcessName && p.InWhitelist != mode)
                    {
                        p.InWhitelist = mode;
                    }
                }
                
            }
        }
        //добавление выделенных процессов в вайтлист
        private void processesGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            

            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);

        }
        //хэдлер открытия процесса
        private void открытьПроцессToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = processesGridView.SelectedCells[processesGridView.SelectedCells.Count - 1].RowIndex;
            //пара pid/материнский pid для поиска процесса в словаре
            var pair = new KeyValuePair<int, int>(
                int.Parse(processesGridView[dbNamesToUI["pid"], index].Value.ToString()),
                int.Parse(processesGridView[dbNamesToUI["parent_pid"], index].Value.ToString())
                );
            if (AddProcessTab != null)
            {
                //открываю вкладку процесса
                AddProcessTab(pidsToProcess[pair]);
            }
        }

        public void Refresh()
        {
            
        }

        public void OnTabClose()
        {
            updateTimer.Stop();
        }
    }


}
