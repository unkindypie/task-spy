namespace TaskSpyAdminPanel
{
    partial class ReportSelectorTab
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
            this.flpReports = new System.Windows.Forms.FlowLayoutPanel();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.сhbOnlyUnwhitelisted = new System.Windows.Forms.CheckBox();
            this.cbMachine = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpReports
            // 
            this.flpReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpReports.AutoScroll = true;
            this.flpReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.flpReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpReports.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flpReports.Location = new System.Drawing.Point(3, 60);
            this.flpReports.Name = "flpReports";
            this.flpReports.Size = new System.Drawing.Size(826, 440);
            this.flpReports.TabIndex = 0;
            this.flpReports.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flpReports_Scroll);
            this.flpReports.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flpReports_MouseClick);
            this.flpReports.Resize += new System.EventHandler(this.flpReports_Resize);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 5000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpFrom.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(39, 17);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(142, 21);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.CloseUp += new System.EventHandler(this.dtpFrom_CloseUp);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarForeColor = System.Drawing.SystemColors.ButtonFace;
            this.dtpTo.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dtpTo.CalendarTitleForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtpTo.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpTo.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(233, 17);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(142, 21);
            this.dtpTo.TabIndex = 2;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "От:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(201, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "До:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // сhbOnlyUnwhitelisted
            // 
            this.сhbOnlyUnwhitelisted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.сhbOnlyUnwhitelisted.AutoSize = true;
            this.сhbOnlyUnwhitelisted.Enabled = false;
            this.сhbOnlyUnwhitelisted.Location = new System.Drawing.Point(598, 36);
            this.сhbOnlyUnwhitelisted.Name = "сhbOnlyUnwhitelisted";
            this.сhbOnlyUnwhitelisted.Size = new System.Drawing.Size(218, 16);
            this.сhbOnlyUnwhitelisted.TabIndex = 5;
            this.сhbOnlyUnwhitelisted.Text = "Показывать только вневайтлистовые";
            this.сhbOnlyUnwhitelisted.UseVisualStyleBackColor = true;
            this.сhbOnlyUnwhitelisted.CheckedChanged += new System.EventHandler(this.сhbOnlyUnwhitelisted_CheckedChanged);
            this.сhbOnlyUnwhitelisted.Click += new System.EventHandler(this.сhbOnlyUnwhitelisted_Click);
            // 
            // cbMachine
            // 
            this.cbMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMachine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cbMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMachine.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbMachine.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbMachine.FormattingEnabled = true;
            this.cbMachine.Location = new System.Drawing.Point(659, 6);
            this.cbMachine.Name = "cbMachine";
            this.cbMachine.Size = new System.Drawing.Size(151, 22);
            this.cbMachine.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cbMachine, "Машина, с которой пришел отчет");
            this.cbMachine.SelectedIndexChanged += new System.EventHandler(this.cbMachine_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(594, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Машина:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(396, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReportSelectorTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.сhbOnlyUnwhitelisted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbMachine);
            this.Controls.Add(this.flpReports);
            this.Font = new System.Drawing.Font("HelveticaNeueCyr", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MinimumSize = new System.Drawing.Size(832, 503);
            this.Name = "ReportSelectorTab";
            this.Size = new System.Drawing.Size(832, 503);
            this.SizeChanged += new System.EventHandler(this.ReportSelectorTab_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpReports;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox сhbOnlyUnwhitelisted;
        private System.Windows.Forms.ComboBox cbMachine;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}
