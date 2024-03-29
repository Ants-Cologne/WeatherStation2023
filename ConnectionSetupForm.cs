﻿using System;
using System.Windows.Forms;

namespace WeatherStation2023
{
    public partial class ConnectionSetupForm : Form
    {
        public Helpers.ResultCode Result;

        public ConnectionSetupForm()
        {
            InitializeComponent();
            Result = Helpers.ResultCode.None;

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

            Result = Helpers.ResultCode.Ok;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Result = Helpers.ResultCode.Cancel;
            Close();
        }
    }
}
