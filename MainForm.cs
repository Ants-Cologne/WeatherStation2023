using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Media;
//using LiveCharts;
//using LiveCharts.Wpf;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;

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

        string[] sensors;
        List<Sensor> sensorList;
        List<String> sensorConfig;

        // Database variables.
        MySqlConnection conDataBase, cdb1, cdb2, cdb3, cdb4;
        /*MySqlDataReader dbReader, dbr1, dbr2, dbr3, dbr4;
        MySqlCommand command, com1, com2, com3, com4;
        private string sql, sql1, sql2, sql3, sql4;*/
        string connectionString;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            sensorList = new List<Sensor>();
            sensorConfig= new List<String>();

            connectionStatusLbl.Text = "";

            initDatabase();

            checkCountSensorProp();

            loadSensorConfig();

            if (sensorList.Count > 0)   // User settings are available.
            {
                List<String> listStrLineElements;
                string tmp_txt, species;

                for (int i = 0; i < sensorList.Count; i++)
                {
                    Sensor s = sensorList[i];
                    listStrLineElements = sensorConfig[i].Split('\t').ToList();
                    // Get AliasLabel from config file
                    if (listStrLineElements[1] != "") tmp_txt = s.PublicLabel + " (" + listStrLineElements[1] + ")";
                    else tmp_txt = s.PublicLabel;
                    // Get species
                    species = getSpecies(listStrLineElements[2]);
                    if (species != "")
                    {
                        tmp_txt += " - Species: " + species;
                    }
                    
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

                    // set temperature and humidity colors
                    setColors(listStrLineElements[2], s);

                    flowLayoutPanel.Controls.Add(customGroupBox);

                    // Add to toolstrip menu
                    addSensorToolStripMenuItem(s);
                }
                connectionStatusLbl.Text = $"{sensorList.Count} Sensors loaded from User Settings!";

                runBackgroundWorkers();
            }
            else
            {
                connectionStatusLbl.Text = "Please run Setup->Database Connection to get a database connection..."; 
            }

            checkToolbar();
            /*for (int i = 0; i < 5; i++)
            
                var customGroupBox = new SensorGroupBox
                {
                    Text = $"Sensor {++_id}",
                    Width = flowLayoutPanel.Width - SystemInformation.VerticalScrollBarWidth,
                    Padding = new Padding(),
                    Margin = new Padding(),
                };
                flowLayoutPanel.Controls.Add(customGroupBox);
            }*/
            //buttonClear.Click += (sender, e) => flowLayoutPanel.Controls.Clear();
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

        private void initDatabase()
        {
            connectionString = "server=" + Properties.Settings.Default.HostProp + "; " +
                    "port=" + Properties.Settings.Default.PortProp.ToString() + "; " +
                    "username='" + Properties.Settings.Default.UserProp + "'; " +
                    "password='" + Properties.Settings.Default.PassProp + "'; " +
                    "database='" + Properties.Settings.Default.DbProp + "'; ";

            conDataBase = new MySqlConnection(connectionString);
            cdb1 = new MySqlConnection(connectionString);
            cdb2 = new MySqlConnection(connectionString);
            cdb3 = new MySqlConnection(connectionString);
            cdb4 = new MySqlConnection(connectionString);
        }

        private void loadSensorConfig()
        {
            string mypath = Properties.Settings.Default.SaveLocation + "\\" + "sensors.cfg";
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
                        MessageBox.Show("Error: not a valid sensor configuration file!");
                    }
                    else
                    {
                        while (line != null)
                        {
                            if (line.Length > 0 && line.Contains('\t'))
                            {
                                sensorConfig.Add(line.Trim());
                                //mappingGroups[count].AliasLabel.Text = listStrLineElements[1];
                                //mappingGroups[count].FilenameLabel.Text = listStrLineElements[2];

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
                    MessageBox.Show("Exception: " + ex.Message);
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
                        MessageBox.Show("Error: not a valid sensor settings file!");
                    }
                    else
                    {
                        count++;
                        while (line != null)
                        {
                            //MessageBox.Show(count.ToString() + " - " + line);
                            if (line.StartsWith("#"))
                            {
                                // Ignore comment lines
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
                            // Species
                            if (count == 3)
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

                    throw;
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
                        MessageBox.Show("Error: not a valid sensor settings file!");
                    }
                    else
                    {
                        count++;
                        
                        while (line != null)
                        {
                            //MessageBox.Show(count.ToString() + " - " + line);
                            //MessageBox.Show(count.ToString());
                            if (line.StartsWith("#"))
                            {
                                // Ignore comment lines
                                line = sr.ReadLine();
                                count++;
                                continue;
                            }
                            if (line.Length == 0)
                            {
                                line = sr.ReadLine();
                                continue;
                            }
                            // Species
                            if (count == 3)
                            {
                                line = sr.ReadLine();
                                count++;
                                continue;
                            }
                            // Min Temp
                            if (count == 4)
                            {
                                //MessageBox.Show("Temp min: " + line);
                                sens.MinTemperature = Convert.ToInt16(line);
                            }
                            // Max Temp
                            if (count == 5)
                            {
                                //MessageBox.Show("Temp max: " + line);
                                sens.MaxTemperature = Convert.ToInt16(line);
                            }
                            // Min Humidity
                            if (count == 6)
                            {
                                sens.MinHumidity = Convert.ToInt16(line);
                            }
                            // Max Humidity
                            if (count == 7)
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

                    throw;
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
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            checkCountSensorProp();
            this.Text = Properties.Settings.Default.ApplicationName;
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
            colorForm.ShowDialog();
        }

        #region Help Menu
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showHelpForm();
        }

        private void showHelpForm()
        {
            /*helpForm = new HelpForm();
            helpForm.MdiParent = this.ParentForm;
            helpForm.StartPosition = FormStartPosition.CenterParent;
            helpForm.ShowDialog();*/
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
                    s.MyBackgroundWorker.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    // at least we need to check if the host is not available: currently app crashes
                    Helpers.ShowError(ex.Message, "0001_BgwMf-" + s.ID.ToString());
                }
            }
        }
    }
}
