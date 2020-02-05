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
    public partial class ProcessesTab : UserControl
    {
        User user;
        public bool loaded = false;
        DateTime lastLoad;
        Dictionary<int, FieldsHider> hided = new Dictionary<int, FieldsHider>();

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

        public void TabOpened()
        {
            if (!loaded)
            {
                LoadProcesses();
                return;
            }
            if((DateTime.Now - lastLoad) > new TimeSpan(0, 0, 0, 10))
            {
                LoadProcesses();
            }
            
        }
        public async void LoadProcesses()
        {
            var table = await DBWorker.Self.fetchProcessesAsync(user.Id, 2, chbShowEveryUser.Checked);
     
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
            this.processesGridView.DataSource = table;
            lastLoad = DateTime.Now;
            if (!loaded) loaded = true;
        }
        public ProcessesTab(User user)
        {
            InitializeComponent();
            this.user = user;

            ConfigManager.Load();

            chbShowSysProc.Checked = ConfigManager.Config.showSystemProcesses;
            chbHighlightUnwhitelisted.Checked = ConfigManager.Config.highlightUnwhitelisted;
            //if (ConfigManager.Config.sortBy < cbSortBy.Items.Count)
            //{
            //    cbSortBy.SelectedIndex = ConfigManager.Config.sortBy;
            //}
            //if (ConfigManager.Config.machine < cbCurMachine.Items.Count)
            //{
            //    cbCurMachine.SelectedIndex = ConfigManager.Config.machine;
            //}
       
        }

        public void SetMachines(List<Machine> machines)
        {
            cbCurMachine.DataSource = machines;
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
            ConfigManager.Config.machine = cbCurMachine.SelectedIndex;
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
            MessageBox.Show(hided[e.RowIndex].Id.ToString());


        }
    }
}
