using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WeatherStation2023
{
    public partial class SensorStatisticsForm : Form
    {
        int sensorId;
        List<Dictionary<string, string>> allSensorValues;

        // Database variables.
        MySqlConnection conDataBase;
        MySqlDataReader dbReader;
        MySqlCommand command;
        private string sql;
        string connectionString;

        public SensorStatisticsForm(string name)
        {
            InitializeComponent();

            allSensorValues = new List<Dictionary<string, string>>();

            statusLabel.Text = "Loading...";

            changeXaxis();

            init(name);

            runBackgroundWorker();
        }

        private void init(string name)
        {
            sensorId = getSensorID(name);

            if (sensorId != -1)
            {
                this.Text = "Data for Sensor " + sensorId;
            }
            else
            {
                this.Text = "No valid sensor loaded!!";
            }

            if (!Properties.Settings.Default.ShowToolbar)
            {
                statToolStrip.Visible = Properties.Settings.Default.ShowToolbar;
            }

            sql = "SELECT * FROM " + Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + " WHERE " +
                Properties.Settings.Default.DbSensValProp + " = " + sensorId.ToString() + ";";

            connectionString = "server=" + Properties.Settings.Default.HostProp + "; " +
                    "port=" + Properties.Settings.Default.PortProp.ToString() + "; " +
                    "username='" + Properties.Settings.Default.UserProp + "'; " +
                    "password='" + Properties.Settings.Default.PassProp + "'; " +
                    "database='" + Properties.Settings.Default.DbProp + "'; ";

            conDataBase = new MySqlConnection(connectionString);
        }

        private int getSensorID(string name)
        {
            int number = -1;
            List<string> list = name.Split(' ').ToList();
            var isNumeric = int.TryParse(list[1] as string, out number);
            return number;
        }

        private void exitTSB_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeFilter();
        }

        private void changeFilter()
        {
            DateTime thisDay = DateTime.Today;
            
            List<Dictionary<string, string>> copyAllSensorValues = allSensorValues;

            if (filterComboBox.Text.Length > 0)
            {
                sensorChart.Series[0].Points.Clear();
                sensorChart.Series[1].Points.Clear();

                foreach (Dictionary<string, string> item in copyAllSensorValues)
                {
                    DateTime dt = DateTime.Parse(item["created_at"]);
                    if (filterComboBox.Text.Length == 4)    // Year
                    {
                        if (dt.Year == Int16.Parse(filterComboBox.Text))
                        {
                            sensorChart.Series[1].Points.AddXY(dt, Double.Parse(item["temp"]));
                            sensorChart.Series[0].Points.AddXY(dt, Double.Parse(item["hygro"]));
                        }
                    }
                    else if (filterComboBox.Text.Length == 7)   // Month
                    {
                        if (dt.Year == Int16.Parse(filterComboBox.Text.Substring(0, 4)) &&
                            dt.Month == Int16.Parse(filterComboBox.Text.Substring(5, 2)))
                        {
                            sensorChart.Series[1].Points.AddXY(dt, Double.Parse(item["temp"]));
                            sensorChart.Series[0].Points.AddXY(dt, Double.Parse(item["hygro"]));
                        }
                    }
                    else if (filterComboBox.Text.Length == 10)   // Today
                    {
                        DateTime filterDay = DateTime.Parse(filterComboBox.Text);
                        if (!filterComboBox.Items.Contains(filterComboBox.Text))
                        {
                            filterComboBox.Items.Add(filterComboBox.Text);
                        }
                        if (dt.Date == thisDay.Date)
                        {
                            sensorChart.Series[1].Points.AddXY(dt, Double.Parse(item["temp"]));
                            sensorChart.Series[0].Points.AddXY(dt, Double.Parse(item["hygro"]));
                        }
                        else if (dt.Date == filterDay.Date) 
                        {
                            sensorChart.Series[1].Points.AddXY(dt, Double.Parse(item["temp"]));
                            sensorChart.Series[0].Points.AddXY(dt, Double.Parse(item["hygro"]));
                        }
                    }
                    else if (filterComboBox.Text == "All data")
                    {
                        sensorChart.Series[1].Points.AddXY(dt, Double.Parse(item["temp"]));
                        sensorChart.Series[0].Points.AddXY(dt, Double.Parse(item["hygro"]));
                    }
                }
            }
        }

        private void changeXaxis()
        {
            if (Properties.Settings.Default.SensorXAxis != "")
            {
                formatToolStripComboBox.Text = Properties.Settings.Default.SensorXAxis;
            }
        }

        #region Application Settings: position, size and name
        //https://www.codeproject.com/Tips/543631/Save-and-restore-your-form-size-and-location
        /// <summary>
        /// Load Application Settings during startup. Hold "Shift"-key for applicaton default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatForm_Load(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) == 0)
            {
                string initLocation = Properties.Settings.Default.SensorStatLocation;
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
        private void StatForm_FormClosing(object sender, FormClosingEventArgs e)
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
                Properties.Settings.Default.SensorStatLocation = initLocation;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
        }
        #endregion

        private void sensorWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;
                allSensorValues.Clear();

                conDataBase.Open();
                command = new MySqlCommand(sql, conDataBase);
                dbReader = command.ExecuteReader();

                while (dbReader.Read())     
                {
                    Dictionary<string, string> result = new Dictionary<string, string>();
                    result["id"] = dbReader.GetInt32(Properties.Settings.Default.IdProp).ToString();
                    result["sensor_id"] = dbReader.GetInt32(Properties.Settings.Default.DbSensValProp).ToString();
                    dt = dbReader.GetDateTime(Properties.Settings.Default.CreatedAtProp);
                    result["temp"] = dbReader.GetDouble(Properties.Settings.Default.DbTempValProp).ToString();
                    result["hygro"] = dbReader.GetDouble(Properties.Settings.Default.DbHumValProp).ToString();
                    result["created_at"] = dt.ToString();

                    allSensorValues.Add(result);                   
                }

                conDataBase.Close();
                e.Result = allSensorValues;
            }
            catch (Exception ex)
            {
                Helpers.ShowError(ex.Message, "0003_BgwSsf_r");
            }
            finally { conDataBase.Close(); }
        }

        private void sensorWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Dictionary<string, string>> tmp = checkBackGroundWorker(e);
            string filter = filterComboBox.Text;
            
            if (tmp != null)
            {
                statusLabel.Text = "Loaded " + tmp.Count.ToString() + " datasets";
                sensorChart.Series[0].Points.Clear();
                sensorChart.Series[1].Points.Clear();
                DateTime thisDay = DateTime.Today;

                for (int i = 0; i < tmp.Count; i++)
                {
                    DateTime dt = DateTime.Parse(tmp[i]["created_at"]);
                    if (dt != null)
                    {
                        if (!filterComboBox.Items.Contains(dt.Year.ToString()))
                        {
                            filterComboBox.Items.Add(dt.Year.ToString());
                        }
                        if (!filterComboBox.Items.Contains(dt.ToString("yyyy-MM")))
                        {
                            filterComboBox.Items.Add(dt.ToString("yyyy-MM"));
                        }
                        if (dt.Date == thisDay.Date && !filterComboBox.Items.Contains(dt.ToString("yyyy-MM-dd")))
                        {
                            filterComboBox.Items.Add(dt.ToString("yyyy-MM-dd"));
                        }
                    }
                    sensorChart.Series[1].Points.AddXY(dt, Double.Parse(tmp[i]["temp"]));
                    sensorChart.Series[0].Points.AddXY(dt, Double.Parse(tmp[i]["hygro"]));
                }
                if (filter == "" || filter == "All data")
                {
                    filterComboBox.Text = "All data";
                }
                else
                {
                    filterComboBox.Text = filter;
                    changeFilter();
                }
            }
        }

        private List<Dictionary<string, string>> checkBackGroundWorker(RunWorkerCompletedEventArgs e)
        {
            List<Dictionary<string, string>> tmp = new List<Dictionary<string, string>>();
            try
            {
                tmp = e.Result as List<Dictionary<string, string>>;
            }
            catch (Exception ex)
            {
                Helpers.ShowError(ex.Message, "0004_BgwSsf_c");
            }

            return tmp;
        }

        private void sensorTimer_Tick(object sender, EventArgs e)
        {
            runBackgroundWorker();
        }

        private void runBackgroundWorker()
        {
            if (sensorWorker.IsBusy != true)
            {
                sensorWorker.RunWorkerAsync();
            }
        }

        private void formatToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formatToolStripComboBox.Text != "")
            {
                formatXAxis(formatToolStripComboBox.Text);
            }
        }

        private void formatXAxis(string format)
        {
            sensorChart.ChartAreas[0].AxisX.LabelStyle.Format = format;
            Properties.Settings.Default.SensorXAxis = format;
        }

        private void exportAsCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export();
        }

        private void exportToolStripButton_Click(object sender, EventArgs e)
        {
            export();
        }

        private void export()
        {
            DateTime thisDay = DateTime.Now;
            List<Dictionary<string, string>> copyAllSensorValues = allSensorValues;
            saveCSVFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveCSVFileDialog.FilterIndex = 1;
            saveCSVFileDialog.RestoreDirectory = true;
            saveCSVFileDialog.Title = "Export to CSV file";
            saveCSVFileDialog.FileName = "sen" + sensorId.ToString() + "_" + thisDay.ToString("yyyyMMddHHmmss");

            if (saveCSVFileDialog.ShowDialog() == DialogResult.OK && copyAllSensorValues.Count > 0)
            {
                var csv = new StringBuilder();
                var newLine = "Data for sensor " + sensorId.ToString() + "\t, created at " + thisDay.ToString("yyyyMMdd HH:mm:ss");
                csv.AppendLine(newLine);
                newLine = "Created at:\tTemperature [°C]\tHumidity [%]";
                csv.AppendLine(newLine);
                for (int i = 0; i < copyAllSensorValues.Count; i++)
                {
                    DateTime dt = DateTime.Parse(copyAllSensorValues[i]["created_at"]);
                    newLine = dt.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + Double.Parse(copyAllSensorValues[i]["temp"]) + "\t" + Double.Parse(copyAllSensorValues[i]["hygro"]);
                    csv.AppendLine(newLine);
                }

                File.WriteAllText(saveCSVFileDialog.FileName, csv.ToString());
                statusLabel.Text = saveCSVFileDialog.FileName + " successfully written...";
            }
        }
    }
}
