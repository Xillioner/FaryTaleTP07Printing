using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fary_Tale_TP07_Printing
{
    public partial class FormESCsQUESTIONSIGN : Form
    {
        public FormESCsQUESTIONSIGN()
        {
            InitializeComponent();
            label2.Text = "32";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }
    }
}
