using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherStation2023
{
    public class Helpers
    {
        public static Color GetColorFromInt(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            return Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]);
        }

        #region MessageBox-Aliases
        public static void ShowError(string message, string errorcode)
        {
            ShowMessageDialog(message, "Error: " + errorcode, Type.Error);
        }

        public static void ShowInfo(string message, string title)
        {
            ShowMessageDialog(message, title, Type.Info);
        }

        public static void ShowWarning(string message, string title)
        {
            ShowMessageDialog(message, title, Type.Warn);
        }

        public enum Type { Info, Warn, Error } 

        public static void ShowMessageDialog(string message, string title, Type type)
        {
            switch (type)
            {
                case Type.Info:
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Type.Warn:
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case Type.Error:
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
