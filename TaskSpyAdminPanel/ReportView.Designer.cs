namespace TaskSpyAdminPanel
{
    partial class ReportView
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
            this.tbCreated = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lProcesses = new System.Windows.Forms.Label();
            this.lCpu = new System.Windows.Forms.Label();
            this.lMem = new System.Windows.Forms.Label();
            this.lIp = new System.Windows.Forms.Label();
            this.chbInWhitelist = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbCreated
            // 
            this.tbCreated.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbCreated.Location = new System.Drawing.Point(5, 5);
            this.tbCreated.Name = "tbCreated";
            this.tbCreated.ReadOnly = true;
            this.tbCreated.Size = new System.Drawing.Size(167, 20);
            this.tbCreated.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lProcesses
            // 
            this.lProcesses.AutoSize = true;
            this.lProcesses.Dock = System.Windows.Forms.DockStyle.Top;
            this.lProcesses.Location = new System.Drawing.Point(5, 25);
            this.lProcesses.Margin = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.lProcesses.Name = "lProcesses";
            this.lProcesses.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.lProcesses.Size = new System.Drawing.Size(86, 53);
            this.lProcesses.TabIndex = 4;
            this.lProcesses.Text = "Процессов:";
            // 
            // lCpu
            // 
            this.lCpu.AutoSize = true;
            this.lCpu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lCpu.Location = new System.Drawing.Point(5, 78);
            this.lCpu.Margin = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.lCpu.Name = "lCpu";
            this.lCpu.Padding = new System.Windows.Forms.Padding(10);
            this.lCpu.Size = new System.Drawing.Size(52, 33);
            this.lCpu.TabIndex = 5;
            this.lCpu.Text = "CPU:";
            // 
            // lMem
            // 
            this.lMem.AutoSize = true;
            this.lMem.Dock = System.Windows.Forms.DockStyle.Top;
            this.lMem.Location = new System.Drawing.Point(5, 111);
            this.lMem.Margin = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.lMem.Name = "lMem";
            this.lMem.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.lMem.Size = new System.Drawing.Size(69, 43);
            this.lMem.TabIndex = 6;
            this.lMem.Text = "Память:";
            // 
            // lIp
            // 
            this.lIp.AutoSize = true;
            this.lIp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lIp.Location = new System.Drawing.Point(5, 150);
            this.lIp.Margin = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.lIp.Name = "lIp";
            this.lIp.Padding = new System.Windows.Forms.Padding(40, 5, 10, 10);
            this.lIp.Size = new System.Drawing.Size(132, 28);
            this.lIp.TabIndex = 7;
            this.lIp.Text = "121.121.45.544";
            // 
            // chbInWhitelist
            // 
            this.chbInWhitelist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbInWhitelist.AutoSize = true;
            this.chbInWhitelist.Location = new System.Drawing.Point(81, 31);
            this.chbInWhitelist.Name = "chbInWhitelist";
            this.chbInWhitelist.Size = new System.Drawing.Size(88, 17);
            this.chbInWhitelist.TabIndex = 8;
            this.chbInWhitelist.Text = "В вайтлисте";
            this.chbInWhitelist.UseVisualStyleBackColor = true;
            this.chbInWhitelist.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chbInWhitelist);
            this.Controls.Add(this.lIp);
            this.Controls.Add(this.lMem);
            this.Controls.Add(this.lCpu);
            this.Controls.Add(this.lProcesses);
            this.Controls.Add(this.tbCreated);
            this.Name = "ReportView";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(177, 183);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCreated;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lProcesses;
        private System.Windows.Forms.Label lCpu;
        private System.Windows.Forms.Label lMem;
        private System.Windows.Forms.Label lIp;
        private System.Windows.Forms.CheckBox chbInWhitelist;
    }
}
