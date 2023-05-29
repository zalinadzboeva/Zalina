using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zalina
{
    internal class TeachBox
    {
        public Panel Panel { get; set; }
        public PictureBox Image { get; set; }
        public string ImageUrl { get; set; }
        public bool IsGreen { get; set; } = false;
    }
}
