using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WeatherStation2023
{
    public partial class ColorValues : Form
    {
        List<Sensor> sensors;
        MappingForm mappingForm;

        public ColorValues(List<Sensor> sens)
        {
            InitializeComponent();

            initSensors(sens);

            checkUserSettings();

            loadFilesToSpeciesComboBox();
        }

        private void checkUserSettings()
        {
            if (Properties.Settings.Default.MinColor == -1)
            {
                minColorDialog.Color = Color.DarkBlue;
                Properties.Settings.Default.MinColor = Color.DarkBlue.ToArgb();
            }
            else
            {
               minColorDialog.Color = Helpers.GetColorFromInt(Properties.Settings.Default.MinColor);
            }
            if (Properties.Settings.Default.NormColor == -1)
            {
                normColorDialog.Color = Color.LimeGreen;
                Properties.Settings.Default.NormColor = Color.LimeGreen.ToArgb();
            }
            else
            {
                normColorDialog.Color = Helpers.GetColorFromInt(Properties.Settings.Default.NormColor);
            }
            if (Properties.Settings.Default.MaxColor == -1)
            {
                maxColorDialog.Color = Color.DarkRed;
                Properties.Settings.Default.MaxColor = Color.DarkRed.ToArgb();
            }
            else
            {
                maxColorDialog.Color = Helpers.GetColorFromInt(Properties.Settings.Default.MaxColor);
            }
            minColorPanel.BackColor = Helpers.GetColorFromInt(Properties.Settings.Default.MinColor);
            normColorPanel.BackColor = Helpers.GetColorFromInt(Properties.Settings.Default.NormColor);
            maxColorPanel.BackColor = Helpers.GetColorFromInt(Properties.Settings.Default.MaxColor);

            if (Properties.Settings.Default.SaveLocation != "")
            {
               locationLabel.Text = Properties.Settings.Default.SaveLocation;
            }

            if (!Properties.Settings.Default.ShowToolbar)
            {
                mappingToolStrip.Visible = Properties.Settings.Default.ShowToolbar;
            }
        }

        private void initSensors(List<Sensor> sens)
        {
            sensors = sens;
        }

        /// <summary>
        /// Simple parser to load the self-generated files.
        /// Not bulletproof against user changes.
        /// </summary>
        private void load(string filename = "")
        {
            string line;
            string file = "";
            try
            {
                if (filename != "")
                {
                    file = filename;
                }
                else
                {
                    if (openTxtFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        file = openTxtFileDialog.FileName;
                    }
                }
                if (file != "")
                {
                    StreamReader sr = new StreamReader(file);
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
                            if (line.StartsWith("#") && count == 2)
                            {
                                commentRTB.Text = line;
                            }
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
                                if (!speciesComboBox.Items.Contains(line))
                                    speciesComboBox.Items.Add(line);
                                speciesComboBox.SelectedItem = line;
                            }
                            // Min Temp
                            if (count == 4)
                            {
                                minTempRTB.Text = line;
                            }
                            // Max Temp
                            if (count == 5)
                            {
                                maxTempRTB.Text = line;
                            }
                            // Min Humidity
                            if (count == 6)
                            {
                                minHumRTB.Text = line;
                            }
                            // Max Humidity
                            if (count == 7)
                            {
                                maxHumRTB.Text = line;
                            }
                            //Read the next line
                            count++;
                            line = sr.ReadLine();
                        }
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load();
        }
        private void loadTSB_Click(object sender, EventArgs e)
        {
            load();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }
        private void saveTSB_Click(object sender, EventArgs e)
        {
            save();
        }

        /// <summary>
        /// Create a simple TXT-files with temperature and humidity warnings.
        /// </summary>
        private void save()
        {
            if (Properties.Settings.Default.SaveLocation != "")
            {
                saveTxtFileDialog.InitialDirectory = Properties.Settings.Default.SaveLocation;
            }
            saveTxtFileDialog.Title = "Save TXT file with sensor settings...";
            if (saveTxtFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Write TXT file
                    StreamWriter sw = new StreamWriter(saveTxtFileDialog.FileName);
                    sw.WriteLine("[antconfig 1.0]");       // this is essential for a working file format

                    if (commentRTB.Text != "") { sw.WriteLine("# " + commentRTB.Text); } else { sw.WriteLine(""); }
                    if (speciesComboBox.Text != "") { sw.WriteLine(speciesComboBox.Text); } else { sw.WriteLine(""); }
                    if (minTempRTB.Text != "") { sw.WriteLine(minTempRTB.Text); } else { sw.WriteLine(""); }
                    if (maxTempRTB.Text != "") { sw.WriteLine(maxTempRTB.Text); } else { sw.WriteLine(""); }
                    if (minHumRTB.Text != "") { sw.WriteLine(minHumRTB.Text); } else { sw.WriteLine(""); }
                    if (maxHumRTB.Text != "") { sw.WriteLine(maxHumRTB.Text); } else { sw.WriteLine(""); }
                    //Close the file
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.Message);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void changeMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minColorDialog.Color = Helpers.GetColorFromInt(Properties.Settings.Default.MinColor);
            if (minColorDialog.ShowDialog() == DialogResult.OK)
            {
                minColorPanel.BackColor = minColorDialog.Color;
                Properties.Settings.Default.MinColor = minColorDialog.Color.ToArgb();
            }
        }

        private void changeNORMColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            normColorDialog.Color = Helpers.GetColorFromInt(Properties.Settings.Default.NormColor);
            if (normColorDialog.ShowDialog() == DialogResult.OK)
            {
                normColorPanel.BackColor = normColorDialog.Color;
                Properties.Settings.Default.NormColor = normColorDialog.Color.ToArgb();
            }
        }

        private void changeMAXColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maxColorDialog.Color = Helpers.GetColorFromInt(Properties.Settings.Default.MaxColor);
            if (maxColorDialog.ShowDialog() == DialogResult.OK)
            {
                maxColorPanel.BackColor = maxColorDialog.Color;
                Properties.Settings.Default.MaxColor = maxColorDialog.Color.ToArgb();
            }
        }

        private void minTempWarningTrackBar_Scroll(object sender, EventArgs e)
        {
            minTempRTB.Text = minTempWarningTrackBar.Value.ToString();
        }

        private void minHumWarningTrackBar_Scroll(object sender, EventArgs e)
        {
            minHumRTB.Text = minHumWarningTrackBar.Value.ToString();
        }

        private void maxTempWarningTrackBar_Scroll(object sender, EventArgs e)
        {
            maxTempRTB.Text = maxTempWarningTrackBar.Value.ToString();
        }

        private void maxHumWarningTrackBar_Scroll(object sender, EventArgs e)
        {
            maxHumRTB.Text = maxHumWarningTrackBar.Value.ToString();
        }

        private void cdButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SaveLocation != "")
            {
                saveLocationFolderBrowserDialog.SelectedPath = Properties.Settings.Default.SaveLocation;
            }
            if (saveLocationFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                locationLabel.Text = saveLocationFolderBrowserDialog.SelectedPath;
                Properties.Settings.Default.SaveLocation = saveLocationFolderBrowserDialog.SelectedPath;
            }
        }

        private void exitTSB_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minTempRTB_TextChanged(object sender, EventArgs e)
        {
            checkValue(minTempRTB.Text, minTempWarningTrackBar);
        }

        private void maxTempRTB_TextChanged(object sender, EventArgs e)
        {
            checkValue(maxTempRTB.Text, maxTempWarningTrackBar);
        }

        private void minHumRTB_TextChanged(object sender, EventArgs e)
        {
            checkValue(minHumRTB.Text, minHumWarningTrackBar);
        }

        private void maxHumRTB_TextChanged(object sender, EventArgs e)
        {
            checkValue(maxHumRTB.Text, maxHumWarningTrackBar);
        }
        
        /// <summary>
        /// Check text fields for integers before updating the trackbar.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tb"></param>
        private void checkValue(string value, TrackBar tb)
        {
            int numericValue;
            bool isNumber = int.TryParse(value, out numericValue);
            if (isNumber)
            {
                if (numericValue >= tb.Minimum && numericValue <= tb.Maximum)
                {
                    tb.Value = numericValue;
                }
                else
                {
                    MessageBox.Show("Value should be between " + tb.Minimum.ToString() + " and " + tb.Maximum.ToString() + "!");
                }
            }
            else if (value != "") MessageBox.Show("Please enter only integer numbers.");
        }

        private void minTempWarningTrackBar_ValueChanged(object sender, EventArgs e)
        {
            minTempRTB.Text = minTempWarningTrackBar.Value.ToString();
        }

        private void maxTempWarningTrackBar_ValueChanged(object sender, EventArgs e)
        {
            maxTempRTB.Text = maxTempWarningTrackBar.Value.ToString();
        }

        private void minHumWarningTrackBar_ValueChanged(object sender, EventArgs e)
        {
            minHumRTB.Text = minHumWarningTrackBar.Value.ToString();
        }

        private void maxHumWarningTrackBar_ValueChanged(object sender, EventArgs e)
        {
            maxHumRTB.Text = maxHumWarningTrackBar.Value.ToString();
        }

        private void mapFilesToSensorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mappingForm = new MappingForm(sensors);
            mappingForm.MdiParent = this.ParentForm;
            mappingForm.StartPosition = FormStartPosition.CenterParent;
            mappingForm.FormClosed += new FormClosedEventHandler(MappingForm_FormClosed);
            mappingForm.ShowDialog();
        }

        private void MappingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void speciesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speciesComboBox.Text != "")
            {
                load(Properties.Settings.Default.SaveLocation + "\\" + speciesComboBox.Text + ".txt");
            }
        }

        /// <summary>
        /// Initialize species combobox.
        /// </summary>
        private void loadFilesToSpeciesComboBox()
        {
            try
            {
                if (Properties.Settings.Default.SaveLocation != "")
                {
                    System.IO.DirectoryInfo ParentDirectory = new System.IO.DirectoryInfo(Properties.Settings.Default.SaveLocation);

                    foreach (System.IO.FileInfo f in ParentDirectory.GetFiles())
                    {
                        if (f.Name.Contains(".txt"))
                        {
                            speciesComboBox.Items.Add(Path.GetFileNameWithoutExtension(f.Name));
                        }                      
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
