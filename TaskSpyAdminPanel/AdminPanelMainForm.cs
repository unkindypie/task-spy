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
        //мой наследник tabcontrol с переписанной отрисовкой, для того, чтобы покрасить ее фон
        MyTabControl tabControl;
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

        TabPage createNiceTab()
        {
            var tab = new TabPage();
            tab.BackColor = ColorPalette.LightDark;
            tab.ForeColor = ColorPalette.FontColor;
            tab.BorderStyle = BorderStyle.None;
            

            return tab;
        }

        void AddUserTab(User user, Report report, Machine machine) {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            var tabpage = createNiceTab();
            tabpage.Text = $"Процессы пользователя {user.Name}";
            var processesTab = new ProcessesTab(user, report, machine);
            processesTab.Dock = DockStyle.Fill;
            tabpage.Controls.Add(processesTab);
            tabControl.TabPages.Add(tabpage);
            //переключаюсь на новую вкладку
            tabControl.SelectedIndex = tabControl.TabCount - 1;
            //если это первая октрытая вкладка, то по какой-то причине
            //событие selected не отрабатывает, так что нужно делать все самому
            if (tabControl.TabCount == 1)
            {
                processesTab.TabOpenned();
            }
        }

        void AddProcessTab(Process process, User user)
        {
            var tabpage = createNiceTab();
            tabpage.Text = $"{process.ProcessName} из {process.Machine.Name}";
            var processesTab = new ProcessTab(process, user);
            processesTab.Dock = DockStyle.Fill;
            tabpage.Controls.Add(processesTab);
            tabControl.TabPages.Add(tabpage);

            tabControl.SelectedIndex = tabControl.TabCount - 1;
            if (tabControl.TabCount == 1)
            {
                processesTab.TabOpenned();
            }
        }

        void AddReportSelectorTab(User user)
        {
            var tabpage = createNiceTab();
            tabpage.Text = $"Диспетчер отчетов пользователя {user.Name}";
            var reportsTab = new ReportSelectorTab(user, AddUserTab);
            reportsTab.Dock = DockStyle.Fill;
            tabpage.Controls.Add(reportsTab);
            tabControl.TabPages.Add(tabpage);

            tabControl.SelectedIndex = tabControl.TabCount - 1;
            if (tabControl.TabCount == 1)
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
            //инициализация tabcontrol
            tabControl = new MyTabControl();
            tabControl.Font = new Font("HelveticaNeueCyr", 8.25f, FontStyle.Bold); ;
            tabControl.Size = new Size(864, 548);

            tabControl.Selected += tabControl1_Selected;
            tabControl.MouseDoubleClick += tabControl1_MouseDoubleClick;
            tabControl.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(tabControl);
            cmsUser.ForeColor = ColorPalette.FontColor;

            menuStrip1.BackColor = ColorPalette.Dark;
            menuStrip1.Renderer = new MyRenderer();

        }
        //кастомный рендерер для менюшки, чтобы перекрасить цвет выбранного элемента
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }
        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return ColorPalette.Selected; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return ColorPalette.Dark; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return ColorPalette.Light; }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.DarkSlateGray; }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return ColorPalette.Light; }
            }
        }

        private void действияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        bool loaded = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            //подгрузка конфига
            OnLaunch();
            //авторизация
            loginForm = new LoginForm();
            Show();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                DBWorker.Self.Disconect();
                Close();
                return;
            }
            //подгрузка/отрисовка пользователей
            FillUsers();

            //для перегрузки drawItem
            lbUsers.DrawMode = DrawMode.OwnerDrawFixed;
            lbUsers.ItemHeight = 40;
        }
        //перегруженный метод отрисовки элемента списка пользователей,
        //где я рисую local_username и pseudonym пользователя
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lbUsers.Items.Count == 0) return;
            Brush roomsBrush;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

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
            var timeFont = new Font("HelveticaNeueCyr", 10.25f, FontStyle.Bold);
            e.Graphics.DrawString(user.Name, timeFont, Brushes.CornflowerBlue, e.Bounds.Left + 3, e.Bounds.Top + 5);
            var roomsFont = new Font("HelveticaNeueCyr", 9.25f, FontStyle.Bold);
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
            TabPage page = tabControl.SelectedTab;
            
            if (page != null)
            {
                if (tabControl.SelectedIndex - 1 < tabControl.TabPages.Count
                    && tabControl.SelectedIndex - 1 > 0)
                {
                    tabControl.SelectedTab = tabControl.TabPages[tabControl.SelectedIndex - 1];
                }
                (page.Controls[0] as ControllableTab).OnTabClose();
                tabControl.TabPages.Remove(page);


            }
        }
        //подгрузка процессов с бд только при октрытии
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl.TabCount > 0 && tabControl.SelectedTab.Controls.Count != 0)
            {
                foreach (TabPage tp in tabControl.TabPages)
                {
                    (tp.Controls[0] as ControllableTab).IsActive = false;
                }
                (tabControl.SelectedTab.Controls[0] as ControllableTab).TabOpenned();


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
            if(tabControl.SelectedIndex != -1)
            {
                (tabControl.SelectedTab.Controls[0] as ControllableTab).Refresh();
            }  
        }

        private void закрытьАктивнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == -1) return;

            if (tabControl.SelectedIndex - 1 < tabControl.TabPages.Count
                && tabControl.SelectedIndex - 1 > 0)
            {
                tabControl.SelectedTab = tabControl.TabPages[tabControl.SelectedIndex - 1];
            }
            tabControl.TabPages.Remove(tabControl.SelectedTab);
        }

        private void обновитьСписокПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillUsers();
        }

        private void смотретьПроцессыВРеальномВремениToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // This event is called once for each tab button in your tab control

            // First paint the background with a color based on the current tab

            // e.Index is the index of the tab in the TabPages collection.
            switch (e.Index)
            {
                case 0:
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
                    break;
                case 1:
                    e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds);
                    break;
                default:
                    break;
            }

            // Then draw the current tab button text 
            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-2, -2);
            e.Graphics.DrawString(tabControl.TabPages[e.Index].Text, this.Font, SystemBrushes.HighlightText, paddedBounds);
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
