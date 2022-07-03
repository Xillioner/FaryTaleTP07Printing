using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Fary_Tale_TP_07_Printing
{
    public partial class FormGSVmn : Form
    {
        public FormGSVmn()
        {
            InitializeComponent();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true) 
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            
            int varRadioButtonValue;
            int varTrackBarValue;

            if (radioButton4.Checked == true)
            {
                if (radioButton1.Checked==true){
                    varRadioButtonValue=Convert.ToInt16(radioButton1.Text);

                    MainWindow.varformGSVmn = String.Format("\x1D\x56{0}", (char)varRadioButtonValue);
                }
                if (radioButton2.Checked == true)
                {
                    varRadioButtonValue = Convert.ToInt16(radioButton2.Text);

                    MainWindow.varformGSVmn = String.Format("\x1D\x56{0}", (char)varRadioButtonValue);
                }
                MainWindow.answerAfterFormGSVmnToLabel = "Режим резки - Полный отрез";
            }
            if (radioButton5.Checked == true) 
            {
                varRadioButtonValue = Convert.ToInt16(radioButton3.Text);
                varTrackBarValue = trackBar1.Value;
                MainWindow.varformGSVmn = string.Format("\x1D\x56{0}{1}", (char)varRadioButtonValue, (char)varTrackBarValue);
                MainWindow.answerAfterFormGSVmnToLabel = "Режим резки - Промотать вперёд и отрезать";
            }
            
            this.Close();
        }
    }
}
