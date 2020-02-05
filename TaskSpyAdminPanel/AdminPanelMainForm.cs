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

namespace TaskSpyAdminPanel
{
    public partial class Form1 : Form
    {
        void FillUsers()
        {

        }
        void OnLaunch()
        {
            //десериализую конфиг и применяю его значения на фильтрах в форме
            ConfigManager.Load();
            chbHighlightUnwhitelisted.Checked = ConfigManager.Config.highlightUnwhitelisted;
            chbShowSysProc.Checked = ConfigManager.Config.showSystemProcesses;
            if(ConfigManager.Config.sortBy < cbSortBy.Items.Count)
            {
                cbSortBy.SelectedIndex = ConfigManager.Config.sortBy;
            }
            if (ConfigManager.Config.machine < cbCurMachine.Items.Count)
            {
                cbCurMachine.SelectedIndex = ConfigManager.Config.machine;
            }
        }
        void SaveConfigChanges()
        {
            //сериализую конфигурацию фильтров
            ConfigManager.Config = new StateConfig(
                chbShowSysProc.Checked,
                chbHighlightUnwhitelisted.Checked,
                cbSortBy.SelectedIndex,
                cbCurMachine.SelectedIndex
                );
            ConfigManager.Save();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void действияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            OnLaunch();


            // This will change the ListBox behaviour, so you can customize the drawing of each item on the list.
            // The fixed mode makes every item on the list to have a fixed size. If you want each item having
            // a different size, you can use DrawMode.OwnerDrawVariable.
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;

            // Here we define the height of each item on your list.
            listBox1.ItemHeight = 40;

            // Here i will just make an example data source, to emulate the control you are trying to reproduce.
            var dataSet = new List<Tuple<string, string>>();
            dataSet.Add(new Tuple<string, string>($"A311_{10}", ""));
            dataSet.Add(new Tuple<string, string>($"A311_{11}", ""));
            dataSet.Add(new Tuple<string, string>($"A311_{12}", "Кто-то"));
            dataSet.Add(new Tuple<string, string>($"A311_{13}", "Ламер"));
            dataSet.Add(new Tuple<string, string>($"A311_{14}", "Еще кто-то"));
            for (int i = 15; i < 25; i++)
            {
                dataSet.Add(new Tuple<string, string>($"A311_{i}", ""));
            }
            listBox1.DataSource = dataSet;


            var table = new DataTable();
            table.Columns.Add("Имя процесса");
            table.Columns.Add("Нагрузка на процессор");
            table.Columns.Add("Память");
            table.Columns.Add("Нагрузка на сеть");
            table.Columns.Add("Родительский процесс");
            table.Rows.Add("chrome");
            table.Rows.Add("minecraft");
            dataGridView1.DataSource = table;
            var tab = tabControl1.TabPages[1];
            //tabControl1.TabPages.Remove(tab);
            foreach(Control c in tab.Controls)
            {
               // MessageBox.Show(c.Name);
            }
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
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
            var dataItem = listBox1.Items[e.Index] as Tuple<string, string>;

            // Here we will format the font of the part corresponding to the Time text of your list item.
            // You can change to wathever you want - i defined it as a bold font.
            var timeFont = new Font("Microsoft Sans Serif", 9.25f, FontStyle.Bold);

            // Here you draw the time text on the top of the list item, using the format you defined.
            e.Graphics.DrawString(dataItem.Item1, timeFont, Brushes.DarkBlue, e.Bounds.Left + 3, e.Bounds.Top + 5);

            // Now we draw the avaliable rooms part. First we define our font.
            var roomsFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            if(dataItem.Item2 != "")
            {
                // And, finally, we draw that text.
                e.Graphics.DrawString(dataItem.Item2, roomsFont, roomsBrush, e.Bounds.Left + 3, e.Bounds.Top + 18);
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfigChanges();
        }
    }
}
