using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WeatherStation2023
{
    public partial class MappingForm : Form
    {
        List<Sensor> sensors;
        List<MappingGroupBox> mappingGroups;
        string mypath;

        public MappingForm(List<Sensor> sens)
        {
            InitializeComponent();

            mypath = Properties.Settings.Default.SaveLocation + "\\" + "sensors.cfg";

            initSensors(sens);

            if (!Properties.Settings.Default.ShowToolbar)
            {
                mappingToolStrip.Visible= false;
            }
        }

        #region Application Settings: position, size and name
        //https://www.codeproject.com/Tips/543631/Save-and-restore-your-form-size-and-location
        /// <summary>
        /// Load Application Settings during startup. Hold "Shift"-key for applicaton default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MappingForm_Load(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) == 0)
            {
                string initLocation = Properties.Settings.Default.MappingLocation;
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
        private void MappingForm_FormClosing(object sender, FormClosingEventArgs e)
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
                Properties.Settings.Default.MappingLocation = initLocation;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
        }
        #endregion

        private void initSensors(List<Sensor> sens)
        {
            sensors = sens;

            mappingGroups = new List<MappingGroupBox>();

            if (sensors != null)
            {
                for (int i = 0; i < sensors.Count; i++)
                {
                    Sensor s = sensors[i];
                    var customGroupBox = new MappingGroupBox
                    {
                        Text = sensors[i].PublicLabel,
                        Width = flowLayoutPanel.Width - SystemInformation.VerticalScrollBarWidth,
                        Padding = new Padding(),
                        Margin = new Padding(),
                    };
                    s.AliasLabel = customGroupBox.AliasLabel;
                    s.FilenameLabel = customGroupBox.FilenameLabel;
                    flowLayoutPanel.Controls.Add(customGroupBox);
                    mappingGroups.Add(customGroupBox);
                }
            }

            if (File.Exists(mypath))
            {
                load();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitTSB_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadTSB_Click(object sender, EventArgs e)
        {
            load();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load();
        }
        
        /// <summary>
        /// Load Configuration file. There is only one file, constant file name: sensors.cfg
        /// </summary>
        private void load()
        {
            string line;
            List<String> listStrLineElements;
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
                            listStrLineElements = line.Split('\t').ToList();
                            mappingGroups[count].AliasLabel.Text = listStrLineElements[1];
                            mappingGroups[count].FilenameLabel.Text = listStrLineElements[2];

                            count++;
                        }
                        else { line = sr.ReadLine(); continue; }

                        line = sr.ReadLine();
                    }
                    sr.Close();
                    toolStripStatusLabel.Text = "Configuration loaded";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void saveTSB_Click(object sender, EventArgs e)
        {
            save();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }
        
        /// <summary>
        /// Save Configuration file. There is only one file, constant file name: sensors.cfg
        /// </summary>
        private void save()
        {
            try
            {
                // Write CFG file
                StreamWriter sw = new StreamWriter(mypath);
                sw.WriteLine("[antconfig 1.0]");       // this is essential for a working file format
                foreach (MappingGroupBox mgb in mappingGroups) 
                { 
                    sw.WriteLine(mgb.Text + "\t" + mgb.AliasLabel.Text + "\t" + mgb.FilenameLabel.Text);
                }

                //Close the file
                sw.Close();
                toolStripStatusLabel.Text = "Configuration saved";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
    }
}
