using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fary_Tale_TP_07_Printing;

namespace Fary_Tale_TP07_Printing
{
    public partial class FormESC3 : Form
    {
        public FormESC3()
        {
            InitializeComponent();
            label2.Text = "34";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            MainWindow.varAfterPressOKint = trackBar1.Value;
            this.Close();
        }
    }
}
