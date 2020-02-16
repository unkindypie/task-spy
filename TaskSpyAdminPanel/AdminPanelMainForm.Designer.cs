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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.cmsUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьВсеПроцессыПользователяВВайтлистToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВсеПроцессыПользователяИзВайтлистаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.диспетчерОтчетовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.смотретьПроцессыВРеальномВремениToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmsUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.menuStrip1.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияToolStripMenuItem,
            this.вкладкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1043, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьСписокПользователейToolStripMenuItem});
            this.действияToolStripMenuItem.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.действияToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.действияToolStripMenuItem.Text = "Пользователи";
            this.действияToolStripMenuItem.Click += new System.EventHandler(this.действияToolStripMenuItem_Click);
            // 
            // обновитьСписокПользователейToolStripMenuItem
            // 
            this.обновитьСписокПользователейToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.обновитьСписокПользователейToolStripMenuItem.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.обновитьСписокПользователейToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.обновитьСписокПользователейToolStripMenuItem.Name = "обновитьСписокПользователейToolStripMenuItem";
            this.обновитьСписокПользователейToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.обновитьСписокПользователейToolStripMenuItem.Text = "Обновить список пользователей";
            this.обновитьСписокПользователейToolStripMenuItem.Click += new System.EventHandler(this.обновитьСписокПользователейToolStripMenuItem_Click);
            // 
            // вкладкиToolStripMenuItem
            // 
            this.вкладкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьАктивнуюToolStripMenuItem,
            this.закрытьАктивнуюToolStripMenuItem});
            this.вкладкиToolStripMenuItem.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.вкладкиToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.вкладкиToolStripMenuItem.Name = "вкладкиToolStripMenuItem";
            this.вкладкиToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.вкладкиToolStripMenuItem.Text = "Вкладки";
            // 
            // обновитьАктивнуюToolStripMenuItem
            // 
            this.обновитьАктивнуюToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.обновитьАктивнуюToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.обновитьАктивнуюToolStripMenuItem.Name = "обновитьАктивнуюToolStripMenuItem";
            this.обновитьАктивнуюToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.обновитьАктивнуюToolStripMenuItem.Text = "Обновить активную";
            this.обновитьАктивнуюToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // закрытьАктивнуюToolStripMenuItem
            // 
            this.закрытьАктивнуюToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.закрытьАктивнуюToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.закрытьАктивнуюToolStripMenuItem.Name = "закрытьАктивнуюToolStripMenuItem";
            this.закрытьАктивнуюToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.закрытьАктивнуюToolStripMenuItem.Text = "Закрыть активную";
            this.закрытьАктивнуюToolStripMenuItem.Click += new System.EventHandler(this.закрытьАктивнуюToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, -146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Пользователи";
            // 
            // lbUsers
            // 
            this.lbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lbUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbUsers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.ItemHeight = 14;
            this.lbUsers.Location = new System.Drawing.Point(0, 48);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(127, 504);
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
            this.splitContainer1.Location = new System.Drawing.Point(14, 29);
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
            this.toolTip1.SetToolTip(this.splitContainer1.Panel2, "Для закрытия вкладки кликните по ней дважды.");
            this.splitContainer1.Panel2MinSize = 700;
            this.splitContainer1.Size = new System.Drawing.Size(1029, 548);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 7;
            // 
            // tbUsrSearch
            // 
            this.tbUsrSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUsrSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tbUsrSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUsrSearch.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tbUsrSearch.Location = new System.Drawing.Point(0, 20);
            this.tbUsrSearch.Name = "tbUsrSearch";
            this.tbUsrSearch.Size = new System.Drawing.Size(129, 21);
            this.tbUsrSearch.TabIndex = 8;
            this.tbUsrSearch.TextChanged += new System.EventHandler(this.tbUsrSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Пользователи";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmsUser
            // 
            this.cmsUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.cmsUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьВсеПроцессыПользователяВВайтлистToolStripMenuItem,
            this.удалитьВсеПроцессыПользователяИзВайтлистаToolStripMenuItem,
            this.диспетчерОтчетовToolStripMenuItem,
            this.смотретьПроцессыВРеальномВремениToolStripMenuItem});
            this.cmsUser.Name = "cmsUser";
            this.cmsUser.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsUser.Size = new System.Drawing.Size(349, 92);
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
            // смотретьПроцессыВРеальномВремениToolStripMenuItem
            // 
            this.смотретьПроцессыВРеальномВремениToolStripMenuItem.Name = "смотретьПроцессыВРеальномВремениToolStripMenuItem";
            this.смотретьПроцессыВРеальномВремениToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.смотретьПроцессыВРеальномВремениToolStripMenuItem.Text = "Смотреть процессы в реальном времени";
            this.смотретьПроцессыВРеальномВремениToolStripMenuItem.Click += new System.EventHandler(this.смотретьПроцессыВРеальномВремениToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.toolTip1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1043, 590);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1029, 608);
            this.Name = "Form1";
            this.Text = "Task Spy - Big Brother\'s panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
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

