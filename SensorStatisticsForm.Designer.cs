﻿namespace WeatherStation2023
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.senorMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statToolStrip = new System.Windows.Forms.ToolStrip();
            this.exitTSB = new System.Windows.Forms.ToolStripButton();
            this.sensorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.filterComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
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
            this.senorMenuStrip.Size = new System.Drawing.Size(800, 24);
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statStatusStrip
            // 
            this.statStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.toolStripProgressBar1});
            this.statStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.statStatusStrip.Name = "statStatusStrip";
            this.statStatusStrip.Size = new System.Drawing.Size(800, 22);
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
            this.statToolStrip.Size = new System.Drawing.Size(800, 39);
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
            // sensorChart
            // 
            chartArea1.Name = "ChartArea1";
            this.sensorChart.ChartAreas.Add(chartArea1);
            this.sensorChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.sensorChart.Legends.Add(legend1);
            this.sensorChart.Location = new System.Drawing.Point(0, 63);
            this.sensorChart.Name = "sensorChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.LegendText = "Humidity [%]";
            series1.Name = "humidity";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.LegendText = "Temperature [°C]";
            series2.Name = "temperature";
            this.sensorChart.Series.Add(series1);
            this.sensorChart.Series.Add(series2);
            this.sensorChart.Size = new System.Drawing.Size(800, 365);
            this.sensorChart.TabIndex = 3;
            this.sensorChart.Text = "chart1";
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
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
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
            this.ClientSize = new System.Drawing.Size(800, 450);
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
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox filterComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart sensorChart;
        private System.ComponentModel.BackgroundWorker sensorWorker;
        private System.Windows.Forms.Timer sensorTimer;
    }
}