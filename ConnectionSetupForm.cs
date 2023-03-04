using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WeatherStation2023
{
    public partial class ConnectionSetupForm : Form
    {
        public ConnectionSetupForm()
        {
            InitializeComponent();

            appNameTB.Text = Properties.Settings.Default.ApplicationName;
            userTB.Text = Properties.Settings.Default.UserProp;
            passwordTB.Text = Properties.Settings.Default.PassProp;
            hostTB.Text = Properties.Settings.Default.HostProp;
            portTB.Text = Properties.Settings.Default.PortProp.ToString();
            databaseTB.Text = Properties.Settings.Default.DbProp;
            tableTB.Text = Properties.Settings.Default.DbTableProp;
            tempColTB.Text = Properties.Settings.Default.DbTempValProp;
            humidityColTB.Text = Properties.Settings.Default.DbHumValProp;
            sensorColTB.Text = Properties.Settings.Default.DbSensValProp;
            createdAtColTB.Text = Properties.Settings.Default.CreatedAtProp;
            IdColTB.Text = Properties.Settings.Default.IdProp;
            sensorsTB.Text = Properties.Settings.Default.CountSensorProp;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ApplicationName = appNameTB.Text;
            Properties.Settings.Default.UserProp = userTB.Text;
            Properties.Settings.Default.PassProp = passwordTB.Text;
            Properties.Settings.Default.HostProp = hostTB.Text;
            Properties.Settings.Default.PortProp = Convert.ToInt32(portTB.Text);
            Properties.Settings.Default.DbProp = databaseTB.Text;
            Properties.Settings.Default.DbTableProp = tableTB.Text;
            Properties.Settings.Default.DbTempValProp = tempColTB.Text;
            Properties.Settings.Default.DbHumValProp = humidityColTB.Text;
            Properties.Settings.Default.DbSensValProp = sensorColTB.Text;
            Properties.Settings.Default.CreatedAtProp = createdAtColTB.Text;
            Properties.Settings.Default.IdProp = IdColTB.Text;
            Properties.Settings.Default.CountSensorProp = sensorsTB.Text;
            
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ConnectionSetupForm
            // 
            this.ClientSize = new System.Drawing.Size(338, 306);
            this.Name = "ConnectionSetupForm";
            this.ResumeLayout(false);

        }*/
    }
}
