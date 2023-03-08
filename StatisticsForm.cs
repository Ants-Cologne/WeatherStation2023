using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WeatherStation2023
{
    public partial class StatisticsForm : Form
    {
        // Database variables.
        MySqlConnection conDataBase, cdb1, cdb2, cdb3, cdb4;
        MySqlDataReader dbReader, dbr1, dbr2, dbr3, dbr4;
        MySqlCommand command, com1, com2, com3, com4;
        private string sql, sql1, sql2, sql3, sql4;
        string connectionString;

        public StatisticsForm()
        {
            InitializeComponent();

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

            if (!Properties.Settings.Default.ShowToolbar)
            {
                topToolStrip.Visible= false;
            }

            runBackgroundWorkers();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void statTimer_Tick(object sender, EventArgs e)
        {
            runBackgroundWorkers();
        }

        #region Application Settings: position, size and name
        //https://www.codeproject.com/Tips/543631/Save-and-restore-your-form-size-and-location
        /// <summary>
        /// Load Application Settings during startup. Hold "Shift"-key for applicaton default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) == 0)
            {
                string initLocation = Properties.Settings.Default.StatLocation;
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
            }
            // Load language from User settings.
            //changeLanguage();
        }

        /// <summary>
        /// Write Application settings on closing. Hold "Shift"-key to skip the saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
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
                Properties.Settings.Default.StatLocation = initLocation;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
        }
        #endregion

        private void runBackgroundWorkers()
        {
            if (statBackgroundWorker.IsBusy == false)
            {
                statBackgroundWorker.RunWorkerAsync();
            }
            if (minT_backgroundWorker.IsBusy == false)
            {
                minT_backgroundWorker.RunWorkerAsync();
            }
            if (maxT_backgroundWorker.IsBusy == false)
            {
                maxT_backgroundWorker.RunWorkerAsync();
            }
            if (minH_backgroundWorker.IsBusy == false)
            {
                minH_backgroundWorker.RunWorkerAsync();
            }          
            if (maxH_backgroundWorker.IsBusy == false)
            {
                maxH_backgroundWorker.RunWorkerAsync();
            }
        }

        #region Statistics Background Worker
        /// <summary>
        /// Statistics Background Worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                sql = "SELECT MAX(" + Properties.Settings.Default.IdProp + ") AS max_id, MIN(" + Properties.Settings.Default.DbTempValProp + ") AS min_t, "
                    + "MAX(" + Properties.Settings.Default.DbTempValProp + ") AS max_t, MIN(" + Properties.Settings.Default.DbHumValProp + ") AS min_h, "
                    + "MAX(" + Properties.Settings.Default.DbHumValProp + ") AS max_h, MIN(" + Properties.Settings.Default.CreatedAtProp + ") AS min_c, "
                    + "MAX(" + Properties.Settings.Default.CreatedAtProp + ") AS max_c FROM " + Properties.Settings.Default.DbProp + "."
                    + Properties.Settings.Default.DbTableProp;

                Dictionary<string, string> result = new Dictionary<string, string>();
                DateTime dt = DateTime.Now;

                conDataBase.Open();
                command = new MySqlCommand(sql, conDataBase);
                dbReader = command.ExecuteReader();

                while (dbReader.Read())     // we get only one row, but still use a while loop here
                {
                    result.Add("max_id", dbReader.GetInt32("max_id").ToString());
                    result.Add("min_t", string.Format("{0:N2}", dbReader.GetDouble("min_t")) + "°C");
                    result.Add("max_t", string.Format("{0:N2}", dbReader.GetDouble("max_t")) + "°C");
                    result.Add("min_h", string.Format("{0:N2}", dbReader.GetDouble("min_h")) + "%");
                    result.Add("max_h", string.Format("{0:N2}", dbReader.GetDouble("max_h")) + "%");
                    dt = dbReader.GetDateTime("min_c");
                    result.Add("min_c", dt.ToString("dd-MMM-yyyy HH:mm:ss"));
                    dt = dbReader.GetDateTime("max_c");
                    result.Add("max_c", dt.ToString("dd-MMM-yyyy HH:mm:ss"));
                }
                conDataBase.Close();

                e.Result = result;
            }
            catch (Exception)
            {
                // implement exceptions here: we're ignoring them now
                throw;
            }
        }

        private void statBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dictionary<string, string> tmp = e.Result as Dictionary<string, string>;
            totalEntriesLabel.Text = tmp["max_id"];
            firstEntryLabel.Text = tmp["min_c"];
            lastEntryLabel.Text = tmp["max_c"];
            minTempLabel.Text = tmp["min_t"];
            maxTempLabel.Text = tmp["max_t"];
            minHumidityLabel.Text = tmp["min_h"];
            maxHumidityLabel.Text = tmp["max_h"];
        }
        #endregion

        #region More Statistics Background Workers
        private void minT_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                sql1 = "SELECT * FROM " + Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + " WHERE "
                    + Properties.Settings.Default.DbTempValProp + " = (SELECT MIN(" + Properties.Settings.Default.DbTempValProp + ") FROM "
                    + Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + ")";

                Dictionary<string, string> result = new Dictionary<string, string>();
                result.Add("id", "");
                result.Add("temp", "");
                result.Add("hygro", "");
                result.Add("sensor_id", "");
                result.Add("created_at", "");
                DateTime dt = DateTime.Now;

                cdb1.Open();
                com1 = new MySqlCommand(sql1, cdb1);
                dbr1 = com1.ExecuteReader();

                while (dbr1.Read())     // this could have more than one row, but we're storing the last one in our result
                {
                    result["id"] = dbr1.GetInt32(Properties.Settings.Default.IdProp).ToString();
                    result["temp"] = string.Format("{0:N2}", dbr1.GetDouble(Properties.Settings.Default.DbTempValProp)) + "°C";
                    result["hygro"] = string.Format("{0:N2}", dbr1.GetDouble(Properties.Settings.Default.DbHumValProp)) + "%";
                    result["sensor_id"] = dbr1.GetInt32(Properties.Settings.Default.DbSensValProp).ToString();
                    dt = dbr1.GetDateTime(Properties.Settings.Default.CreatedAtProp);
                    result["created_at"] = dt.ToString("dd-MMM-yyyy HH:mm:ss");
                }
                cdb1.Close();

                e.Result = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void minT_backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dictionary<string, string> tmp = checkBackGroundWorker(e);
            if (tmp != null)
            {
                minTempSensorLabel.Text = "   (Sensor " + tmp["sensor_id"] + ": " + tmp["created_at"] + ")";
            }
            else
            {
                minTempSensorLabel.Text = "   n/a";
            }
        }

        private void maxT_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                sql2 = "SELECT * FROM " + Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + " WHERE "
                    + Properties.Settings.Default.DbTempValProp + " = (SELECT MAX(" + Properties.Settings.Default.DbTempValProp + ") FROM "
                    + Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + ")";

                Dictionary<string, string> result = new Dictionary<string, string>();
                result.Add("id", "");
                result.Add("temp", "");
                result.Add("hygro", "");
                result.Add("sensor_id", "");
                result.Add("created_at", "");
                DateTime dt = DateTime.Now;

                cdb2.Open();
                com2 = new MySqlCommand(sql2, cdb2);
                dbr2 = com2.ExecuteReader();

                while (dbr2.Read())     // this could have more than one row, but we're storing the last one in our result
                {
                    result["id"] = dbr2.GetInt32(Properties.Settings.Default.IdProp).ToString();
                    result["temp"] = string.Format("{0:N2}", dbr2.GetDouble(Properties.Settings.Default.DbTempValProp)) + "°C";
                    result["hygro"] = string.Format("{0:N2}", dbr2.GetDouble(Properties.Settings.Default.DbHumValProp)) + "%";
                    result["sensor_id"] = dbr2.GetInt32(Properties.Settings.Default.DbSensValProp).ToString();
                    dt = dbr2.GetDateTime(Properties.Settings.Default.CreatedAtProp);
                    result["created_at"] = dt.ToString("dd-MMM-yyyy HH:mm:ss");
                }
                cdb2.Close();

                e.Result = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void maxT_backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dictionary<string, string> tmp = checkBackGroundWorker(e);
            if (tmp != null)
            {
                maxTempSensorLabel.Text = "   (Sensor " + tmp["sensor_id"] + ": " + tmp["created_at"] + ")";
            }
            else
            {
                maxTempSensorLabel.Text = "   n/a";
            }
        }

        private void minH_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                sql3 = "SELECT * FROM " + Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + " WHERE "
                    + Properties.Settings.Default.DbHumValProp + " = (SELECT MIN(" + Properties.Settings.Default.DbHumValProp + ") FROM "
                    + Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + ")";

                Dictionary<string, string> result = new Dictionary<string, string>();
                result.Add("id", "");
                result.Add("temp", "");
                result.Add("hygro", "");
                result.Add("sensor_id", "");
                result.Add("created_at", "");
                DateTime dt = DateTime.Now;

                cdb3.Open();
                com3 = new MySqlCommand(sql3, cdb3);
                dbr3 = com3.ExecuteReader();

                while (dbr3.Read())     // this could have more than one row, but we're storing the last one in our result
                {
                    result["id"] = dbr3.GetInt32(Properties.Settings.Default.IdProp).ToString();
                    result["temp"] = string.Format("{0:N2}", dbr3.GetDouble(Properties.Settings.Default.DbTempValProp)) + "°C";
                    result["hygro"] = string.Format("{0:N2}", dbr3.GetDouble(Properties.Settings.Default.DbHumValProp)) + "%";
                    result["sensor_id"] = dbr3.GetInt32(Properties.Settings.Default.DbSensValProp).ToString();
                    dt = dbr3.GetDateTime(Properties.Settings.Default.CreatedAtProp);
                    result["created_at"] = dt.ToString("dd-MMM-yyyy HH:mm:ss");
                }
                cdb3.Close();

                e.Result = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void minH_backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dictionary<string, string> tmp = checkBackGroundWorker(e);
            if (tmp != null)
            {
                minHumiditySensorLabel.Text = "   (Sensor " + tmp["sensor_id"] + ": " + tmp["created_at"] + ")";
            }
            else
            {
                minHumiditySensorLabel.Text = "   n/a";
            }
        }

        private void maxH_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                sql4 = "SELECT * FROM " + Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + " WHERE "
                    + Properties.Settings.Default.DbHumValProp + " = (SELECT MAX(" + Properties.Settings.Default.DbHumValProp + ") FROM "
                    + Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + ")";

                Dictionary<string, string> result = new Dictionary<string, string>();
                result.Add("id", "");
                result.Add("temp", "");
                result.Add("hygro", "");
                result.Add("sensor_id", "");
                result.Add("created_at", "");
                DateTime dt = DateTime.Now;

                cdb4.Open();
                com4 = new MySqlCommand(sql4, cdb4);
                dbr4 = com4.ExecuteReader();

                while (dbr4.Read())     // this could have more than one row, but we're storing the last one in our result
                {
                    result["id"] = dbr4.GetInt32(Properties.Settings.Default.IdProp).ToString();
                    result["temp"] = string.Format("{0:N2}", dbr4.GetDouble(Properties.Settings.Default.DbTempValProp)) + "°C";
                    result["hygro"] = string.Format("{0:N2}", dbr4.GetDouble(Properties.Settings.Default.DbHumValProp)) + "%";
                    result["sensor_id"] = dbr4.GetInt32(Properties.Settings.Default.DbSensValProp).ToString();
                    dt = dbr4.GetDateTime(Properties.Settings.Default.CreatedAtProp);
                    result["created_at"] = dt.ToString("dd-MMM-yyyy HH:mm:ss");
                }
                cdb4.Close();

                e.Result = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void maxH_backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dictionary<string, string> tmp = checkBackGroundWorker(e);
            if (tmp != null)
            {
                maxHumiditySensorLabel.Text = "   (Sensor " + tmp["sensor_id"] + ": " + tmp["created_at"] + ")";
            }
            else
            {
                maxHumiditySensorLabel.Text = "   n/a";
            }
        }

        private Dictionary<string,string> checkBackGroundWorker(RunWorkerCompletedEventArgs e)
        {
            Dictionary<string,string> tmp = new Dictionary<string,string>();
            try
            {
                tmp = e.Result as Dictionary<string, string>;
            }
            catch (Exception ex)
            {
                Helpers.ShowError(ex.Message, "0005_BgwSf");
            }

            return tmp;
        }
        #endregion
    }
}
