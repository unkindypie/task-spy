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
        void FillUsers()
        {

            if (DBWorker.Self.Connect())
            {
                List<User> users = DBWorker.Self.fetchUsers();
                lbUsers.DataSource = users;
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


        }
        void SaveConfigChanges()
        {
            //сериализую конфигурацию фильтров
            ConfigManager.Save();
        }

        void AddUserTab(User user) {
            var tabpage = new TabPage();
            tabpage.Text = $"Процессы пользователя {user.Name}";
            var processesTab = new ProcessesTab(user);
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
            tabpage.Text = $"{process.ProcessName} от {process.OwnerName}";
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

        public Form1()
        {
            InitializeComponent();
            //коллбек, который будет открывать вкладку с еденичным процессом
            ProcessesTab.AddProcessTab = AddProcessTab;
            tbUsrSearch.SetPlaceholder("Поиск");
            lbUsers.IntegralHeight = false;
        }

        private void действияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OnLaunch();
            //loginForm = new LoginForm();
            //Show();
            //if (loginForm.ShowDialog() != DialogResult.OK)
            //{
            //    Close();
            //}
            //DBWorker.SetCredentials("SQL_E1118P1", "10.3.31.8", "E1118P1", "1P8111E");
            DBWorker.SetCredentials("DESKTOP-CJ4FN0M", "", "sa", "baddev02");
            FillUsers();




            // This will change the ListBox behaviour, so you can customize the drawing of each item on the list.
            // The fixed mode makes every item on the list to have a fixed size. If you want each item having
            // a different size, you can use DrawMode.OwnerDrawVariable.
            lbUsers.DrawMode = DrawMode.OwnerDrawFixed;

            // Here we define the height of each item on your list.
            lbUsers.ItemHeight = 40;

            // Here i will just make an example data source, to emulate the control you are trying to reproduce.


            var table = new DataTable();
            table.Columns.Add("Имя процесса");
            table.Columns.Add("Нагрузка на процессор");
            table.Columns.Add("Память");
            table.Columns.Add("Нагрузка на сеть");
            table.Columns.Add("Родительский процесс");
            table.Rows.Add("chrome");
            table.Rows.Add("minecraft");
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lbUsers.Items.Count == 0) return;
            // This variable will hold the color of the bottom text - the one saying the count of 
            // the avaliable rooms in your example.
            Brush roomsBrush;

            // Here we override the DrawItemEventArgs to change the color of the selected 
            // item background to one of our preference.
            // I changed to SystemColors.Control, to be more like the list you are trying to reproduce.
            // Also, as I see in your example, the font of the room text part is black colored when selected, and gray
            // colored when not selected. So, we are going to reproduce it as well, by setting the correct color
            // on our variable defined above.
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

            // Looking more at your example, i noticed a gray line at the bottom of each item.
            // Lets reproduce that, too.
            var linePen = new Pen(SystemBrushes.Control);
            var lineStartPoint = new Point(e.Bounds.Left, e.Bounds.Height + e.Bounds.Top);
            var lineEndPoint = new Point(e.Bounds.Width, e.Bounds.Height + e.Bounds.Top);

            e.Graphics.DrawLine(linePen, lineStartPoint, lineEndPoint);

            // Command the event to draw the appropriate background of the item.
            e.DrawBackground();

            // Here you get the data item associated with the current item being drawed.
            var user = lbUsers.Items[e.Index] as User;

            // Here we will format the font of the part corresponding to the Time text of your list item.
            // You can change to wathever you want - i defined it as a bold font.
            var timeFont = new Font("Microsoft Sans Serif", 9.25f, FontStyle.Bold);

            // Here you draw the time text on the top of the list item, using the format you defined.
            e.Graphics.DrawString(user.Name, timeFont, Brushes.DarkBlue, e.Bounds.Left + 3, e.Bounds.Top + 5);

            // Now we draw the avaliable rooms part. First we define our font.
            var roomsFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            if (user.Pseudonym != "")
            {
                // And, finally, we draw that text.
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
                AddUserTab(lbUsers.SelectedItem as User);
            }
        }

        private void lbUsers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddUserTab(lbUsers.SelectedItem as User);
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
                tabControl1.TabPages.Remove(page);


            }
        }
        //подгрузка процессов с бд только при октрытии
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.TabCount > 0 && tabControl1.SelectedTab.Controls.Count != 0 &&
                tabControl1.SelectedTab.Controls[0].GetType().ToString() == "TaskSpyAdminPanel.ProcessesTab")
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
