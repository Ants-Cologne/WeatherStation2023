using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WeatherStation2023
{
    public partial class SensorGroupBox : UserControl
    {
        public SensorGroupBox() => InitializeComponent();
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if ((Parent != null) && !DesignMode)
            {
                Parent.SizeChanged += OnParentSizeChanged;
            }
        }
        private void OnParentSizeChanged(object sender, EventArgs e)
        {
            if (sender is FlowLayoutPanel flowLayoutPanel)
            {
                Debug.WriteLine($"{flowLayoutPanel.Width}");
                Width =
                    flowLayoutPanel.Width -
                    SystemInformation.VerticalScrollBarWidth;
            }
        }
        public new string Text
        {
            get => groupBox.Text;
            set => groupBox.Text = value;
        }
        public Label TemperatureLabel
        {
            get => tempLabel;
        }
        public Label HumidityLabel
        {
            get => humLabel;
        }
        public Label TimeStampLabel
        {
            get => timeLabel;
        }
    }
}
