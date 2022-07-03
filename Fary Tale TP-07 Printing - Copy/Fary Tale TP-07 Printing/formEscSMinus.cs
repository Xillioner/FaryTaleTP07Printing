using Fary_Tale_TP_07_Printing;
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
    public partial class formEscSMinus : Form
    {
        public formEscSMinus()
        {
            InitializeComponent();
            
            
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (radioButtonTurnOnUnderline1Dot1.Checked)
            {
                MainWindow.formEscsMinusRadioResult = radioButtonTurnOnUnderline1Dot1.Text;
            }
            if (radioButtonTurnOffUnderline1.Checked)
            {
                MainWindow.formEscsMinusRadioResult = radioButtonTurnOffUnderline1.Text;
            }
            if (radioButtonTurnOffUnderline2.Checked)
            {
                MainWindow.formEscsMinusRadioResult = radioButtonTurnOffUnderline2.Text;
            }
            if (radioButtonTurnOnUnderline1Dot2.Checked)
            {
                MainWindow.formEscsMinusRadioResult = radioButtonTurnOnUnderline1Dot2.Text;
            }
            if (radioButtonTurnOnUnderline2Dot1.Checked)
            {
                MainWindow.formEscsMinusRadioResult = radioButtonTurnOnUnderline2Dot1.Text;
            }
            if (radioButtonTurnOnUnderline2Dot2.Checked)
            {
                MainWindow.formEscsMinusRadioResult = radioButtonTurnOnUnderline2Dot2.Text;
            }
            this.Close();
            
        }

        private void formEscSMinus_Load(object sender, EventArgs e)
        {

        }

        private void radioButtonTurnOnUnderline1Dot1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTurnOnUnderline1Dot1.Checked == true)
            {
                radioButtonTurnOffUnderline1.Checked = false;
                radioButtonTurnOffUnderline2.Checked = false;
                radioButtonTurnOnUnderline2Dot1.Checked = false;
                radioButtonTurnOnUnderline2Dot2.Checked = false;
            }
        }

        private void radioButtonTurnOnUnderline2Dot1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTurnOnUnderline2Dot1.Checked == true)
            {
                radioButtonTurnOffUnderline1.Checked = false;
                radioButtonTurnOffUnderline2.Checked = false;
                radioButtonTurnOnUnderline1Dot1.Checked = false;
                radioButtonTurnOnUnderline1Dot2.Checked = false;
            }
        }

        private void radioButtonTurnOnUnderline1Dot2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTurnOnUnderline1Dot2.Checked == true)
            {
                radioButtonTurnOffUnderline1.Checked = false;
                radioButtonTurnOffUnderline2.Checked = false;
                radioButtonTurnOnUnderline2Dot1.Checked = false;
                radioButtonTurnOnUnderline2Dot2.Checked = false;
            }
        }

        private void radioButtonTurnOnUnderline2Dot2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTurnOnUnderline2Dot2.Checked == true)
            {
                radioButtonTurnOffUnderline1.Checked = false;
                radioButtonTurnOffUnderline2.Checked = false;
                radioButtonTurnOnUnderline1Dot1.Checked = false;
                radioButtonTurnOnUnderline1Dot2.Checked = false;
            }
        }

        private void radioButtonTurnOffUnderline1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTurnOffUnderline1.Checked == true)
            {
                radioButtonTurnOnUnderline2Dot1.Checked = false;
                radioButtonTurnOnUnderline2Dot2.Checked = false;
                radioButtonTurnOnUnderline1Dot1.Checked = false;
                radioButtonTurnOnUnderline1Dot2.Checked = false;
            }
        }

        private void radioButtonTurnOffUnderline2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTurnOffUnderline2.Checked == true)
            {
                radioButtonTurnOnUnderline2Dot1.Checked = false;
                radioButtonTurnOnUnderline2Dot2.Checked = false;
                radioButtonTurnOnUnderline1Dot1.Checked = false;
                radioButtonTurnOnUnderline1Dot2.Checked = false;
            }
        }
    }
}
