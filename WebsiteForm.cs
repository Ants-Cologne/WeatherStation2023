using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherStation2023
{
    public partial class WebsiteForm : Form
    {
        public WebsiteForm()
        {
            InitializeComponent();

            enableCheckBox.Checked = Properties.Settings.Default.UseWebserver;

            checkProtocol();

            checkURL();

            helpRichTextBox.Text = "Please check chapters 10.1.7 of the Help File to install a webserver. Use the script provided in chapter 11.4 "
                + "as index.php to run in the webserver's root or change as needed. Press \"Test\" to check the URL. If you operating system starts "
                + "your default web browser with the correct URL, the test was successfull. This form can now be closed and the new settings will "
                + "automatically be applied.";
        }

        #region Application Settings: position, size and name
        //https://www.codeproject.com/Tips/543631/Save-and-restore-your-form-size-and-location
        /// <summary>
        /// Load Application Settings during startup. Hold "Shift"-key for applicaton default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebsiteForm_Load(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) == 0)
            {
                string initLocation = Properties.Settings.Default.WebserverLocation;
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
        private void WebsiteForm_FormClosing(object sender, FormClosingEventArgs e)
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
                Properties.Settings.Default.WebserverLocation = initLocation;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }

            if (enableCheckBox.Checked)
            {
                if (protocolComboBox.Text != "" && urlTextBox.Text != "")
                {
                    Properties.Settings.Default.WebserverURL = protocolComboBox.Text + urlTextBox.Text;
                }
            }
        }
        #endregion

        private void checkProtocol()
        {
            if (Properties.Settings.Default.WebserverURL != "")
            {
                if (Properties.Settings.Default.WebserverURL.StartsWith("http://"))
                {
                    protocolComboBox.SelectedIndex = 0;
                }
                else if (Properties.Settings.Default.WebserverURL.StartsWith("https://"))
                {
                    protocolComboBox.SelectedIndex = 1;
                }
            }
            else
            {
                protocolComboBox.SelectedIndex = 0;
            }
        }

        private void checkURL()
        {
            if (Properties.Settings.Default.WebserverURL != "")
            {
                if (Properties.Settings.Default.WebserverURL.StartsWith("http://"))
                {
                    urlTextBox.Text = Properties.Settings.Default.WebserverURL.Remove(0, 7);
                    protocolComboBox.SelectedIndex = 0;
                }
                else if (Properties.Settings.Default.WebserverURL.StartsWith("https://"))
                {
                    urlTextBox.Text = Properties.Settings.Default.WebserverURL.Remove(0, 8);
                    protocolComboBox.SelectedIndex = 1;
                }
            }
        }

        private void enableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableCheckBox.Checked == true)
            {
                Properties.Settings.Default.UseWebserver = true;
            }
            else
            {
                Properties.Settings.Default.UseWebserver = false;
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (protocolComboBox.Text != "" && urlTextBox.Text != "")
                {
                    System.Diagnostics.Process.Start(protocolComboBox.Text + urlTextBox.Text);
                }
                
            }
            catch (Exception ex)
            {
                Helpers.ShowError("Website could not be loaded! " + ex.Message, "0018_wwwerr");
            }
        }
    }
}
