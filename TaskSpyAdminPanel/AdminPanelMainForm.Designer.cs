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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.graphicGroupBox = new System.Windows.Forms.GroupBox();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.tbMemLoad = new System.Windows.Forms.TextBox();
            this.tbCpuLoad = new System.Windows.Forms.TextBox();
            this.tbBinPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.linkParentProc = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelProcName = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbLastReportTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCurMachine = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbSortBy = new System.Windows.Forms.ComboBox();
            this.chbShowSysProc = new System.Windows.Forms.CheckBox();
            this.chbHighlightUnwhitelisted = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            this.действияToolStripMenuItem.Click += new System.EventHandler(this.действияToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.dateTimePickerTo);
            this.tabPage2.Controls.Add(this.graphicGroupBox);
            this.tabPage2.Controls.Add(this.dateTimePickerFrom);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.tbMemLoad);
            this.tabPage2.Controls.Add(this.tbCpuLoad);
            this.tabPage2.Controls.Add(this.tbBinPath);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.linkParentProc);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.labelProcName);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(772, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "chrome";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(507, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "До:";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerTo.Location = new System.Drawing.Point(538, 199);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(130, 20);
            this.dateTimePickerTo.TabIndex = 13;
            // 
            // graphicGroupBox
            // 
            this.graphicGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphicGroupBox.Location = new System.Drawing.Point(6, 225);
            this.graphicGroupBox.Name = "graphicGroupBox";
            this.graphicGroupBox.Size = new System.Drawing.Size(675, 293);
            this.graphicGroupBox.TabIndex = 11;
            this.graphicGroupBox.TabStop = false;
            this.graphicGroupBox.Text = "График работы";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(371, 199);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(130, 20);
            this.dateTimePickerFrom.TabIndex = 12;
            this.dateTimePickerFrom.Value = new System.DateTime(2020, 1, 25, 13, 50, 0, 0);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(342, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "От:";
            // 
            // tbMemLoad
            // 
            this.tbMemLoad.Location = new System.Drawing.Point(163, 130);
            this.tbMemLoad.Name = "tbMemLoad";
            this.tbMemLoad.ReadOnly = true;
            this.tbMemLoad.Size = new System.Drawing.Size(186, 20);
            this.tbMemLoad.TabIndex = 10;
            this.tbMemLoad.Text = "108 261 Kb";
            // 
            // tbCpuLoad
            // 
            this.tbCpuLoad.Location = new System.Drawing.Point(163, 95);
            this.tbCpuLoad.Name = "tbCpuLoad";
            this.tbCpuLoad.ReadOnly = true;
            this.tbCpuLoad.Size = new System.Drawing.Size(186, 20);
            this.tbCpuLoad.TabIndex = 7;
            this.tbCpuLoad.Text = "14.7%";
            // 
            // tbBinPath
            // 
            this.tbBinPath.Location = new System.Drawing.Point(163, 59);
            this.tbBinPath.Name = "tbBinPath";
            this.tbBinPath.ReadOnly = true;
            this.tbBinPath.Size = new System.Drawing.Size(186, 20);
            this.tbBinPath.TabIndex = 6;
            this.tbBinPath.Text = "C:\\Program Files (x86)\\Google\\Chrome\\Application";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Память:";
            // 
            // linkParentProc
            // 
            this.linkParentProc.AutoSize = true;
            this.linkParentProc.Location = new System.Drawing.Point(163, 160);
            this.linkParentProc.Name = "linkParentProc";
            this.linkParentProc.Size = new System.Drawing.Size(42, 13);
            this.linkParentProc.TabIndex = 5;
            this.linkParentProc.TabStop = true;
            this.linkParentProc.Text = "chrome";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Родительский процесс:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Нагрзка CPU:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Путь:";
            // 
            // labelProcName
            // 
            this.labelProcName.AutoSize = true;
            this.labelProcName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProcName.Location = new System.Drawing.Point(21, 14);
            this.labelProcName.Name = "labelProcName";
            this.labelProcName.Size = new System.Drawing.Size(104, 31);
            this.labelProcName.TabIndex = 0;
            this.labelProcName.Text = "chrome";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbLastReportTime);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbCurMachine);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.cbSortBy);
            this.tabPage1.Controls.Add(this.chbShowSysProc);
            this.tabPage1.Controls.Add(this.chbHighlightUnwhitelisted);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(772, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Процессы пользователя A311_10";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbLastReportTime
            // 
            this.tbLastReportTime.Location = new System.Drawing.Point(533, 9);
            this.tbLastReportTime.Name = "tbLastReportTime";
            this.tbLastReportTime.ReadOnly = true;
            this.tbLastReportTime.Size = new System.Drawing.Size(100, 20);
            this.tbLastReportTime.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(431, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Последний отчет:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Машина:";
            // 
            // cbCurMachine
            // 
            this.cbCurMachine.FormattingEnabled = true;
            this.cbCurMachine.Location = new System.Drawing.Point(64, 9);
            this.cbCurMachine.Name = "cbCurMachine";
            this.cbCurMachine.Size = new System.Drawing.Size(121, 21);
            this.cbCurMachine.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(196, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Сортировать по:";
            // 
            // cbSortBy
            // 
            this.cbSortBy.FormattingEnabled = true;
            this.cbSortBy.Items.AddRange(new object[] {
            "Имени"});
            this.cbSortBy.Location = new System.Drawing.Point(292, 9);
            this.cbSortBy.Name = "cbSortBy";
            this.cbSortBy.Size = new System.Drawing.Size(115, 21);
            this.cbSortBy.TabIndex = 3;
            // 
            // chbShowSysProc
            // 
            this.chbShowSysProc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbShowSysProc.AutoSize = true;
            this.chbShowSysProc.Location = new System.Drawing.Point(259, 412);
            this.chbShowSysProc.Name = "chbShowSysProc";
            this.chbShowSysProc.Size = new System.Drawing.Size(137, 17);
            this.chbShowSysProc.TabIndex = 2;
            this.chbShowSysProc.Text = "Системные процессы";
            this.chbShowSysProc.UseVisualStyleBackColor = true;
            // 
            // chbHighlightUnwhitelisted
            // 
            this.chbHighlightUnwhitelisted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbHighlightUnwhitelisted.AutoSize = true;
            this.chbHighlightUnwhitelisted.Location = new System.Drawing.Point(17, 412);
            this.chbHighlightUnwhitelisted.Name = "chbHighlightUnwhitelisted";
            this.chbHighlightUnwhitelisted.Size = new System.Drawing.Size(236, 17);
            this.chbHighlightUnwhitelisted.TabIndex = 1;
            this.chbHighlightUnwhitelisted.Text = "Подсвечивать процессы не из вайтлиста";
            this.chbHighlightUnwhitelisted.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(759, 358);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 465);
            this.tabControl1.TabIndex = 0;
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
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(170, 465);
            this.listBox1.TabIndex = 6;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(954, 465);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 7;
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.TextBox tbMemLoad;
        private System.Windows.Forms.TextBox tbCpuLoad;
        private System.Windows.Forms.TextBox tbBinPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkParentProc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelProcName;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbSortBy;
        private System.Windows.Forms.CheckBox chbShowSysProc;
        private System.Windows.Forms.CheckBox chbHighlightUnwhitelisted;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox graphicGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCurMachine;
        private System.Windows.Forms.TextBox tbLastReportTime;
        private System.Windows.Forms.Label label3;
    }
}

