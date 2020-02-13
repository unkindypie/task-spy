namespace TaskSpyAdminPanel
{
    partial class ProcessesTab
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbLastReportTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCurMachine = new System.Windows.Forms.ComboBox();
            this.chbShowSysProc = new System.Windows.Forms.CheckBox();
            this.chbHighlightUnwhitelisted = new System.Windows.Forms.CheckBox();
            this.processesGridView = new System.Windows.Forms.DataGridView();
            this.chbShowEveryUser = new System.Windows.Forms.CheckBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.lbProcessCount = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.открытьПроцессToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВыделенныеПроцессыВВайтлистToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВыделенныеПроцессыИзВайтлистаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.processesGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLastReportTime
            // 
            this.tbLastReportTime.Location = new System.Drawing.Point(296, 8);
            this.tbLastReportTime.Name = "tbLastReportTime";
            this.tbLastReportTime.ReadOnly = true;
            this.tbLastReportTime.Size = new System.Drawing.Size(113, 20);
            this.tbLastReportTime.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Время отчета:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Машина:";
            // 
            // cbCurMachine
            // 
            this.cbCurMachine.FormattingEnabled = true;
            this.cbCurMachine.Location = new System.Drawing.Point(64, 8);
            this.cbCurMachine.Name = "cbCurMachine";
            this.cbCurMachine.Size = new System.Drawing.Size(121, 21);
            this.cbCurMachine.TabIndex = 14;
            this.cbCurMachine.SelectedIndexChanged += new System.EventHandler(this.cbCurMachine_SelectedIndexChanged);
            // 
            // chbShowSysProc
            // 
            this.chbShowSysProc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbShowSysProc.AutoSize = true;
            this.chbShowSysProc.Location = new System.Drawing.Point(259, 412);
            this.chbShowSysProc.Name = "chbShowSysProc";
            this.chbShowSysProc.Size = new System.Drawing.Size(137, 17);
            this.chbShowSysProc.TabIndex = 11;
            this.chbShowSysProc.Text = "Системные процессы";
            this.chbShowSysProc.UseVisualStyleBackColor = true;
            this.chbShowSysProc.CheckedChanged += new System.EventHandler(this.chbShowSysProc_CheckedChanged);
            // 
            // chbHighlightUnwhitelisted
            // 
            this.chbHighlightUnwhitelisted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbHighlightUnwhitelisted.AutoSize = true;
            this.chbHighlightUnwhitelisted.Location = new System.Drawing.Point(17, 412);
            this.chbHighlightUnwhitelisted.Name = "chbHighlightUnwhitelisted";
            this.chbHighlightUnwhitelisted.Size = new System.Drawing.Size(236, 17);
            this.chbHighlightUnwhitelisted.TabIndex = 10;
            this.chbHighlightUnwhitelisted.Text = "Подсвечивать процессы не из вайтлиста";
            this.chbHighlightUnwhitelisted.UseVisualStyleBackColor = true;
            this.chbHighlightUnwhitelisted.CheckedChanged += new System.EventHandler(this.chbHighlightUnwhitelisted_CheckedChanged);
            // 
            // processesGridView
            // 
            this.processesGridView.AllowUserToAddRows = false;
            this.processesGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.processesGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.processesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.processesGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.processesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.processesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.processesGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.processesGridView.Location = new System.Drawing.Point(7, 39);
            this.processesGridView.Name = "processesGridView";
            this.processesGridView.ReadOnly = true;
            this.processesGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.processesGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.processesGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.processesGridView.Size = new System.Drawing.Size(759, 358);
            this.processesGridView.TabIndex = 9;
            this.processesGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.processesGridView_CellDoubleClick);
            this.processesGridView.Sorted += new System.EventHandler(this.processesGridView_Sorted);
            this.processesGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.processesGridView_MouseClick);
            // 
            // chbShowEveryUser
            // 
            this.chbShowEveryUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbShowEveryUser.AutoSize = true;
            this.chbShowEveryUser.Location = new System.Drawing.Point(412, 412);
            this.chbShowEveryUser.Name = "chbShowEveryUser";
            this.chbShowEveryUser.Size = new System.Drawing.Size(217, 17);
            this.chbShowEveryUser.TabIndex = 18;
            this.chbShowEveryUser.Text = "Процессы всех пользователей на ПК";
            this.chbShowEveryUser.UseVisualStyleBackColor = true;
            this.chbShowEveryUser.CheckedChanged += new System.EventHandler(this.chbShowEveryUser_CheckedChanged);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 5000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // lbProcessCount
            // 
            this.lbProcessCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProcessCount.AutoSize = true;
            this.lbProcessCount.Location = new System.Drawing.Point(675, 11);
            this.lbProcessCount.Name = "lbProcessCount";
            this.lbProcessCount.Size = new System.Drawing.Size(0, 13);
            this.lbProcessCount.TabIndex = 19;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьПроцессToolStripMenuItem,
            this.добавитьВыделенныеПроцессыВВайтлистToolStripMenuItem,
            this.удалитьВыделенныеПроцессыИзВайтлистаToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(322, 70);
            // 
            // открытьПроцессToolStripMenuItem
            // 
            this.открытьПроцессToolStripMenuItem.Name = "открытьПроцессToolStripMenuItem";
            this.открытьПроцессToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.открытьПроцессToolStripMenuItem.Text = "Открыть процесс";
            this.открытьПроцессToolStripMenuItem.Click += new System.EventHandler(this.открытьПроцессToolStripMenuItem_Click);
            // 
            // добавитьВыделенныеПроцессыВВайтлистToolStripMenuItem
            // 
            this.добавитьВыделенныеПроцессыВВайтлистToolStripMenuItem.Name = "добавитьВыделенныеПроцессыВВайтлистToolStripMenuItem";
            this.добавитьВыделенныеПроцессыВВайтлистToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.добавитьВыделенныеПроцессыВВайтлистToolStripMenuItem.Text = "Добавить выделенные процессы в вайтлист";
            // 
            // удалитьВыделенныеПроцессыИзВайтлистаToolStripMenuItem
            // 
            this.удалитьВыделенныеПроцессыИзВайтлистаToolStripMenuItem.Name = "удалитьВыделенныеПроцессыИзВайтлистаToolStripMenuItem";
            this.удалитьВыделенныеПроцессыИзВайтлистаToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.удалитьВыделенныеПроцессыИзВайтлистаToolStripMenuItem.Text = "Удалить выделенные процессы из вайтлиста";
            // 
            // ProcessesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.lbProcessCount);
            this.Controls.Add(this.chbShowEveryUser);
            this.Controls.Add(this.tbLastReportTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCurMachine);
            this.Controls.Add(this.chbShowSysProc);
            this.Controls.Add(this.chbHighlightUnwhitelisted);
            this.Controls.Add(this.processesGridView);
            this.Name = "ProcessesTab";
            this.Size = new System.Drawing.Size(772, 439);
            this.Load += new System.EventHandler(this.ProcessesTab_Load);
            this.Enter += new System.EventHandler(this.ProcessesTab_Enter);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.ProcessesTab_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.processesGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLastReportTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCurMachine;
        private System.Windows.Forms.CheckBox chbShowSysProc;
        private System.Windows.Forms.CheckBox chbHighlightUnwhitelisted;
        private System.Windows.Forms.DataGridView processesGridView;
        private System.Windows.Forms.CheckBox chbShowEveryUser;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label lbProcessCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьПроцессToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьВыделенныеПроцессыВВайтлистToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВыделенныеПроцессыИзВайтлистаToolStripMenuItem;
    }
}
