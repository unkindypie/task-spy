using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//мои пространства имен
using TaskSpyAdminPanel.Models;
using TaskSpyAdminPanel.Config;
using TaskSpyAdminPanel.DB;
using System.Runtime.InteropServices;

namespace TaskSpyAdminPanel
{
    public partial class Form1 : Form
    {
        LoginForm loginForm;
        async void FillUsers()
        {
            if (DBWorker.Self.Connect(false))
            {
                //загружаю реальных пользователей с бд, соответствующих строке поиска
                List<User> users = await DBWorker.Self.fetchUsers(tbUsrSearch.Text);
                //добавляю только пользователей, которых не было ранее
                lbUsers.DataSource = users;
                if(!loaded)
                {
                    AddUserTab((lbUsers.SelectedItem as User), null, null);
                    loaded = true;
                }
            }
            else
            {
                MessageBox.Show("Проблемы с подключением к базе данных. Проверьте интернет соеденение.");
            }
        }
        void OnLaunch()
        {
            //десериализую конфиг и применяю его значения на фильтрах в форме
            ConfigManager.Load();
            timer1.Start();

        }
        void SaveConfigChanges()
        {
            //сериализую конфигурацию фильтров
            ConfigManager.Save();
        }

        void AddUserTab(User user, Report report, Machine machine) {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            var tabpage = new TabPage();
            tabpage.Text = $"Процессы пользователя {user.Name}";
            var processesTab = new ProcessesTab(user, report, machine);
            processesTab.Dock = DockStyle.Fill;
            tabpage.Controls.Add(processesTab);
            tabControl1.TabPages.Add(tabpage);
            //переключаюсь на новую вкладку
            tabControl1.SelectedIndex = tabControl1.TabCount - 1;
            //если это первая октрытая вкладка, то по какой-то причине
            //событие selected не отрабатывает, так что нужно делать все самому
            if (tabControl1.TabCount == 1)
            {
                processesTab.TabOpenned();
            }
        }

        void AddProcessTab(Process process)
        {
            var tabpage = new TabPage();
            tabpage.Text = $"{process.ProcessName} из {process.Machine.Name}";
            var processesTab = new ProcessTab(process);
            processesTab.Dock = DockStyle.Fill;
            tabpage.Controls.Add(processesTab);
            tabControl1.TabPages.Add(tabpage);

            tabControl1.SelectedIndex = tabControl1.TabCount - 1;
            if (tabControl1.TabCount == 1)
            {
                processesTab.TabOpenned();
            }
        }

        void AddReportSelectorTab(User user)
        {
            var tabpage = new TabPage();
            tabpage.Text = $"Диспетчер отчетов пользователя {user.Name}";
            var reportsTab = new ReportSelectorTab(user, AddUserTab);
            reportsTab.Dock = DockStyle.Fill;
            tabpage.Controls.Add(reportsTab);
            tabControl1.TabPages.Add(tabpage);

            tabControl1.SelectedIndex = tabControl1.TabCount - 1;
            if (tabControl1.TabCount == 1)
            {
                reportsTab.TabOpenned();
            }
        }

        private UserPseudonymMenuItem userPseudonymForm;
        public Form1()
        {
            InitializeComponent();
            //коллбек, который будет открывать вкладку с еденичным процессом
            ProcessesTab.AddProcessTab = AddProcessTab;
            //для того, чтобы отрывать материнские процессы
            ProcessTab.AddProcessTab = AddProcessTab;

            tbUsrSearch.SetPlaceholder("Поиск");
            lbUsers.IntegralHeight = false;

            Action refresh = () => {
                cmsUser.Visible = false;
                
            };
            refresh += FillUsers;
            //менюшка на пкм по юзеру
            userPseudonymForm = new UserPseudonymMenuItem(refresh);
            cmsUser.Items.Add(userPseudonymForm);


            cmsUser.Items[0].Click += (object o, EventArgs e_) =>
            {
                DBWorker.Self.whitelistAllUserProcesses(userUnderClick.Id, true);
            };
            cmsUser.Items[1].Click += (object o, EventArgs e_) =>
            {
                DBWorker.Self.whitelistAllUserProcesses(userUnderClick.Id, false);
            };
            cmsUser.Items[2].Click += (object o, EventArgs e_) =>
            {
                AddReportSelectorTab(userUnderClick);
            };
            cmsUser.Items[3].Click += (object o, EventArgs e_) =>
            {
                AddUserTab(userUnderClick, null, null);
            };
        }

        private void действияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        bool loaded = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            OnLaunch();
            loginForm = new LoginForm();
            Show();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                DBWorker.Self.Disconect();
                Close();
                return;
            }
     
            //DBWorker.SetCredentials("SQL_E1118P1", "10.3.31.8", "E1118P1", "1P8111E");
            //DBWorker.SetCredentials("DESKTOP-CJ4FN0M", "", "sa", "baddev02");
            //DBWorker.SetCredentials("DESKTOP-6DIF51U\\SQL_S2", "", "sa", "baddev02");
            FillUsers();

            //var menu = new ContextMenuStrip();
            
            lbUsers.DrawMode = DrawMode.OwnerDrawFixed;
            lbUsers.ItemHeight = 40;

         
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lbUsers.Items.Count == 0) return;
            Brush roomsBrush;

          
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds,
                    e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, SystemColors.Control);

                roomsBrush = Brushes.Black;
            }
            else
            {
                roomsBrush = Brushes.Gray;
            }
            var linePen = new Pen(SystemBrushes.Control);
            var lineStartPoint = new Point(e.Bounds.Left, e.Bounds.Height + e.Bounds.Top);
            var lineEndPoint = new Point(e.Bounds.Width, e.Bounds.Height + e.Bounds.Top);

            e.Graphics.DrawLine(linePen, lineStartPoint, lineEndPoint);
            e.DrawBackground();
            var user = lbUsers.Items[e.Index] as User;
            var timeFont = new Font("Microsoft Sans Serif", 9.25f, FontStyle.Bold);
            e.Graphics.DrawString(user.Name, timeFont, Brushes.DarkBlue, e.Bounds.Left + 3, e.Bounds.Top + 5);
            var roomsFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            if (user.Pseudonym != "")
            {
                e.Graphics.DrawString(user.Pseudonym, roomsFont, roomsBrush, e.Bounds.Left + 3, e.Bounds.Top + 18);
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfigChanges();
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lbUsers.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                AddUserTab(lbUsers.SelectedItem as User, null, null);
            }
        }

        private void lbUsers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddUserTab(lbUsers.SelectedItem as User, null, null);
            }
        }

        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TabPage page = tabControl1.SelectedTab;
            
            if (page != null)
            {
                if (tabControl1.SelectedIndex - 1 < tabControl1.TabPages.Count
                    && tabControl1.SelectedIndex - 1 > 0)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.SelectedIndex - 1];
                }
                (page.Controls[0] as ControllableTab).OnTabClose();
                tabControl1.TabPages.Remove(page);


            }
        }
        //подгрузка процессов с бд только при октрытии
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.TabCount > 0 && tabControl1.SelectedTab.Controls.Count != 0)
            {
                foreach (TabPage tp in tabControl1.TabPages)
                {
                    (tp.Controls[0] as ControllableTab).IsActive = false;
                }
                (tabControl1.SelectedTab.Controls[0] as ControllableTab).TabOpenned();


            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        User userUnderClick;
        //открывает контекстное меню по ПКМ на пользователя в списке
        private void lbUsers_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var index = lbUsers.IndexFromPoint(e.Location);
                if (index == -1) return;
                var user = lbUsers.Items[index] as User;    
                userPseudonymForm.SetUser(user);

                userUnderClick = user;

                cmsUser.Show(lbUsers, new Point(e.X, e.Y));
                cmsUser.Visible = true;
               

            }
        }

        private void tbUsrSearch_TextChanged(object sender, EventArgs e)
        {
            FillUsers();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void диспетчерОтчетовToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //обвновляю текущую вкладку с помощью абстрактного метода ее интерфейса
        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex != -1)
            {
                (tabControl1.SelectedTab.Controls[0] as ControllableTab).Refresh();
            }  
        }

        private void закрытьАктивнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1) return;

            if (tabControl1.SelectedIndex - 1 < tabControl1.TabPages.Count
                && tabControl1.SelectedIndex - 1 > 0)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.SelectedIndex - 1];
            }
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void обновитьСписокПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillUsers();
        }

        private void смотретьПроцессыВРеальномВремениToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    public static class TextBoxExtension
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public static void SetPlaceholder(this TextBox box, string text)
        {
            SendMessage(box.Handle, EM_SETCUEBANNER, 0, text);
        }

    } 
}
