using System.Windows.Forms;

namespace WeatherStation2023
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
            this.Text = "About " + Properties.Settings.Default.ApplicationName;

            infoRichTextBox.Text = "Weather Station 2023 - previously (2021) Ant Station 1.0 \n\n" +
                "Youtoube Playlist (German): https://www.youtube.com/watch?v=VK3Pj76e1gA&list=PLdIR8q_1oO5Du9xklO7tYyTcq_UK8M4-j \n\n" +
                "During this project I soldered a circuit board with five sensors, in my case DHT22 sensors that can measure temperature and humidity. " +
                "But any sensor with 3 lines (plus, data, ground) should work. The circuit board is connected to a Raspberry Pi that writes the sensor data to a " +
                "MariaDB database via CronJob every 10 minutes.\nThe goal of this desktop application is to query this database and to display its data. " +
                "\n\n\n" +
                "© Dipl.-Biol. Björn Zedroßer 2021-23";
        }

        private void infoRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
