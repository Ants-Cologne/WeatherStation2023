using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WeatherStation2023
{
    public partial class MainForm : Form
    {
        #region Private class variables
        ConnectionSetupForm connectionSetupForm;
        InfoForm infoForm;
        SensorStatisticsForm sensorStatisticsForm;
        ColorValues colorForm;
        StatisticsForm statisticsForm;
        private static string config_file = "sensors.cfg";

        string[] sensors;
        List<Sensor> sensorList;
        List<String> sensorConfig;

        // Database variables.
        MySqlConnection conDataBase;
        string connectionString;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            sensorList = new List<Sensor>();
            sensorConfig= new List<String>();

            connectionStatusLbl.Text = "";

            initDatabase();

            init();
        }

        private void init()
        {
            checkCountSensorProp();

            loadSensorConfig();

            if (Properties.Settings.Default.ShowDebug)
            {
                showErrorsToolStripMenuItem.Checked = true;
            }

            if (sensorList.Count > 0)   // User settings are available.
            {
                loadUserSettings();

                runBackgroundWorkers();
            }
            else
            {
                connectionStatusLbl.Text = "Please run Setup->Database Connection to get a database connection...";
            }

            checkToolbar();
        }

        #region Application Settings: position, size and name
        //https://www.codeproject.com/Tips/543631/Save-and-restore-your-form-size-and-location
        /// <summary>
        /// Load Application Settings during startup. Hold "Shift"-key for applicaton default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) == 0)
            {
                string initLocation = Properties.Settings.Default.InitialLocation;
                Point il = new Point(0, 0);
                Size sz = Size;
                if (!string.IsNullOrWhiteSpace(initLocation))
                {
                    string[] parts = initLocation.Split(',');
                    if (parts.Length >= 2)
                    {
                        il = new Point(int.Parse(parts[0]), int.Parse(parts[1]));
                    }
                    if (parts.Length >= 4)
                    {
                        sz = new Size(int.Parse(parts[2]), int.Parse(parts[3]));
                    }
                }
                Size = sz;
                Location = il;
                this.Text = Properties.Settings.Default.ApplicationName;
            }
            // Load language from User settings.
            //changeLanguage();
        }

        /// <summary>
        /// Write Application settings on closing. Hold "Shift"-key to skip the saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) == 0)
            {
                Point location = Location;
                Size size = Size;
                if (WindowState != FormWindowState.Normal)
                {
                    location = RestoreBounds.Location;
                    size = RestoreBounds.Size;
                }
                string initLocation = string.Join(",", location.X, location.Y, size.Width, size.Height);
                Properties.Settings.Default.InitialLocation = initLocation;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
        }
        #endregion

        private void loadUserSettings()
        {
            List<String> listStrLineElements;
            string tmp_txt, species;

            for (int i = 0; i < sensorList.Count; i++)
            {
                Sensor s = sensorList[i];
                tmp_txt = s.PublicLabel;
                if (sensorConfig.Count > 0)
                {
                    listStrLineElements = sensorConfig[i].Split('\t').ToList();
                    // Get AliasLabel from config file
                    if (listStrLineElements[1] != "") tmp_txt = s.PublicLabel + " (" + listStrLineElements[1] + ")";
                    // Get species
                    species = getSpecies(listStrLineElements[2]);
                    if (species != "")
                    {
                        tmp_txt += " - Species: " + species;
                    }
                    // set temperature and humidity colors
                    setColors(listStrLineElements[2], s);
                }

                // Create the sensor groupbox.
                var customGroupBox = new SensorGroupBox
                {
                    Text = tmp_txt,
                    Width = flowLayoutPanel.Width - SystemInformation.VerticalScrollBarWidth,
                    Padding = new Padding(),
                    Margin = new Padding(),
                };
                s.TempLabel = customGroupBox.TemperatureLabel;
                s.HumidityLabel = customGroupBox.HumidityLabel;
                s.TimeLabel = customGroupBox.TimeStampLabel;

                flowLayoutPanel.Controls.Add(customGroupBox);

                // Add to toolstrip menu to show sensor charts
                addSensorToolStripMenuItem(s);
            }
            connectionStatusLbl.Text = $"{sensorList.Count} Sensors loaded from User Settings!";
        }
        private void addSensorToolStripMenuItem(Sensor sens)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(sens.PublicLabel, null, showSensorStatistics);
            sensorStatisticsToolStripMenuItem.DropDownItems.Add(menuItem);
        }

        private void showSensorStatistics(object sender, EventArgs e)
        {
            sensorStatisticsForm = new SensorStatisticsForm(sender.ToString());
            sensorStatisticsForm.MdiParent = this.ParentForm;
            sensorStatisticsForm.StartPosition = FormStartPosition.CenterParent;
            sensorStatisticsForm.Show();
        }

        //https://stackoverflow.com/questions/5951496/how-do-i-capture-keys-f1-regardless-of-the-focused-control-on-a-form
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                showHelpForm();
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void initDatabase()
        {
            connectionString = "server=" + Properties.Settings.Default.HostProp + "; " +
                    "port=" + Properties.Settings.Default.PortProp.ToString() + "; " +
                    "username='" + Properties.Settings.Default.UserProp + "'; " +
                    "password='" + Properties.Settings.Default.PassProp + "'; " +
                    "database='" + Properties.Settings.Default.DbProp + "'; ";

            conDataBase = new MySqlConnection(connectionString);
        }

        private void loadSensorConfig()
        {
            string mypath = Properties.Settings.Default.SaveLocation + "\\" + config_file;
            if (File.Exists(mypath))
            {
                string line;
                int count = 0;
                try
                {
                    StreamReader sr = new StreamReader(mypath);
                    line = sr.ReadLine();
                    if (line != "[antconfig 1.0]")
                    {
                        Helpers.ShowError("Not a valid sensor configuration file!", "0006_Mfconf");
                    }
                    else
                    {
                        while (line != null)
                        {
                            if (line.Length > 0 && line.Contains('\t'))
                            {
                                sensorConfig.Add(line.Trim());

                                count++;
                            }
                            else { line = sr.ReadLine(); continue; }

                            line = sr.ReadLine();
                        }
                        sr.Close();
                    }
                }
                catch (Exception ex)
                {
                    Helpers.ShowError("Exception: " + ex.Message, "0007_Mfconf");
                }
            }
        }

        private string getSpecies(string path)
        {
            string spec = "";
            string line;

            if (File.Exists(path))
            {
                try
                {
                    StreamReader sr = new StreamReader(path);
                    int count = 0;
                    line = sr.ReadLine();
                    if (line != "[antconfig 1.0]")
                    {
                        Helpers.ShowError("Not a valid species file: " + path, "0008_Mfspec");
                    }
                    else
                    {
                        count++;
                        while (line != null)
                        {
                            if (line.StartsWith("#"))   // Ignore comment lines
                            {
                                count++;
                                line = sr.ReadLine();
                                continue;
                            }
                            if (line.Length == 0)
                            {
                                count++;
                                line = sr.ReadLine();
                                continue;
                            }
                            if (count == 3)     // Species
                            {
                                spec = line;
                            }
                            
                            //Read the next line
                            count++;
                            line = sr.ReadLine();
                        }
                    }
                    sr.Close();
                }
                catch (Exception)
                {
                    Helpers.ShowError("Corrupt species file: " + path, "0009_Mfspec");
                }
            }           

            return spec;
        }

        private void setColors(string path, Sensor sens)
        {
            string line;
            
            if (File.Exists(path))
            {
                try
                {
                    StreamReader sr = new StreamReader(path);
                    int count = 0;
                    line = sr.ReadLine();
                    if (line != "[antconfig 1.0]")
                    {
                        Helpers.ShowError("Colors could not be loaded. Not a valid species file: " + path, "0010_Mfcol");
                    }
                    else
                    {
                        count++;
                        
                        while (line != null)
                        {
                            if (line.StartsWith("#"))       // Ignore comment lines
                            {
                                
                                line = sr.ReadLine();
                                count++;
                                continue;
                            }
                            if (line.Length == 0)
                            {
                                line = sr.ReadLine();
                                continue;
                            }
                            if (count == 3)     // Species
                            {
                                line = sr.ReadLine();
                                count++;
                                continue;
                            }
                            if (count == 4)     // Min Temp
                            {
                                sens.MinTemperature = Convert.ToInt16(line);
                            }
                            if (count == 5)     // Max Temp
                            {
                                sens.MaxTemperature = Convert.ToInt16(line);
                            }
                            if (count == 6)     // Min Humidity
                            {
                                sens.MinHumidity = Convert.ToInt16(line);
                            }
                            if (count == 7)     // Max Humidity
                            {
                                sens.MaxHumidity = Convert.ToInt16(line);
                            }

                            //Read the next line
                            count++;
                            line = sr.ReadLine();
                        }
                    }
                    sr.Close();
                }
                catch (Exception)
                {
                    Helpers.ShowError("Colors could not be loaded. Not a valid species file: " + path, "0010_Mfcol");
                }
            }
        }

        private void showConnectionSetupForm()
        {
            connectionSetupForm = new ConnectionSetupForm();
            connectionSetupForm.MdiParent = this.ParentForm;
            connectionSetupForm.StartPosition = FormStartPosition.CenterParent;
            connectionSetupForm.FormClosed += new FormClosedEventHandler(ConnectionForm_FormClosed);
            connectionSetupForm.ShowDialog();
        }
        private void ConnectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connectionSetupForm.Result == Helpers.ResultCode.Ok)
            {
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                clearDashboardTable();
                init();
            }
        }
            
        private void checkCountSensorProp()
        {
            if (Properties.Settings.Default.CountSensorProp.Length >= 1)
            {
                if (Properties.Settings.Default.CountSensorProp.Contains(","))
                {
                    sensors = Properties.Settings.Default.CountSensorProp.Split(',');
                }
                else if (Properties.Settings.Default.CountSensorProp.Contains(";"))
                {
                    sensors = Properties.Settings.Default.CountSensorProp.Split(';');
                }
                else if (Properties.Settings.Default.CountSensorProp.Contains(" "))
                {
                    sensors = Properties.Settings.Default.CountSensorProp.Split(' ');
                }
                if (sensors.Length >= 1)    // at least one sensor was defined in the ConnectionSetupForm
                {
                    clearDashboardTable();

                    for (int i = 0; i < sensors.Length; i++)
                    {
                        // add Sensor
                        sensorList.Add(new Sensor(Int32.Parse(sensors[i])));
                    }
                }
            }
        }

        private void statisticsToolStripButton_Click(object sender, EventArgs e)
        {
            showStatistics();
        }

        private void checkToolbar()
        {
            mainToolStrip.Visible = Properties.Settings.Default.ShowToolbar;
            showToolbarToolStripMenuItem.Checked = Properties.Settings.Default.ShowToolbar;
            showHelpIconsToolStripMenuItem.Checked = Properties.Settings.Default.ShowHelpicons;
            if (!Properties.Settings.Default.ShowHelpicons)
            {
                helpTSB.Visible = false;
                help_infoTSB.Visible = false;
            }
        }
        private void showHelpIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showHelpIconsToolStripMenuItem.Checked)
            {
                helpToolStripSeparator.Visible = false;
                helpTSB.Visible = false;
                help_infoTSB.Visible = false;
                showHelpIconsToolStripMenuItem.Checked = false;
                Properties.Settings.Default.ShowHelpicons = false;
            }
            else
            {
                helpToolStripSeparator.Visible = true;
                helpTSB.Visible = true;
                help_infoTSB.Visible = true;
                showHelpIconsToolStripMenuItem.Checked = true;
                Properties.Settings.Default.ShowHelpicons = true;
            }
        }
        private void showToolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showToolbarToolStripMenuItem.Checked)
            {
                mainToolStrip.Visible = false;
                showToolbarToolStripMenuItem.Checked = false;
                Properties.Settings.Default.ShowToolbar = false;
            }
            else
            {
                mainToolStrip.Visible = true;
                showToolbarToolStripMenuItem.Checked = true;
                Properties.Settings.Default.ShowToolbar = true;
            }
        }

        private void clearDashboardTable()
        {
            sensorList = new List<Sensor>();
            sensorConfig = new List<String>();
            flowLayoutPanel.Controls.Clear();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showStatistics();
        }

        private void showStatistics()
        {
            statisticsForm = new StatisticsForm();
            statisticsForm.MdiParent = this.ParentForm;
            statisticsForm.StartPosition = FormStartPosition.CenterParent;
            statisticsForm.Show();
        }

        private void exitToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void databaseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showConnectionSetupForm();
        }
        private void sensorMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorForm = new ColorValues(sensorList);
            colorForm.MdiParent = this.ParentForm;
            colorForm.StartPosition = FormStartPosition.CenterParent;
            colorForm.FormClosed += new FormClosedEventHandler(ColorForm_FormClosed);
            colorForm.ShowDialog();
        }

        private void ColorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (colorForm.Result == Helpers.ResultCode.Ok)
            {
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                clearDashboardTable();
                init();
            }
        }

        #region Help Menu
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showHelpForm();
        }

        private void showHelpForm()
        {
            System.Diagnostics.Process.Start("WeatherStation2023.pdf");
        }
        
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showInfoForm();
        }

        private void showInfoForm()
        {
            infoForm = new InfoForm();
            infoForm.MdiParent = this.ParentForm;
            infoForm.StartPosition = FormStartPosition.CenterParent;
            infoForm.ShowDialog();
        }

        private void showErrorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showErrorsToolStripMenuItem.Checked)
            {
                showErrorsToolStripMenuItem.Checked = false;
                Properties.Settings.Default.ShowDebug = false;
            }
            else
            {
                showErrorsToolStripMenuItem.Checked = true;
                Properties.Settings.Default.ShowDebug = true;
            }
        }

        private void helpTSB_Click(object sender, EventArgs e)
        {
            showHelpForm();
        }

        private void help_infoTSB_Click(object sender, EventArgs e)
        {
            showInfoForm();
        }
        #endregion

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            runBackgroundWorkers();
        }
        private void runBackgroundWorkers()
        {
            foreach (Sensor s in sensorList)
            {
                try
                {
                    if (s.MyBackgroundWorker.IsBusy != true)
                    {
                        s.MyBackgroundWorker.RunWorkerAsync();
                    }   
                }
                catch (Exception ex)
                {
                    Helpers.ShowError(ex.Message, "0001_BgwMf-" + s.ID.ToString());
                }
            }
        }
    }
}
