namespace TaskSpyAdminPanel
{
    partial class ProcessTab
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
            this.lbProcessName = new System.Windows.Forms.Label();
            this.chbWhitelisted = new System.Windows.Forms.CheckBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(499, 237);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "До:";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerTo.Location = new System.Drawing.Point(530, 236);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(130, 20);
            this.dateTimePickerTo.TabIndex = 27;
            // 
            // graphicGroupBox
            // 
            this.graphicGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphicGroupBox.Location = new System.Drawing.Point(53, 262);
            this.graphicGroupBox.Name = "graphicGroupBox";
            this.graphicGroupBox.Size = new System.Drawing.Size(607, 293);
            this.graphicGroupBox.TabIndex = 25;
            this.graphicGroupBox.TabStop = false;
            this.graphicGroupBox.Text = "График работы";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(363, 236);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(130, 20);
            this.dateTimePickerFrom.TabIndex = 26;
            this.dateTimePickerFrom.Value = new System.DateTime(2020, 1, 25, 13, 50, 0, 0);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(334, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "От:";
            // 
            // tbMemLoad
            // 
            this.tbMemLoad.Location = new System.Drawing.Point(223, 167);
            this.tbMemLoad.Name = "tbMemLoad";
            this.tbMemLoad.ReadOnly = true;
            this.tbMemLoad.Size = new System.Drawing.Size(186, 20);
            this.tbMemLoad.TabIndex = 24;
            this.tbMemLoad.Text = "108 261 Kb";
            // 
            // tbCpuLoad
            // 
            this.tbCpuLoad.Location = new System.Drawing.Point(223, 132);
            this.tbCpuLoad.Name = "tbCpuLoad";
            this.tbCpuLoad.ReadOnly = true;
            this.tbCpuLoad.Size = new System.Drawing.Size(186, 20);
            this.tbCpuLoad.TabIndex = 22;
            this.tbCpuLoad.Text = "14.7%";
            // 
            // tbBinPath
            // 
            this.tbBinPath.Location = new System.Drawing.Point(223, 96);
            this.tbBinPath.Name = "tbBinPath";
            this.tbBinPath.ReadOnly = true;
            this.tbBinPath.Size = new System.Drawing.Size(186, 20);
            this.tbBinPath.TabIndex = 21;
            this.tbBinPath.Text = "C:\\Program Files (x86)\\Google\\Chrome\\Application";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Память:";
            // 
            // linkParentProc
            // 
            this.linkParentProc.AutoSize = true;
            this.linkParentProc.Location = new System.Drawing.Point(223, 197);
            this.linkParentProc.Name = "linkParentProc";
            this.linkParentProc.Size = new System.Drawing.Size(42, 13);
            this.linkParentProc.TabIndex = 20;
            this.linkParentProc.TabStop = true;
            this.linkParentProc.Text = "chrome";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Родительский процесс:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Нагрзка CPU:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Путь:";
            // 
            // labelProcName
            // 
            this.labelProcName.AutoSize = true;
            this.labelProcName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProcName.Location = new System.Drawing.Point(81, -33);
            this.labelProcName.Name = "labelProcName";
            this.labelProcName.Size = new System.Drawing.Size(104, 31);
            this.labelProcName.TabIndex = 16;
            this.labelProcName.Text = "chrome";
            // 
            // lbProcessName
            // 
            this.lbProcessName.AutoSize = true;
            this.lbProcessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbProcessName.Location = new System.Drawing.Point(53, 27);
            this.lbProcessName.Name = "lbProcessName";
            this.lbProcessName.Size = new System.Drawing.Size(194, 25);
            this.lbProcessName.TabIndex = 30;
            this.lbProcessName.Text = "process_name.exe";
            // 
            // chbWhitelisted
            // 
            this.chbWhitelisted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbWhitelisted.AutoSize = true;
            this.chbWhitelisted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbWhitelisted.Location = new System.Drawing.Point(620, 33);
            this.chbWhitelisted.Name = "chbWhitelisted";
            this.chbWhitelisted.Size = new System.Drawing.Size(99, 19);
            this.chbWhitelisted.TabIndex = 31;
            this.chbWhitelisted.Text = "В вайтлисте";
            this.chbWhitelisted.UseVisualStyleBackColor = true;
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 5000;
            // 
            // ProcessTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.chbWhitelisted);
            this.Controls.Add(this.lbProcessName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.graphicGroupBox);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbMemLoad);
            this.Controls.Add(this.tbCpuLoad);
            this.Controls.Add(this.tbBinPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.linkParentProc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelProcName);
            this.Name = "ProcessTab";
            this.Size = new System.Drawing.Size(738, 439);
            this.Load += new System.EventHandler(this.ProcessTab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.GroupBox graphicGroupBox;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbMemLoad;
        private System.Windows.Forms.TextBox tbCpuLoad;
        private System.Windows.Forms.TextBox tbBinPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkParentProc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelProcName;
        private System.Windows.Forms.Label lbProcessName;
        private System.Windows.Forms.CheckBox chbWhitelisted;
        private System.Windows.Forms.Timer updateTimer;
    }
}
