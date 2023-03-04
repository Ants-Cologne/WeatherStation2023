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
                Properties.Settings.Default.DbSensValProp + " = " + sensorId.ToString() + ");";

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
                conDataBase.Open();
                command = new MySqlCommand(sql, conDataBase);
                dbReader = command.ExecuteReader();

                double currentTemp = 0;
                double currentHygro = 0;
                DateTime dt = DateTime.Now;

                while (dbReader.Read())     
                {
                    currentTemp = dbReader.GetDouble(Properties.Settings.Default.DbTempValProp);
                    currentHygro = dbReader.GetDouble(Properties.Settings.Default.DbHumValProp);
                    dt = dbReader.GetDateTime(Properties.Settings.Default.CreatedAtProp);
                }

                conDataBase.Close();
                e.Result = this;
            }
            catch (Exception ex)
            {
                // at least we need to check if the host is not available: otherwise app crashes
                Helpers.ShowError(ex.Message, "0003_BgwSsf");
            }
            finally { conDataBase.Close(); }
        }

        private void sensorWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void sensorWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void sensorTimer_Tick(object sender, EventArgs e)
        {
            runBackgroundWorker();
        }

        private void runBackgroundWorker()
        {

        }
    }
}
