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
    public partial class FormWithScrollBarESCs8 : Form
    {
        public static int varK;
        public static string varAfterPressOK;
        
        public FormWithScrollBarESCs8()
        {
            InitializeComponent();
            label1.Text = "nL=0";
            label2.Text = "nH=0";
            label3.Text = "d=0";
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = String.Format("nL={0}", hScrollBar1.Value.ToString());
            findTheVarK();

        }

        private void findTheVarK()
        {

            
            if (radioButton1.Checked == true || radioButton2.Checked == true)
            {
                //k = nL + 256 * nH
                varK = hScrollBar1.Value + 256 * hScrollBar2.Value;
                label4.Text = String.Format("k={0}", varK.ToString());
            }


            if (radioButton3.Checked == true || radioButton4.Checked == true)
            {
                //k = (nL + 256 * nH)*3
                varK = (hScrollBar1.Value + 256 * hScrollBar2.Value) * 3;
                label4.Text = String.Format("k={0}", varK.ToString());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            findTheVarK();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = String.Format("nH={0}", hScrollBar2.Value.ToString());
            findTheVarK();
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            label3.Text = String.Format("d={0}", hScrollBar3.Value.ToString());
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            findTheVarK();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            findTheVarK();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            findTheVarK();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int varM=0;
            if (radioButton1.Checked==true)varM=0;
            if (radioButton2.Checked == true) varM = 1;
            if (radioButton3.Checked == true) varM = 32;
            if (radioButton4.Checked==true) varM = 33;

            varAfterPressOK = String.Format("\x1B\x2A" + "{0}{1}{2}{3}{4}",(char)varM,(char)hScrollBar1.Value,(char)hScrollBar2.Value,(char)hScrollBar3.Value,(char)varK);
            //varAfterPressOK = "";
            this.Close();
            
        }
    }
}
