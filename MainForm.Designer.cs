namespace WeatherStation2023
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.connectionStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sensorStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sensorMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.showHelpIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.showErrorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.exitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statisticsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpTSB = new System.Windows.Forms.ToolStripButton();
            this.help_infoTSB = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.dbBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.mainStatusStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStatusLbl});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.mainStatusStrip.TabIndex = 0;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // connectionStatusLbl
            // 
            this.connectionStatusLbl.Name = "connectionStatusLbl";
            this.connectionStatusLbl.Size = new System.Drawing.Size(115, 17);
            this.connectionStatusLbl.Text = "connectionStatusLbl";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
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
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statisticsToolStripMenuItem,
            this.sensorStatisticsToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "&Data";
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("statisticsToolStripMenuItem.Image")));
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.statisticsToolStripMenuItem.Text = "S&tatistics";
            this.statisticsToolStripMenuItem.Click += new System.EventHandler(this.statisticsToolStripMenuItem_Click);
            // 
            // sensorStatisticsToolStripMenuItem
            // 
            this.sensorStatisticsToolStripMenuItem.Name = "sensorStatisticsToolStripMenuItem";
            this.sensorStatisticsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.sensorStatisticsToolStripMenuItem.Text = "S&ensor statistics";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseConnectionToolStripMenuItem,
            this.sensorMappingToolStripMenuItem,
            this.toolStripMenuItem1,
            this.showHelpIconsToolStripMenuItem,
            this.showToolbarToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showErrorsToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.setupToolStripMenuItem.Text = "&Setup";
            // 
            // databaseConnectionToolStripMenuItem
            // 
            this.databaseConnectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("databaseConnectionToolStripMenuItem.Image")));
            this.databaseConnectionToolStripMenuItem.Name = "databaseConnectionToolStripMenuItem";
            this.databaseConnectionToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.databaseConnectionToolStripMenuItem.Text = "&Database-Connection";
            this.databaseConnectionToolStripMenuItem.Click += new System.EventHandler(this.databaseConnectionToolStripMenuItem_Click);
            // 
            // sensorMappingToolStripMenuItem
            // 
            this.sensorMappingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sensorMappingToolStripMenuItem.Image")));
            this.sensorMappingToolStripMenuItem.Name = "sensorMappingToolStripMenuItem";
            this.sensorMappingToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.sensorMappingToolStripMenuItem.Text = "Sensor-&Mapping";
            this.sensorMappingToolStripMenuItem.Click += new System.EventHandler(this.sensorMappingToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 6);
            // 
            // showHelpIconsToolStripMenuItem
            // 
            this.showHelpIconsToolStripMenuItem.Checked = true;
            this.showHelpIconsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showHelpIconsToolStripMenuItem.Name = "showHelpIconsToolStripMenuItem";
            this.showHelpIconsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.showHelpIconsToolStripMenuItem.Text = "Show &Help icons";
            this.showHelpIconsToolStripMenuItem.Click += new System.EventHandler(this.showHelpIconsToolStripMenuItem_Click);
            // 
            // showToolbarToolStripMenuItem
            // 
            this.showToolbarToolStripMenuItem.Checked = true;
            this.showToolbarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showToolbarToolStripMenuItem.Name = "showToolbarToolStripMenuItem";
            this.showToolbarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.showToolbarToolStripMenuItem.Text = "Show &Toolbar";
            this.showToolbarToolStripMenuItem.Click += new System.EventHandler(this.showToolbarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(186, 6);
            // 
            // showErrorsToolStripMenuItem
            // 
            this.showErrorsToolStripMenuItem.Name = "showErrorsToolStripMenuItem";
            this.showErrorsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.showErrorsToolStripMenuItem.Text = "Show &Errors (Debug)";
            this.showErrorsToolStripMenuItem.Click += new System.EventHandler(this.showErrorsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.infoToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem1.Image")));
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("infoToolStripMenuItem.Image")));
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.infoToolStripMenuItem.Text = "&Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripButton,
            this.statisticsToolStripButton,
            this.helpToolStripSeparator,
            this.helpTSB,
            this.help_infoTSB});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(800, 39);
            this.mainToolStrip.TabIndex = 2;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // exitToolStripButton
            // 
            this.exitToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripButton.Image")));
            this.exitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitToolStripButton.Name = "exitToolStripButton";
            this.exitToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.exitToolStripButton.Text = "Exit";
            this.exitToolStripButton.Click += new System.EventHandler(this.exitToolStripButton_Click);
            // 
            // statisticsToolStripButton
            // 
            this.statisticsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.statisticsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("statisticsToolStripButton.Image")));
            this.statisticsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statisticsToolStripButton.Name = "statisticsToolStripButton";
            this.statisticsToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.statisticsToolStripButton.Text = "Statistics";
            this.statisticsToolStripButton.Click += new System.EventHandler(this.statisticsToolStripButton_Click);
            // 
            // helpToolStripSeparator
            // 
            this.helpToolStripSeparator.Name = "helpToolStripSeparator";
            this.helpToolStripSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // helpTSB
            // 
            this.helpTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpTSB.Image = ((System.Drawing.Image)(resources.GetObject("helpTSB.Image")));
            this.helpTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpTSB.Name = "helpTSB";
            this.helpTSB.Size = new System.Drawing.Size(36, 36);
            this.helpTSB.Text = "Help";
            this.helpTSB.Click += new System.EventHandler(this.helpTSB_Click);
            // 
            // help_infoTSB
            // 
            this.help_infoTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.help_infoTSB.Image = ((System.Drawing.Image)(resources.GetObject("help_infoTSB.Image")));
            this.help_infoTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.help_infoTSB.Name = "help_infoTSB";
            this.help_infoTSB.Size = new System.Drawing.Size(36, 36);
            this.help_infoTSB.Text = "Info";
            this.help_infoTSB.Click += new System.EventHandler(this.help_infoTSB_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 63);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(800, 365);
            this.flowLayoutPanel.TabIndex = 3;
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 60000;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // dbBackgroundWorker
            // 
            this.dbBackgroundWorker.WorkerReportsProgress = true;
            this.dbBackgroundWorker.WorkerSupportsCancellation = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Weather Station 2023";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatusLbl;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sensorMappingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton exitToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Timer mainTimer;
        private System.ComponentModel.BackgroundWorker dbBackgroundWorker;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showHelpIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton statisticsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator helpToolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpTSB;
        private System.Windows.Forms.ToolStripButton help_infoTSB;
        private System.Windows.Forms.ToolStripMenuItem showToolbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sensorStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showErrorsToolStripMenuItem;
    }
}

