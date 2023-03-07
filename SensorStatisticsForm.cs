using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WeatherStation2023
{
    public partial class SensorStatisticsForm : Form
    {
        int sensorId;
        // Database variables.
        MySqlConnection conDataBase;
        MySqlDataReader dbReader;
        MySqlCommand command;
        private string sql;
        string connectionString;

        public SensorStatisticsForm(string name)
        {
            InitializeComponent();

            statusLabel.Text = "Loading...";

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
                //int cnt = 0;

                List<Dictionary<string, string>> allSensorValues = new List<Dictionary<string,string>>();

                
                /*result.Add("id", "");
                result.Add("temp", "");
                result.Add("hygro", "");
                result.Add("sensor_id", "");
                result.Add("created_at", "");*/

                //string query;

                /*if (filterComboBox.Text == "")      // not used, yet
                {
                    //query = "select * from antstation.raw_data;";

                    query = "select * from " + Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + " WHERE date(created_at) = '" + dt.ToString("yyyy-MM-dd") + "'; ";
                }
                else
                {
                    dt = DateTime.Parse(filterComboBox.Text);
                    query = "select * from " + Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + " WHERE date(created_at) = '" + filterComboBox.Text + "'; ";    //Month and Year doesn't work
                }*/

                conDataBase.Open();
                command = new MySqlCommand(sql, conDataBase);
                dbReader = command.ExecuteReader();

                while (dbReader.Read())     
                {
                    /*currentTemp = dbReader.GetDouble(Properties.Settings.Default.DbTempValProp);
                    currentHygro = dbReader.GetDouble(Properties.Settings.Default.DbHumValProp);
                    dt = dbReader.GetDateTime(Properties.Settings.Default.CreatedAtProp);*/

                    Dictionary<string, string> result = new Dictionary<string, string>();
                    result["id"] = dbReader.GetInt32(Properties.Settings.Default.IdProp).ToString();
                    //result["temp"] = string.Format("{0:N2}", dbReader.GetDouble(Properties.Settings.Default.DbTempValProp)) + "°C";
                    //result["hygro"] = string.Format("{0:N2}", dbReader.GetDouble(Properties.Settings.Default.DbHumValProp)) + "%";
                    result["sensor_id"] = dbReader.GetInt32(Properties.Settings.Default.DbSensValProp).ToString();
                    dt = dbReader.GetDateTime(Properties.Settings.Default.CreatedAtProp);
                    //result["created_at"] = dt.ToString("dd-MMM-yyyy HH:mm:ss");
                    //result["id"] = dbReader.GetInt32(Properties.Settings.Default.IdProp).ToString();
                    result["temp"] = dbReader.GetDouble(Properties.Settings.Default.DbTempValProp).ToString();
                    result["hygro"] = dbReader.GetDouble(Properties.Settings.Default.DbHumValProp).ToString();
                    //result["sensor_id"] = dbReader.GetInt32(Properties.Settings.Default.DbSensValProp).ToString();
                    //dt = dbReader.GetDateTime(Properties.Settings.Default.CreatedAtProp);
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

        private void sensorWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void sensorWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Dictionary<string, string>> tmp = checkBackGroundWorker(e);
            //int cnt = 0;

            /*string year = dt.Year.ToString();

            string month = dt.Month.ToString();

            string day = year + "-" + month + "-" + dt.Day.ToString();

            if (!filterComboBox.Items.Contains(year))
            {
                filterComboBox.Items.Add(year);
            }

            if (!filterComboBox.Items.Contains(year + "-" + month))
            {
                filterComboBox.Items.Add(year + "-" + month);
            }

            if (!filterComboBox.Items.Contains(day))
            {
                filterComboBox.Items.Add(day);
            }*/
            
            if (tmp != null)
            {
                statusLabel.Text = "Loaded " + tmp.Count.ToString() + " datasets";
                //MessageBox.Show(tmp.Count.ToString());
                sensorChart.Series[0].Points.Clear();
                sensorChart.Series[1].Points.Clear();

                for (int i = 0; i < tmp.Count; i++)
                {
                    DateTime dt = DateTime.Parse(tmp[i]["created_at"]);
                    //MessageBox.Show(dt.ToString());
                    sensorChart.Series[1].Points.AddXY(dt, Double.Parse(tmp[i]["temp"]));
                    sensorChart.Series[0].Points.AddXY(dt, Double.Parse(tmp[i]["hygro"]));
                } 

/*                foreach (Dictionary<string, string> series in tmp)
                {
                    //MessageBox.Show(series["id"].ToString() + " - " + series["created_at"]);
                    DateTime dt = DateTime.Parse(series["created_at"]);
                    MessageBox.Show(dt.ToString());
                    sensorChart.Series[1].Points.AddXY(dt, Double.Parse(series["temp"]));
                    sensorChart.Series[0].Points.AddXY(dt, Double.Parse(series["hygro"]));
                }*/
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
    }
}
