using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WeatherStation2023
{
    public class Sensor
    {
        // These could be private, but I set them up as properties.
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PublicLabel { get; set; }
        public RichTextBox AliasLabel { get; set; }
        public string Alias { get; set; }
        public string Filename { get; set; }
        public Label FilenameLabel { get; set; }

        // Variables for the min/max coloring
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set; }
        public int MinHumidity { get; set; }
        public int MaxHumidity { get; set; }

        // Labels from the MainForm - these are updated in RunWorkerCompleted
        public Label TempLabel { get; set; }
        public Label HumidityLabel { get; set; }
        public Label TimeLabel { get; set; }

        public BackgroundWorker MyBackgroundWorker;

        private int sensorID;

        public int ID { get { return sensorID; } }

        // Database variables.
        MySqlConnection conDataBase;
        MySqlDataReader dbReader;
        MySqlCommand command;
        private string sql;
        string connectionString;

        /// <summary>
        /// Constructor of the Sensor.
        /// </summary>
        /// <param name="sensor">The Pin to which the sensor is connected to the Raspberry Pi.</param>
        public Sensor(int sensor)
        {
            sensorID = sensor;

            sql = "SELECT * FROM " + Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + " WHERE " +
            Properties.Settings.Default.IdProp + " = (SELECT MAX(" + Properties.Settings.Default.IdProp + ") FROM " +
            Properties.Settings.Default.DbProp + "." + Properties.Settings.Default.DbTableProp + " WHERE " +
            Properties.Settings.Default.DbSensValProp + " = " + sensorID.ToString() + ");";

            connectionString = "server=" + Properties.Settings.Default.HostProp + "; " +
                    "port=" + Properties.Settings.Default.PortProp.ToString() + "; " +
                    "username='" + Properties.Settings.Default.UserProp + "'; " +
                    "password='" + Properties.Settings.Default.PassProp + "'; " +
                    "database='" + Properties.Settings.Default.DbProp + "'; ";

            conDataBase = new MySqlConnection(connectionString);

            PublicLabel = "Sensor " + sensorID.ToString();

            MyBackgroundWorker = new BackgroundWorker();

            InitializeBackgroundWorker();
        }

        // Set up the BackgroundWorker object by 
        // attaching event handlers. 
        private void InitializeBackgroundWorker()
        {

            MyBackgroundWorker.DoWork +=
                new DoWorkEventHandler(backgroundWorker_DoWork);
            MyBackgroundWorker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker_RunWorkerCompleted);

            // We don't use ProgressChanged as we're only fetching one row from the database.
            /*myBackgroundWorker.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker_ProgressChanged);*/
        }

        /// <summary>
        /// DoWork of the background worker. Makes DB-query.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_DoWork(object sender,
            DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            //BackgroundWorker worker = sender as BackgroundWorker;

            try
            {
                conDataBase.Open();
                command = new MySqlCommand(sql, conDataBase);
                dbReader = command.ExecuteReader();

                double currentTemp = 0;
                double currentHygro = 0;

                while (dbReader.Read())     // we get only one row, but still use a while loop here
                {
                    currentTemp = dbReader.GetDouble(Properties.Settings.Default.DbTempValProp);
                    currentHygro = dbReader.GetDouble(Properties.Settings.Default.DbHumValProp);

                    TimeStamp = dbReader.GetDateTime(Properties.Settings.Default.CreatedAtProp);
                }
                conDataBase.Close();

                if (currentTemp < MinTemperature)
                {
                    TempLabel.ForeColor = Helpers.GetColorFromInt(Properties.Settings.Default.MinColor);
                }
                else if (currentTemp > MaxTemperature)
                {
                    TempLabel.ForeColor = Helpers.GetColorFromInt(Properties.Settings.Default.MaxColor);
                }
                else
                {
                    TempLabel.ForeColor = Helpers.GetColorFromInt(Properties.Settings.Default.NormColor);
                }
                Temperature = string.Format("{0:N2}", currentTemp) + "°C";

                if (currentHygro < MinHumidity)
                {
                    HumidityLabel.ForeColor = Helpers.GetColorFromInt(Properties.Settings.Default.MinColor);
                }
                else if (currentHygro > MaxHumidity)
                {
                    HumidityLabel.ForeColor = Helpers.GetColorFromInt(Properties.Settings.Default.MaxColor);
                }
                else
                {
                    HumidityLabel.ForeColor = Helpers.GetColorFromInt(Properties.Settings.Default.NormColor);
                }
                Humidity = string.Format("{0:N2}", currentHygro) + "%";               

                e.Result = this;
            }
            catch (Exception ex)
            {
                // at least we need to check if the host is not available: currently app crashes
                Helpers.ShowError(ex.Message, "0002_BgwSen-" + ID.ToString());
            }
            finally { conDataBase.Close(); }
        }

        /// <summary>
        /// When the background worker completed its task, the UI is updated.
        /// </summary>     
        private void backgroundWorker_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            TempLabel.Text = Temperature;
            HumidityLabel.Text = Humidity;
            DateTime dt = DateTime.Now;
            TimeSpan ts = dt.Subtract(TimeStamp);
            if (ts.TotalMinutes > 30)
            {
                TimeLabel.ForeColor = Helpers.GetColorFromInt(Properties.Settings.Default.MaxColor);
                TimeLabel.Text = "Outdated!";
            }
            else
            {
                TimeLabel.ForeColor = Helpers.GetColorFromInt(Properties.Settings.Default.NormColor);
                TimeLabel.Text = TimeStamp.ToString("HH:mm:ss");
            }
        }
    }
}

