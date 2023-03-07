namespace WeatherStation2023
{
    partial class SensorStatisticsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorStatisticsForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.senorMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statToolStrip = new System.Windows.Forms.ToolStrip();
            this.exitTSB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.filterComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.sensorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sensorWorker = new System.ComponentModel.BackgroundWorker();
            this.sensorTimer = new System.Windows.Forms.Timer(this.components);
            this.senorMenuStrip.SuspendLayout();
            this.statStatusStrip.SuspendLayout();
            this.statToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).BeginInit();
            this.SuspendLayout();
            // 
            // senorMenuStrip
            // 
            this.senorMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.senorMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.senorMenuStrip.Name = "senorMenuStrip";
            this.senorMenuStrip.Size = new System.Drawing.Size(670, 24);
            this.senorMenuStrip.TabIndex = 0;
            this.senorMenuStrip.Text = "menuStrip1";
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statStatusStrip
            // 
            this.statStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statStatusStrip.Location = new System.Drawing.Point(0, 511);
            this.statStatusStrip.Name = "statStatusStrip";
            this.statStatusStrip.Size = new System.Drawing.Size(670, 22);
            this.statStatusStrip.TabIndex = 1;
            this.statStatusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(66, 17);
            this.statusLabel.Text = "statusLabel";
            // 
            // statToolStrip
            // 
            this.statToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitTSB,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.filterComboBox});
            this.statToolStrip.Location = new System.Drawing.Point(0, 24);
            this.statToolStrip.Name = "statToolStrip";
            this.statToolStrip.Size = new System.Drawing.Size(670, 39);
            this.statToolStrip.TabIndex = 2;
            this.statToolStrip.Text = "toolStrip1";
            // 
            // exitTSB
            // 
            this.exitTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitTSB.Image = ((System.Drawing.Image)(resources.GetObject("exitTSB.Image")));
            this.exitTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitTSB.Name = "exitTSB";
            this.exitTSB.Size = new System.Drawing.Size(36, 36);
            this.exitTSB.Text = "Exit";
            this.exitTSB.Click += new System.EventHandler(this.exitTSB_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 36);
            this.toolStripLabel1.Text = "Filter";
            // 
            // filterComboBox
            // 
            this.filterComboBox.Items.AddRange(new object[] {
            "Today",
            "Month",
            "Year",
            "All data"});
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(121, 39);
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);
            // 
            // sensorChart
            // 
            chartArea2.AxisX.Title = "Time";
            chartArea2.AxisY.Title = "Value";
            chartArea2.Name = "ChartArea1";
            this.sensorChart.ChartAreas.Add(chartArea2);
            this.sensorChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.sensorChart.Legends.Add(legend2);
            this.sensorChart.Location = new System.Drawing.Point(0, 63);
            this.sensorChart.Name = "sensorChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Blue;
            series3.Legend = "Legend1";
            series3.LegendText = "Humidity [%]";
            series3.Name = "humidity";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.LegendText = "Temperature [°C]";
            series4.Name = "temperature";
            this.sensorChart.Series.Add(series3);
            this.sensorChart.Series.Add(series4);
            this.sensorChart.Size = new System.Drawing.Size(670, 448);
            this.sensorChart.TabIndex = 3;
            this.sensorChart.Text = "chart1";
            // 
            // sensorWorker
            // 
            this.sensorWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sensorWorker_DoWork);
            this.sensorWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.sensorWorker_ProgressChanged);
            this.sensorWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.sensorWorker_RunWorkerCompleted);
            // 
            // sensorTimer
            // 
            this.sensorTimer.Enabled = true;
            this.sensorTimer.Interval = 30000;
            this.sensorTimer.Tick += new System.EventHandler(this.sensorTimer_Tick);
            // 
            // SensorStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 533);
            this.Controls.Add(this.sensorChart);
            this.Controls.Add(this.statToolStrip);
            this.Controls.Add(this.statStatusStrip);
            this.Controls.Add(this.senorMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.senorMenuStrip;
            this.Name = "SensorStatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sensor Statistics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatForm_FormClosing);
            this.Load += new System.EventHandler(this.StatForm_Load);
            this.senorMenuStrip.ResumeLayout(false);
            this.senorMenuStrip.PerformLayout();
            this.statStatusStrip.ResumeLayout(false);
            this.statStatusStrip.PerformLayout();
            this.statToolStrip.ResumeLayout(false);
            this.statToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip senorMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStrip statToolStrip;
        private System.Windows.Forms.ToolStripButton exitTSB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox filterComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart sensorChart;
        private System.ComponentModel.BackgroundWorker sensorWorker;
        private System.Windows.Forms.Timer sensorTimer;
    }
}