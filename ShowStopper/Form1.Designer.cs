namespace ShowStopper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.entriesBtn = new System.Windows.Forms.Button();
            this.colorsBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.buttonFlp = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.stopLbl = new System.Windows.Forms.Label();
            this.startLbl = new System.Windows.Forms.Label();
            this.displayLbl = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(884, 507);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer2.Panel1.Controls.Add(this.entriesBtn);
            this.splitContainer2.Panel1.Controls.Add(this.colorsBtn);
            this.splitContainer2.Panel1.Controls.Add(this.saveBtn);
            this.splitContainer2.Panel1.Controls.Add(this.quitBtn);
            this.splitContainer2.Panel1.Controls.Add(this.resetBtn);
            this.splitContainer2.Panel1.Controls.Add(this.stopBtn);
            this.splitContainer2.Panel1.Controls.Add(this.startBtn);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer2.Panel2.Controls.Add(this.buttonFlp);
            this.splitContainer2.Size = new System.Drawing.Size(217, 507);
            this.splitContainer2.SplitterDistance = 101;
            this.splitContainer2.TabIndex = 0;
            // 
            // entriesBtn
            // 
            this.entriesBtn.Location = new System.Drawing.Point(104, 37);
            this.entriesBtn.Name = "entriesBtn";
            this.entriesBtn.Size = new System.Drawing.Size(52, 28);
            this.entriesBtn.TabIndex = 6;
            this.entriesBtn.Text = "Entries";
            this.entriesBtn.UseVisualStyleBackColor = true;
            this.entriesBtn.Click += new System.EventHandler(this.entriesBtn_Click);
            // 
            // colorsBtn
            // 
            this.colorsBtn.Location = new System.Drawing.Point(104, 68);
            this.colorsBtn.Name = "colorsBtn";
            this.colorsBtn.Size = new System.Drawing.Size(52, 28);
            this.colorsBtn.TabIndex = 5;
            this.colorsBtn.Text = "Colors";
            this.colorsBtn.UseVisualStyleBackColor = true;
            this.colorsBtn.Click += new System.EventHandler(this.colorsBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(162, 37);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(52, 28);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.Location = new System.Drawing.Point(162, 68);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(52, 28);
            this.quitBtn.TabIndex = 3;
            this.quitBtn.Text = "Quit";
            this.quitBtn.UseVisualStyleBackColor = true;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(3, 68);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(52, 28);
            this.resetBtn.TabIndex = 2;
            this.resetBtn.Text = "RESET";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(3, 37);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(52, 28);
            this.stopBtn.TabIndex = 1;
            this.stopBtn.Text = "STOP";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(3, 3);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(52, 28);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "START";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // buttonFlp
            // 
            this.buttonFlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFlp.Location = new System.Drawing.Point(0, 0);
            this.buttonFlp.Name = "buttonFlp";
            this.buttonFlp.Size = new System.Drawing.Size(217, 402);
            this.buttonFlp.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer3.Panel1.Controls.Add(this.stopLbl);
            this.splitContainer3.Panel1.Controls.Add(this.startLbl);
            this.splitContainer3.Panel1.Controls.Add(this.displayLbl);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer3.Size = new System.Drawing.Size(663, 507);
            this.splitContainer3.SplitterDistance = 100;
            this.splitContainer3.TabIndex = 0;
            // 
            // stopLbl
            // 
            this.stopLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stopLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.stopLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopLbl.Location = new System.Drawing.Point(494, 23);
            this.stopLbl.Name = "stopLbl";
            this.stopLbl.Size = new System.Drawing.Size(148, 39);
            this.stopLbl.TabIndex = 2;
            this.stopLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startLbl
            // 
            this.startLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.startLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.startLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLbl.Location = new System.Drawing.Point(28, 23);
            this.startLbl.Name = "startLbl";
            this.startLbl.Size = new System.Drawing.Size(148, 39);
            this.startLbl.TabIndex = 1;
            this.startLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // displayLbl
            // 
            this.displayLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.displayLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.displayLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayLbl.Location = new System.Drawing.Point(203, 23);
            this.displayLbl.Name = "displayLbl";
            this.displayLbl.Size = new System.Drawing.Size(253, 39);
            this.displayLbl.TabIndex = 0;
            this.displayLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.type,
            this.message});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(663, 403);
            this.dataGridView1.TabIndex = 0;
            // 
            // time
            // 
            this.time.HeaderText = "Time";
            this.time.MinimumWidth = 150;
            this.time.Name = "time";
            this.time.Width = 150;
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.MinimumWidth = 150;
            this.type.Name = "type";
            this.type.Width = 150;
            // 
            // message
            // 
            this.message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.message.HeaderText = "Message";
            this.message.Name = "message";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 507);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Show Stopper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label displayLbl;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Label stopLbl;
        private System.Windows.Forms.Label startLbl;
        private System.Windows.Forms.FlowLayoutPanel buttonFlp;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button colorsBtn;
        private System.Windows.Forms.Button entriesBtn;
    }
}

