namespace TaskSpyAdminPanel
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьСписокПользователейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вкладкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьАктивнуюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьАктивнуюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbUsrSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.cmsUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьВсеПроцессыПользователяВВайтлистToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВсеПроцессыПользователяИзВайтлистаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.диспетчерОтчетовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.смотретьПроцессыВРеальномВремениToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmsUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияToolStripMenuItem,
            this.вкладкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьСписокПользователейToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.действияToolStripMenuItem.Text = "Пользователи";
            this.действияToolStripMenuItem.Click += new System.EventHandler(this.действияToolStripMenuItem_Click);
            // 
            // обновитьСписокПользователейToolStripMenuItem
            // 
            this.обновитьСписокПользователейToolStripMenuItem.Name = "обновитьСписокПользователейToolStripMenuItem";
            this.обновитьСписокПользователейToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.обновитьСписокПользователейToolStripMenuItem.Text = "Обновить список пользователей";
            this.обновитьСписокПользователейToolStripMenuItem.Click += new System.EventHandler(this.обновитьСписокПользователейToolStripMenuItem_Click);
            // 
            // вкладкиToolStripMenuItem
            // 
            this.вкладкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьАктивнуюToolStripMenuItem,
            this.закрытьАктивнуюToolStripMenuItem});
            this.вкладкиToolStripMenuItem.Name = "вкладкиToolStripMenuItem";
            this.вкладкиToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.вкладкиToolStripMenuItem.Text = "Вкладки";
            // 
            // обновитьАктивнуюToolStripMenuItem
            // 
            this.обновитьАктивнуюToolStripMenuItem.Name = "обновитьАктивнуюToolStripMenuItem";
            this.обновитьАктивнуюToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.обновитьАктивнуюToolStripMenuItem.Text = "Обновить активную";
            this.обновитьАктивнуюToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // закрытьАктивнуюToolStripMenuItem
            // 
            this.закрытьАктивнуюToolStripMenuItem.Name = "закрытьАктивнуюToolStripMenuItem";
            this.закрытьАктивнуюToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.закрытьАктивнуюToolStripMenuItem.Text = "Закрыть активную";
            this.закрытьАктивнуюToolStripMenuItem.Click += new System.EventHandler(this.закрытьАктивнуюToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, -136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Пользователи";
            // 
            // lbUsers
            // 
            this.lbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(0, 45);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(170, 420);
            this.lbUsers.TabIndex = 6;
            this.toolTip1.SetToolTip(this.lbUsers, "Список пользователей.  Двойной щелчок для открытия текущего отчета, ПКМ для просм" +
        "отра возможных опций.");
            this.lbUsers.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.lbUsers.SelectedIndexChanged += new System.EventHandler(this.lbUsers_SelectedIndexChanged);
            this.lbUsers.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbUsers_KeyUp);
            this.lbUsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbUsers_MouseDoubleClick);
            this.lbUsers.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbUsers_MouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tbUsrSearch);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lbUsers);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2MinSize = 700;
            this.splitContainer1.Size = new System.Drawing.Size(954, 465);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 7;
            // 
            // tbUsrSearch
            // 
            this.tbUsrSearch.Location = new System.Drawing.Point(3, 19);
            this.tbUsrSearch.Name = "tbUsrSearch";
            this.tbUsrSearch.Size = new System.Drawing.Size(164, 20);
            this.tbUsrSearch.TabIndex = 8;
            this.tbUsrSearch.TextChanged += new System.EventHandler(this.tbUsrSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Пользователи";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 465);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            this.tabControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDoubleClick);
            // 
            // cmsUser
            // 
            this.cmsUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьВсеПроцессыПользователяВВайтлистToolStripMenuItem,
            this.удалитьВсеПроцессыПользователяИзВайтлистаToolStripMenuItem,
            this.диспетчерОтчетовToolStripMenuItem,
            this.смотретьПроцессыВРеальномВремениToolStripMenuItem});
            this.cmsUser.Name = "cmsUser";
            this.cmsUser.Size = new System.Drawing.Size(349, 114);
            // 
            // добавитьВсеПроцессыПользователяВВайтлистToolStripMenuItem
            // 
            this.добавитьВсеПроцессыПользователяВВайтлистToolStripMenuItem.Name = "добавитьВсеПроцессыПользователяВВайтлистToolStripMenuItem";
            this.добавитьВсеПроцессыПользователяВВайтлистToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.добавитьВсеПроцессыПользователяВВайтлистToolStripMenuItem.Text = "Добавить все процессы пользователя в вайтлист";
            // 
            // удалитьВсеПроцессыПользователяИзВайтлистаToolStripMenuItem
            // 
            this.удалитьВсеПроцессыПользователяИзВайтлистаToolStripMenuItem.Name = "удалитьВсеПроцессыПользователяИзВайтлистаToolStripMenuItem";
            this.удалитьВсеПроцессыПользователяИзВайтлистаToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.удалитьВсеПроцессыПользователяИзВайтлистаToolStripMenuItem.Text = "Удалить все процессы пользователя из вайтлиста";
            // 
            // диспетчерОтчетовToolStripMenuItem
            // 
            this.диспетчерОтчетовToolStripMenuItem.Name = "диспетчерОтчетовToolStripMenuItem";
            this.диспетчерОтчетовToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.диспетчерОтчетовToolStripMenuItem.Text = "Диспетчер отчетов";
            this.диспетчерОтчетовToolStripMenuItem.Click += new System.EventHandler(this.диспетчерОтчетовToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // смотретьПроцессыВРеальномВремениToolStripMenuItem
            // 
            this.смотретьПроцессыВРеальномВремениToolStripMenuItem.Name = "смотретьПроцессыВРеальномВремениToolStripMenuItem";
            this.смотретьПроцессыВРеальномВремениToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.смотретьПроцессыВРеальномВремениToolStripMenuItem.Text = "Смотреть процессы в реальном времени";
            this.смотретьПроцессыВРеальномВремениToolStripMenuItem.Click += new System.EventHandler(this.смотретьПроцессыВРеальномВремениToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 504);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(970, 500);
            this.Name = "Form1";
            this.Text = "Task Spy - Big Brother\'s panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cmsUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox tbUsrSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsUser;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem добавитьВсеПроцессыПользователяВВайтлистToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВсеПроцессыПользователяИзВайтлистаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem диспетчерОтчетовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьСписокПользователейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вкладкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьАктивнуюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьАктивнуюToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem смотретьПроцессыВРеальномВремениToolStripMenuItem;
    }
}

