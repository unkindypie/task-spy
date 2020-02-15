using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskSpyAdminPanel
{
    public class ColorPalette
    {
        public static Color Dark
        {
            get; set;
        }
        public static Color LightDark
        {
            get; set;
        }
        public static Color Light
        {
            get; set;
        }
        public static Color FontColor
        {
            get; set;
        }
        static ColorPalette()
        {
            Dark = Color.FromArgb(28, 28, 28);
            LightDark = Color.FromArgb(37, 37, 38);
            Light = Color.FromArgb(45, 45, 48);
            FontColor = Color.WhiteSmoke;
           
        }
    }
}
