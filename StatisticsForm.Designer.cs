namespace WeatherStation2023
{
    partial class StatisticsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            this.maxH_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.minH_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.minT_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.maxT_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statisticsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lastEntryLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.minTempLabel = new System.Windows.Forms.Label();
            this.minTempSensorLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.maxTempLabel = new System.Windows.Forms.Label();
            this.maxTempSensorLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.minHumidityLabel = new System.Windows.Forms.Label();
            this.minHumiditySensorLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.totalEntriesLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.firstEntryLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.maxHumidityLabel = new System.Windows.Forms.Label();
            this.maxHumiditySensorLabel = new System.Windows.Forms.Label();
            this.topToolStrip = new System.Windows.Forms.ToolStrip();
            this.exitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statisticsTableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            this.topToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // maxH_backgroundWorker
            // 
            this.maxH_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.maxH_backgroundWorker_DoWork);
            this.maxH_backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.maxH_backgroundWorker_RunWorkerCompleted);
            // 
            // minH_backgroundWorker
            // 
            this.minH_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.minH_backgroundWorker_DoWork);
            this.minH_backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.minH_backgroundWorker_RunWorkerCompleted);
            // 
            // minT_backgroundWorker
            // 
            this.minT_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.minT_backgroundWorker_DoWork);
            this.minT_backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.minT_backgroundWorker_RunWorkerCompleted);
            // 
            // maxT_backgroundWorker
            // 
            this.maxT_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.maxT_backgroundWorker_DoWork);
            this.maxT_backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.maxT_backgroundWorker_RunWorkerCompleted);
            // 
            // statBackgroundWorker
            // 
            this.statBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.statBackgroundWorker_DoWork);
            this.statBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.statBackgroundWorker_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(456, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.statisticsTableLayoutPanel);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(456, 213);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(456, 252);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.topToolStrip);
            // 
            // statisticsTableLayoutPanel
            // 
            this.statisticsTableLayoutPanel.ColumnCount = 2;
            this.statisticsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.statisticsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.statisticsTableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.statisticsTableLayoutPanel.Controls.Add(this.flowLayoutPanel2, 1, 3);
            this.statisticsTableLayoutPanel.Controls.Add(this.flowLayoutPanel3, 1, 4);
            this.statisticsTableLayoutPanel.Controls.Add(this.flowLayoutPanel4, 1, 5);
            this.statisticsTableLayoutPanel.Controls.Add(this.flowLayoutPanel6, 1, 0);
            this.statisticsTableLayoutPanel.Controls.Add(this.flowLayoutPanel7, 1, 1);
            this.statisticsTableLayoutPanel.Controls.Add(this.label7, 0, 6);
            this.statisticsTableLayoutPanel.Controls.Add(this.label6, 0, 5);
            this.statisticsTableLayoutPanel.Controls.Add(this.label5, 0, 4);
            this.statisticsTableLayoutPanel.Controls.Add(this.label4, 0, 3);
            this.statisticsTableLayoutPanel.Controls.Add(this.label3, 0, 2);
            this.statisticsTableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.statisticsTableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.statisticsTableLayoutPanel.Controls.Add(this.flowLayoutPanel8, 1, 6);
            this.statisticsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statisticsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.statisticsTableLayoutPanel.Name = "statisticsTableLayoutPanel";
            this.statisticsTableLayoutPanel.RowCount = 8;
            this.statisticsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.statisticsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.statisticsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.statisticsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.statisticsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.statisticsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.statisticsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.statisticsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.statisticsTableLayoutPanel.Size = new System.Drawing.Size(456, 213);
            this.statisticsTableLayoutPanel.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lastEntryLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(113, 63);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(340, 24);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // lastEntryLabel
            // 
            this.lastEntryLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lastEntryLabel.AutoSize = true;
            this.lastEntryLabel.Location = new System.Drawing.Point(3, 0);
            this.lastEntryLabel.Name = "lastEntryLabel";
            this.lastEntryLabel.Size = new System.Drawing.Size(0, 13);
            this.lastEntryLabel.TabIndex = 9;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.minTempLabel);
            this.flowLayoutPanel2.Controls.Add(this.minTempSensorLabel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(113, 93);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(340, 24);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // minTempLabel
            // 
            this.minTempLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.minTempLabel.AutoSize = true;
            this.minTempLabel.Location = new System.Drawing.Point(3, 0);
            this.minTempLabel.Name = "minTempLabel";
            this.minTempLabel.Size = new System.Drawing.Size(0, 13);
            this.minTempLabel.TabIndex = 10;
            // 
            // minTempSensorLabel
            // 
            this.minTempSensorLabel.AutoSize = true;
            this.minTempSensorLabel.Location = new System.Drawing.Point(9, 0);
            this.minTempSensorLabel.Name = "minTempSensorLabel";
            this.minTempSensorLabel.Size = new System.Drawing.Size(0, 13);
            this.minTempSensorLabel.TabIndex = 11;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.maxTempLabel);
            this.flowLayoutPanel3.Controls.Add(this.maxTempSensorLabel);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(113, 123);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(340, 24);
            this.flowLayoutPanel3.TabIndex = 14;
            // 
            // maxTempLabel
            // 
            this.maxTempLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maxTempLabel.AutoSize = true;
            this.maxTempLabel.Location = new System.Drawing.Point(3, 0);
            this.maxTempLabel.Name = "maxTempLabel";
            this.maxTempLabel.Size = new System.Drawing.Size(0, 13);
            this.maxTempLabel.TabIndex = 11;
            // 
            // maxTempSensorLabel
            // 
            this.maxTempSensorLabel.AutoSize = true;
            this.maxTempSensorLabel.Location = new System.Drawing.Point(9, 0);
            this.maxTempSensorLabel.Name = "maxTempSensorLabel";
            this.maxTempSensorLabel.Size = new System.Drawing.Size(0, 13);
            this.maxTempSensorLabel.TabIndex = 12;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.minHumidityLabel);
            this.flowLayoutPanel4.Controls.Add(this.minHumiditySensorLabel);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(113, 153);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(340, 24);
            this.flowLayoutPanel4.TabIndex = 15;
            // 
            // minHumidityLabel
            // 
            this.minHumidityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.minHumidityLabel.AutoSize = true;
            this.minHumidityLabel.Location = new System.Drawing.Point(3, 0);
            this.minHumidityLabel.Name = "minHumidityLabel";
            this.minHumidityLabel.Size = new System.Drawing.Size(0, 13);
            this.minHumidityLabel.TabIndex = 0;
            // 
            // minHumiditySensorLabel
            // 
            this.minHumiditySensorLabel.AutoSize = true;
            this.minHumiditySensorLabel.Location = new System.Drawing.Point(9, 0);
            this.minHumiditySensorLabel.Name = "minHumiditySensorLabel";
            this.minHumiditySensorLabel.Size = new System.Drawing.Size(0, 13);
            this.minHumiditySensorLabel.TabIndex = 1;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.totalEntriesLabel);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(113, 3);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(340, 24);
            this.flowLayoutPanel6.TabIndex = 17;
            // 
            // totalEntriesLabel
            // 
            this.totalEntriesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.totalEntriesLabel.AutoSize = true;
            this.totalEntriesLabel.Location = new System.Drawing.Point(3, 0);
            this.totalEntriesLabel.Name = "totalEntriesLabel";
            this.totalEntriesLabel.Size = new System.Drawing.Size(0, 13);
            this.totalEntriesLabel.TabIndex = 7;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.firstEntryLabel);
            this.flowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(113, 33);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(340, 24);
            this.flowLayoutPanel7.TabIndex = 18;
            // 
            // firstEntryLabel
            // 
            this.firstEntryLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.firstEntryLabel.AutoSize = true;
            this.firstEntryLabel.Location = new System.Drawing.Point(3, 0);
            this.firstEntryLabel.Name = "firstEntryLabel";
            this.firstEntryLabel.Size = new System.Drawing.Size(0, 13);
            this.firstEntryLabel.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Max humidity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Min humidity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Max temperature";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Min temperature";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last entry";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "First entry";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database entries";
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Controls.Add(this.maxHumidityLabel);
            this.flowLayoutPanel8.Controls.Add(this.maxHumiditySensorLabel);
            this.flowLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel8.Location = new System.Drawing.Point(113, 183);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(340, 24);
            this.flowLayoutPanel8.TabIndex = 19;
            // 
            // maxHumidityLabel
            // 
            this.maxHumidityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maxHumidityLabel.AutoSize = true;
            this.maxHumidityLabel.Location = new System.Drawing.Point(3, 0);
            this.maxHumidityLabel.Name = "maxHumidityLabel";
            this.maxHumidityLabel.Size = new System.Drawing.Size(0, 13);
            this.maxHumidityLabel.TabIndex = 0;
            // 
            // maxHumiditySensorLabel
            // 
            this.maxHumiditySensorLabel.AutoSize = true;
            this.maxHumiditySensorLabel.Location = new System.Drawing.Point(9, 0);
            this.maxHumiditySensorLabel.Name = "maxHumiditySensorLabel";
            this.maxHumiditySensorLabel.Size = new System.Drawing.Size(0, 13);
            this.maxHumiditySensorLabel.TabIndex = 1;
            // 
            // topToolStrip
            // 
            this.topToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.topToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.topToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripButton});
            this.topToolStrip.Location = new System.Drawing.Point(3, 0);
            this.topToolStrip.Name = "topToolStrip";
            this.topToolStrip.Size = new System.Drawing.Size(48, 39);
            this.topToolStrip.TabIndex = 0;
            // 
            // exitToolStripButton
            // 
            this.exitToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripButton.Image")));
            this.exitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitToolStripButton.Name = "exitToolStripButton";
            this.exitToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.exitToolStripButton.Text = "Exit";
            this.exitToolStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // statTimer
            // 
            this.statTimer.Enabled = true;
            this.statTimer.Interval = 51000;
            this.statTimer.Tick += new System.EventHandler(this.statTimer_Tick);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 276);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "StatisticsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Statistics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatisticsForm_FormClosing);
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statisticsTableLayoutPanel.ResumeLayout(false);
            this.statisticsTableLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel8.PerformLayout();
            this.topToolStrip.ResumeLayout(false);
            this.topToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker maxH_backgroundWorker;
        private System.ComponentModel.BackgroundWorker minH_backgroundWorker;
        private System.ComponentModel.BackgroundWorker minT_backgroundWorker;
        private System.ComponentModel.BackgroundWorker maxT_backgroundWorker;
        private System.ComponentModel.BackgroundWorker statBackgroundWorker;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip topToolStrip;
        private System.Windows.Forms.ToolStripButton exitToolStripButton;
        private System.Windows.Forms.TableLayoutPanel statisticsTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lastEntryLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label minTempLabel;
        private System.Windows.Forms.Label minTempSensorLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label maxTempLabel;
        private System.Windows.Forms.Label maxTempSensorLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label minHumidityLabel;
        private System.Windows.Forms.Label minHumiditySensorLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label totalEntriesLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label firstEntryLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.Label maxHumidityLabel;
        private System.Windows.Forms.Label maxHumiditySensorLabel;
        private System.Windows.Forms.Timer statTimer;
    }
}