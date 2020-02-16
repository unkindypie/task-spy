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
            this.graphicGroupBox = new System.Windows.Forms.GroupBox();
            this.graphicScroll = new System.Windows.Forms.HScrollBar();
            this.tbMemLoad = new System.Windows.Forms.TextBox();
            this.tbCpuLoad = new System.Windows.Forms.TextBox();
            this.tbBinPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.linkParentProc = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelProcName = new System.Windows.Forms.Label();
            this.lbProcessName = new System.Windows.Forms.Label();
            this.chbWhitelisted = new System.Windows.Forms.CheckBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tbPid = new System.Windows.Forms.TextBox();
            this.chbIsSytem = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbMax = new System.Windows.Forms.Label();
            this.lbMin = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // graphicGroupBox
            // 
            this.graphicGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphicGroupBox.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.graphicGroupBox.Location = new System.Drawing.Point(70, 348);
            this.graphicGroupBox.Name = "graphicGroupBox";
            this.graphicGroupBox.Size = new System.Drawing.Size(521, 294);
            this.graphicGroupBox.TabIndex = 25;
            this.graphicGroupBox.TabStop = false;
            this.toolTip1.SetToolTip(this.graphicGroupBox, "График работы процессора. Значение - загрузка процесса,  в левом верхнем углу мак" +
        "симальное значение, нижнем - минимальное.");
            this.graphicGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicGroupBox_Paint);
            // 
            // graphicScroll
            // 
            this.graphicScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphicScroll.Enabled = false;
            this.graphicScroll.Location = new System.Drawing.Point(70, 338);
            this.graphicScroll.Name = "graphicScroll";
            this.graphicScroll.Size = new System.Drawing.Size(521, 17);
            this.graphicScroll.TabIndex = 0;
            this.graphicScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.graphicScroll_Scroll);
            // 
            // tbMemLoad
            // 
            this.tbMemLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tbMemLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMemLoad.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMemLoad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tbMemLoad.Location = new System.Drawing.Point(265, 167);
            this.tbMemLoad.Name = "tbMemLoad";
            this.tbMemLoad.ReadOnly = true;
            this.tbMemLoad.Size = new System.Drawing.Size(122, 21);
            this.tbMemLoad.TabIndex = 24;
            this.tbMemLoad.Text = "108 261 Kb";
            // 
            // tbCpuLoad
            // 
            this.tbCpuLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tbCpuLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCpuLoad.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCpuLoad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tbCpuLoad.Location = new System.Drawing.Point(265, 132);
            this.tbCpuLoad.Name = "tbCpuLoad";
            this.tbCpuLoad.ReadOnly = true;
            this.tbCpuLoad.Size = new System.Drawing.Size(122, 21);
            this.tbCpuLoad.TabIndex = 22;
            this.tbCpuLoad.Text = "14.7%";
            // 
            // tbBinPath
            // 
            this.tbBinPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tbBinPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBinPath.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBinPath.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tbBinPath.Location = new System.Drawing.Point(265, 99);
            this.tbBinPath.Name = "tbBinPath";
            this.tbBinPath.ReadOnly = true;
            this.tbBinPath.Size = new System.Drawing.Size(272, 21);
            this.tbBinPath.TabIndex = 21;
            this.tbBinPath.Text = "C:\\Program Files (x86)\\Google\\Chrome\\Application";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(84, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 14);
            this.label8.TabIndex = 23;
            this.label8.Text = "Память:";
            // 
            // linkParentProc
            // 
            this.linkParentProc.AutoSize = true;
            this.linkParentProc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkParentProc.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.linkParentProc.Enabled = false;
            this.linkParentProc.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkParentProc.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkParentProc.Location = new System.Drawing.Point(396, 204);
            this.linkParentProc.Name = "linkParentProc";
            this.linkParentProc.Size = new System.Drawing.Size(159, 14);
            this.linkParentProc.TabIndex = 20;
            this.linkParentProc.TabStop = true;
            this.linkParentProc.Text = "К материнскому процессу";
            this.linkParentProc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkParentProc_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(84, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "Нагрзка CPU:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(84, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 14);
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
            this.lbProcessName.Font = new System.Drawing.Font("HelveticaNeueCyr", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbProcessName.Location = new System.Drawing.Point(53, 27);
            this.lbProcessName.Name = "lbProcessName";
            this.lbProcessName.Size = new System.Drawing.Size(193, 23);
            this.lbProcessName.TabIndex = 30;
            this.lbProcessName.Text = "process_name.exe";
            this.toolTip1.SetToolTip(this.lbProcessName, "Имя процесса");
            // 
            // chbWhitelisted
            // 
            this.chbWhitelisted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbWhitelisted.AutoSize = true;
            this.chbWhitelisted.Enabled = false;
            this.chbWhitelisted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbWhitelisted.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbWhitelisted.Location = new System.Drawing.Point(527, 32);
            this.chbWhitelisted.Name = "chbWhitelisted";
            this.chbWhitelisted.Size = new System.Drawing.Size(95, 18);
            this.chbWhitelisted.TabIndex = 31;
            this.chbWhitelisted.Text = "В вайтлисте";
            this.chbWhitelisted.UseVisualStyleBackColor = true;
            this.chbWhitelisted.CheckedChanged += new System.EventHandler(this.chbWhitelisted_CheckedChanged);
            this.chbWhitelisted.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chbWhitelisted_MouseUp);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 5000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(84, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 14);
            this.label1.TabIndex = 32;
            this.label1.Text = "PID:";
            // 
            // tbPid
            // 
            this.tbPid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tbPid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPid.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPid.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tbPid.Location = new System.Drawing.Point(265, 201);
            this.tbPid.Name = "tbPid";
            this.tbPid.ReadOnly = true;
            this.tbPid.Size = new System.Drawing.Size(122, 21);
            this.tbPid.TabIndex = 33;
            // 
            // chbIsSytem
            // 
            this.chbIsSytem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbIsSytem.AutoCheck = false;
            this.chbIsSytem.AutoSize = true;
            this.chbIsSytem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbIsSytem.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbIsSytem.Location = new System.Drawing.Point(527, 67);
            this.chbIsSytem.Name = "chbIsSytem";
            this.chbIsSytem.Size = new System.Drawing.Size(90, 18);
            this.chbIsSytem.TabIndex = 34;
            this.chbIsSytem.Text = "Системный";
            this.chbIsSytem.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(84, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 14);
            this.label2.TabIndex = 35;
            this.label2.Text = "Имя пользователя процесса:";
            // 
            // tbUser
            // 
            this.tbUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tbUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUser.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbUser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tbUser.Location = new System.Drawing.Point(265, 240);
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(122, 21);
            this.tbUser.TabIndex = 36;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // lbMax
            // 
            this.lbMax.AutoSize = true;
            this.lbMax.Font = new System.Drawing.Font("HelveticaNeueCyr", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMax.Location = new System.Drawing.Point(10, 357);
            this.lbMax.Name = "lbMax";
            this.lbMax.Size = new System.Drawing.Size(0, 14);
            this.lbMax.TabIndex = 37;
            this.lbMax.Visible = false;
            // 
            // lbMin
            // 
            this.lbMin.AutoSize = true;
            this.lbMin.Font = new System.Drawing.Font("HelveticaNeueCyr", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMin.Location = new System.Drawing.Point(10, 608);
            this.lbMin.Name = "lbMin";
            this.lbMin.Size = new System.Drawing.Size(0, 14);
            this.lbMin.TabIndex = 38;
            this.lbMin.Visible = false;
            // 
            // ProcessTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.lbMin);
            this.Controls.Add(this.lbMax);
            this.Controls.Add(this.graphicScroll);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbIsSytem);
            this.Controls.Add(this.tbPid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbWhitelisted);
            this.Controls.Add(this.lbProcessName);
            this.Controls.Add(this.graphicGroupBox);
            this.Controls.Add(this.tbMemLoad);
            this.Controls.Add(this.tbCpuLoad);
            this.Controls.Add(this.tbBinPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.linkParentProc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelProcName);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MinimumSize = new System.Drawing.Size(832, 503);
            this.Name = "ProcessTab";
            this.Size = new System.Drawing.Size(815, 503);
            this.Load += new System.EventHandler(this.ProcessTab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox graphicGroupBox;
        private System.Windows.Forms.TextBox tbMemLoad;
        private System.Windows.Forms.TextBox tbCpuLoad;
        private System.Windows.Forms.TextBox tbBinPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkParentProc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelProcName;
        private System.Windows.Forms.Label lbProcessName;
        private System.Windows.Forms.CheckBox chbWhitelisted;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPid;
        private System.Windows.Forms.CheckBox chbIsSytem;
        private System.Windows.Forms.HScrollBar graphicScroll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUser;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lbMax;
        private System.Windows.Forms.Label lbMin;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
