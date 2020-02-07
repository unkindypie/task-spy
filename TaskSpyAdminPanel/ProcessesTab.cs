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
        Dictionary<int, FieldsHider> hided = new Dictionary<int, FieldsHider>();
        DateTime lastReport;

        static Dictionary<string, string> dbNamesToUI = new Dictionary<string, string>();
        static ProcessesTab()
        {
            dbNamesToUI.Add("procname", "Имя процесса");
            dbNamesToUI.Add("username", "Пользователь");
            dbNamesToUI.Add("cpu_load", "Загрузка процессора");
            dbNamesToUI.Add("mem_load", "ОЗУ");
            dbNamesToUI.Add("pid", "PID");
            dbNamesToUI.Add("parent_pid", "Материнский PID");
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
            updateTimer.Start();
            if (!loaded)
            {
                LoadProcesses(true);
                return;
            }
            if ((DateTime.Now - lastLoad) > new TimeSpan(0, 0, 0, 10))
            {
                LoadProcesses(true);
            }

        }
        public async void LoadProcesses(bool loadMachines)
        {
            if (loading) return;
            loading = true;
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

            tbLastReportTime.Text = newReportTime.ToString();
            if (lastReport == null && lastReport >= newReportTime)
            {
                loading = false;
                return;
            }
            lastReport = newReportTime;

            var table = await DBWorker.Self.fetchProcessesAsync(
                user.Id,
                (cbCurMachine.SelectedItem as Machine).Id,
                chbShowEveryUser.Checked
                );


            //перевожу столбцы
            for(int i = 0; i < table.Columns.Count; i++)
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
                    if ((bool)table.Rows[i]["is_system"])
                    {
                        deleteThem.Add(table.Rows[i]);
                    }
                }
                foreach(DataRow r in deleteThem)
                {
                    table.Rows.Remove(r);
                }
            }
            //прячу id записи и is_system в FieldsHider, который записываю в поле имени, так что
            //пользователю не заметен id в бд, но он все еще привязан к строке
            hided.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                hided.Add(i, new FieldsHider()
                {
                    Id = long.Parse(table.Rows[i]["id"].ToString()),
                    IsSystem = (bool)table.Rows[i]["is_system"]
                });
            }
            table.Columns.Remove("is_system");
            table.Columns.Remove("id");
            lbProcessCount.Text = "Процессов: " + table.Rows.Count.ToString();

            //запоминаю параметры сортировки до обновления
            string sortBy = "Загрузка процессора";
            ListSortDirection sortOrder = ListSortDirection.Descending;
            //запоминаю позицию скролла
            int scroll = processesGridView.FirstDisplayedScrollingRowIndex;
            if (scroll == -1) scroll = 0;
   
            if (processesGridView.SortedColumn != null)
            {
                sortBy = processesGridView.SortedColumn.Name;
                sortOrder = processesGridView.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending
                    : ListSortDirection.Descending;
            }
            //применяю таблицу
            processesGridView.DataSource = table;
            
            //применяю сортировку
            if (sortBy != "")
            {
                processesGridView.Sort(processesGridView.Columns[sortBy], sortOrder);
            }
            processesGridView.FirstDisplayedScrollingRowIndex = scroll;


            lastLoad = DateTime.Now;
            loading = false;
            if (!loaded) loaded = true;
        }
        public ProcessesTab(User user)
        {
            InitializeComponent();
            this.user = user;

            ConfigManager.Load();

            chbShowSysProc.Checked = ConfigManager.Config.showSystemProcesses;
            chbHighlightUnwhitelisted.Checked = ConfigManager.Config.highlightUnwhitelisted;
            chbShowEveryUser.Checked = ConfigManager.Config.showEveryUser;
        }


        private void ProcessesTab_Load(object sender, EventArgs e)
        {
        
        }
       
        private void chbShowSysProc_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.showSystemProcesses = chbShowSysProc.Checked;
        }

        private void chbHighlightUnwhitelisted_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.highlightUnwhitelisted = chbHighlightUnwhitelisted.Checked;
        }

        private void cbCurMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                LoadProcesses(false);
            }
        }

        private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ConfigManager.Config.sortBy = cbSortBy.SelectedIndex;
        }
        private void chbShowEveryUser_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.showEveryUser = chbShowEveryUser.Checked;
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
            MessageBox.Show(hided[e.RowIndex].Id.ToString());


        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {

            //если вкладка активна, обновляю данные
            if (IsActive && (DateTime.Now - lastLoad) > new TimeSpan(0, 0, 0, 3))
            {
                LoadProcesses(true);
            }
        }
    }


}
