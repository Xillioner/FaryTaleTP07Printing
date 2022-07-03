using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using LibUsbDotNet;
using Fary_Tale_TP07_Printing;

namespace Fary_Tale_TP_07_Printing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public static int countPipeReset = 0;
        public static string formEscsMinusRadioResult;
        public static string varformGSVmn = "\x1D\x56\x00";
        public static string answerAfterFormGSVmnToLabel="Режим резки - Полный отрез";
        public static int varAfterPressOKint;
        
        string codePage;
        string sResult;
        int numberCodePageSelect = 0;
        string sTransmitStatus;
        public MainWindow()
        {
            
            //FindDeviceTP07.FDTP07();// - разблокировать
            InitializeComponent();
            FindDeviceTP07.FDTP07();
            
            
//textBox1.Text = "----------------------------------------\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-\r\n-";
            /*
             * разблокировать
            Thread ThR = new Thread(() =>
                SendText.ST(textBox1));

            ThR.Start();
            */ 

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            exitFuncion();
            Close();

                // Wait for user input..
                //Console.ReadKey();
            }

        private void exitFuncion()
        {
            //throw new NotImplementedException();
            if (FindDeviceTP07.MyTp07 != null)
            {
                if (FindDeviceTP07.MyTp07.IsOpen)
                {
                    // If this is a "whole" usb device (libusb-win32, linux libusb-1.0)
                    // it exposes an IUsbDevice interface. If not (WinUSB) the 
                    // 'wholeUsbDevice' variable will be null indicating this is 
                    // an interface of a device; it does not require or support 
                    // configuration and interface selection.
                    IUsbDevice wholeUsbDevice = FindDeviceTP07.MyTp07 as IUsbDevice;
                    if (!ReferenceEquals(wholeUsbDevice, null))
                    {
                        // Release interface #0.
                        wholeUsbDevice.ReleaseInterface(0);
                    }

                    FindDeviceTP07.MyTp07.Close();
                }
                FindDeviceTP07.MyTp07 = null;

                // Free usb resources
                UsbDevice.Exit();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            exitFuncion();
        }

        private void buttonESCs2_Click(object sender, RoutedEventArgs e)
        {
            
            //TextBox TextBox1=null;
            string message1 = "\x1B\x40";//esc инициализация принтера
            //textBox1.Text += "\x1B\x40";

            sResult = ReadWriteHandler.RWH(message1, textBox1);
        }

        private void buttonGSA_Click(object sender, RoutedEventArgs e)
        {
            
            //TextBox TextBox1=null;
            string message1 = "\x1D\x28\x41\x02\x00\x02\x02";//esc 

            sResult = ReadWriteHandler.RWH(message1, textBox1);
        }

        private void buttonGSI_Click(object sender, RoutedEventArgs e)
        {
            
            //TextBox TextBox1=null;
            string message1 = "\x1D\x49\x01";//esc инициализация принтера

            sResult = ReadWriteHandler.RWH(message1, textBox1);
        }

        private void buttonHT_Click(object sender, RoutedEventArgs e)
        {
            
            
            string message1 = "\x09";//горизонтальная табуляция
            textBox1.Text += "1\"\x09\"2 - горизонтальная табуляция\r\n";

            //sResult = ReadWriteHandler.RWH(message1, textBox1);
        }

        private void buttonLF_Click(object sender, RoutedEventArgs e)
        {
            

            string message1 = "\x0A";//Печать и переходна линию
            textBox1.Text += "1\"\x0A\"2 - печать и переход на линию\r\n";

            //sResult = ReadWriteHandler.RWH(message1, textBox1);
        }

        private void buttonFF_Click(object sender, RoutedEventArgs e)
        {
            

            string message1 = "\x0C";//Печать и переход к следующей метке на бумаге
            var fromEncoding = Encoding.GetEncoding(437);
            var bytes = fromEncoding.GetBytes(message1);
            var toEncoding = Encoding.GetEncoding(1251);
            message1 = toEncoding.GetString(bytes);
            textBox1.Text += message1;

            //sResult = ReadWriteHandler.RWH(message1, textBox1);
        }

        private void buttonDLEEOT_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "Выбери из контекстного меню\r\n";
        }

        private void buttonDLEENQ_Click(object sender, RoutedEventArgs e)
        {
            

            string message1 = "\x10\x05\x02";//Запрос настоящего времени принтеру
            //textBox1.Text += "\\x10\\x05\\x02 - Запрос настоящего времени принтеру\r\n";

            sResult = ReadWriteHandler.RWH(message1, textBox1);
        }

        private void buttonESCSP_Click(object sender, RoutedEventArgs e)
        {
            FormESC3 fEsc3 = new FormESC3();
            fEsc3.Text = "ESC SP";
            fEsc3.label1.Text = "Установить расстояние с правой стороны символа";
            fEsc3.trackBar1.Value = 2;
            fEsc3.label2.Text = "2";
            fEsc3.ShowDialog();
            labelRightSideSpacing.Content = String.Format("Отступ справа от символа - {0}",fEsc3.trackBar1.Value.ToString());
            

            string message1 = String.Format("\x1B\x20{0}",(char)varAfterPressOKint);//Установить пробел с правой стороны
            //textBox1.Text += "1\"\x1B\x20\x02\"2 - Установить пробел с правой стороны\r\n";

            sResult = ReadWriteHandler.RWH(message1, textBox1);
        }

        private void buttonESCs4_Click(object sender, RoutedEventArgs e)
        {
            FormEscS4 escS4Form = new FormEscS4();
            escS4Form.ShowDialog();
        }

        private void buttonESCs1_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "Select from the context menu\r\n";
            string message1 = "\x1B\x21\xC8";//Установить режим печати


            sResult = ReadWriteHandler.RWH(message1, textBox1);
        }

        private void buttonESCs5_Click(object sender, RoutedEventArgs e)
        {
            FormEscS5 escS5Form = new FormEscS5();
            escS5Form.ShowDialog();
        }

        private void buttonESCs7_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "Комманда, создай свой собственный символ\r\n";
        }

        private void buttonESCs8_Click(object sender, RoutedEventArgs e)
        {
            
            FormWithScrollBarESCs8 fWSB = new FormWithScrollBarESCs8();
            fWSB.ShowDialog();
            textBox1.Text =String.Format("{0} - выбрать режим битового изображения", FormWithScrollBarESCs8.varAfterPressOK);
        }

        private void buttonESCsMINUS_Click(object sender, RoutedEventArgs e)
        {
            formEscSMinus fESM = new formEscSMinus();
            fESM.ShowDialog();
        }

        private void buttonESC2_Click(object sender, RoutedEventArgs e)
        {
            

            string message1 = "\x1B\x32";//Установить 1/6" пробел
            textBox1.Text += "1\"\x1B\x32\"2 - Установить 1/6\" пробел\r\n";

            //sResult = ReadWriteHandler.RWH(message1, textBox1);
        }

        private void buttonESC3_Click(object sender, RoutedEventArgs e)
        {
            FormESC3 fEsc3 = new FormESC3();
            fEsc3.ShowDialog();
        }

        private void buttonESCsQUESTIONSIGN_Click(object sender, RoutedEventArgs e)
        {
            FormESCsQUESTIONSIGN fEsQS = new FormESCsQUESTIONSIGN();
            fEsQS.ShowDialog();
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            
            string message1 = "";
            message1 = textBox1.Text;
            var fromEncoding = Encoding.GetEncoding(437);
            /////////
            switch (numberCodePageSelect)
            {
                case 0:
                    fromEncoding = Encoding.GetEncoding(437);
                    break;
                case 1:
                    fromEncoding = Encoding.GetEncoding(932);
                    break;
                case 2:
                    fromEncoding = Encoding.GetEncoding(850);
                    break;
                case 3:
                    fromEncoding = Encoding.GetEncoding(860);
                    break;
                case 4:
                    fromEncoding = Encoding.GetEncoding(863);
                    break;
                case 5:
                    fromEncoding = Encoding.GetEncoding(865);
                    break;
                case 16:
                    fromEncoding = Encoding.GetEncoding(1252);
                    break;
                case 17:
                    fromEncoding = Encoding.GetEncoding(866);
                    break;
                case 18:
                    fromEncoding = Encoding.GetEncoding(852);
                    break;
                case 19:
                    fromEncoding = Encoding.GetEncoding(858);
                    break;
                case 255:
                    MessageBox.Show("Здесь нужно сделать загрузку своей кодировки");
                    break;
                default:
                    break;
            }


            
            var bytes = fromEncoding.GetBytes(message1);
            var toEncoding = Encoding.GetEncoding(1251);
            message1 = toEncoding.GetString(bytes);
            /////////
            sResult  = ReadWriteHandler.RWH(message1, textBox1);
            sResult = ReadWriteHandler.RWH("\r\n", textBox1);
            sResult = ReadWriteHandler.RWH(varformGSVmn, textBox1);
            textBox1.Clear();
        }

        private void buttonESCa_Click(object sender, RoutedEventArgs e)
        {
            int varM=0;
            formEscSMinus fEA=new formEscSMinus();
            fEA.groupBox2.Text = "Центровать текст";
            fEA.groupBox1.Text = "Текст слева";
            fEA.groupBox3.Text = "Текст справа";
            fEA.Text = "ESC a";
            fEA.ShowDialog();
            varM=Convert.ToInt16(formEscsMinusRadioResult);
            textBox1.Text += String.Format("\x1B\x61{0}",(char)varM);

        }

        

        private void MenuItemCodeTablePC866_Click(object sender, RoutedEventArgs e)
        {
            numberCodePageSelect = 17;
            codePage= "\x1B\x74\x11";//выбор кодовой страницы
            sResult = ReadWriteHandler.RWH(codePage, textBox1);
        }

        private void buttonGSV_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "\x1D\x56\x30";///выбрать режим обрезки и резки бумаги
        }

        private void menuItemGSVMN_Click(object sender, RoutedEventArgs e)
        {
            FormGSVmn fGSVmn = new FormGSVmn();
            fGSVmn.ShowDialog();
            labelCutMode.Content = answerAfterFormGSVmnToLabel;
        }

        private void MenuItemCodeTablePC437_Click(object sender, RoutedEventArgs e)
        {
            numberCodePageSelect = 0;
            codePage = "\x1B\x74\x00";//выбор кодовой страницы
            sResult = ReadWriteHandler.RWH(codePage, textBox1);
        }

        private void MenuItemCodeTableKatakana_Click(object sender, RoutedEventArgs e)
        {
            numberCodePageSelect = 1;
            codePage = "\x1B\x74\x01";//выбор кодовой страницы
            sResult = ReadWriteHandler.RWH(codePage, textBox1);
        }

        private void MenuItemCodeTablePC850_Click(object sender, RoutedEventArgs e)
        {
            numberCodePageSelect = 2;
            codePage = "\x1B\x74\x02";//выбор кодовой страницы
            sResult = ReadWriteHandler.RWH(codePage, textBox1);
        }

        private void MenuItemCodeTablePC860_Click(object sender, RoutedEventArgs e)
        {
            numberCodePageSelect = 3;
            codePage = "\x1B\x74\x03";//выбор кодовой страницы
            sResult = ReadWriteHandler.RWH(codePage, textBox1);
        }

        private void MenuItemCodeTablePC863_Click(object sender, RoutedEventArgs e)
        {
            numberCodePageSelect = 4;
            codePage = "\x1B\x74\x04";//выбор кодовой страницы
            sResult = ReadWriteHandler.RWH(codePage, textBox1);
        }

        private void MenuItemCodeTablePC865_Click(object sender, RoutedEventArgs e)
        {
            numberCodePageSelect = 5;
            codePage = "\x1B\x74\x05";//выбор кодовой страницы
            sResult = ReadWriteHandler.RWH(codePage, textBox1);
        }

        private void MenuItemCodeTableWPC1252_Click(object sender, RoutedEventArgs e)
        {
            numberCodePageSelect = 16;
            codePage = "\x1B\x74\x10";//выбор кодовой страницы
            sResult = ReadWriteHandler.RWH(codePage, textBox1);
        }

        private void MenuItemCodeTablePC852_Click(object sender, RoutedEventArgs e)
        {
            numberCodePageSelect = 18;
            codePage = "\x1B\x74\x12";//выбор кодовой страницы
            sResult = ReadWriteHandler.RWH(codePage, textBox1);
        }

        private void MenuItemCodeTablePC858_Click(object sender, RoutedEventArgs e)
        {
            numberCodePageSelect = 19;
            codePage = "\x1B\x74\x13";//выбор кодовой страницы
            sResult = ReadWriteHandler.RWH(codePage, textBox1);
        }

        private void MenuItemCodeTableSpacePage_Click(object sender, RoutedEventArgs e)
        {
            numberCodePageSelect = 255;
            codePage = "\x1B\x74\xFF";//выбор кодовой страницы
            sResult = ReadWriteHandler.RWH(codePage, textBox1);
        }

        private void menuItemPrinterStatus_Click(object sender, RoutedEventArgs e)
        {
            
            sTransmitStatus = "\x10\x04\x01";
            sResult = ReadWriteHandler.RWH(sTransmitStatus, textBox1);
            string valueBin=functionGetRealTimePrinterStatus(sResult);

            if (valueBin[3].ToString() == "0")
            {
                textBox1.Text += "On-line / Off-line - On-line\r\n";
            }
            else
            {
                textBox1.Text += "On-line / Off-line - Off-line\r\n";
            }
            if (valueBin[6].ToString() == "0")
            {
                textBox1.Text += "Paper feed button - Off\r\n";
            }
            else
            {
                textBox1.Text += "Paper feed button - On\r\n";
            }
            
        }

        private string functionGetRealTimePrinterStatus(string sResult)
        {
            
            int valueInt;
            string valueBin;
            valueInt = (int)sResult[0];
            valueBin = Convert.ToString(valueInt, 2);


            if (valueBin.Length != 8)
            {
                while (valueBin.Length != 8)
                {
                    valueBin = valueBin.Insert(0, "0");
                }
                
            }
            //переворот строки
            char[] arr = valueBin.ToCharArray();
            Array.Reverse(arr);
            valueBin = new string(arr);
            return valueBin;
        }
        

        

        private void menuItemOffLineStatus_Click(object sender, RoutedEventArgs e)
        {
            sTransmitStatus = "\x10\x04\x02";
            sResult = ReadWriteHandler.RWH(sTransmitStatus, textBox1);
            string valueBin = functionGetRealTimePrinterStatus(sResult);

            if (valueBin[3].ToString() == "0")
            {
                textBox1.Text += "Paper feeding with paper feed button - Except during paper feeding\r\n";
            }
            else
            {
                textBox1.Text += "Paper feeding with paper feed button - During paper feeding\r\n";
            }
            if (valueBin[5].ToString() == "0")
            {
                textBox1.Text += "Printing stop due to a paper end - No paper end stop\r\n";
            }
            else
            {
                textBox1.Text += "Printing stop due to a paper end - Printing stops\r\n";
            }
            if (valueBin[6].ToString() == "0")
            {
                textBox1.Text += "Error - No error\r\n";
            }
            else
            {
                textBox1.Text += "Error - Error occured\r\n";
            }
        }

        private void menuItemErrorStatus_Click(object sender, RoutedEventArgs e)
        {
            sTransmitStatus = "\x10\x04\x03";
            sResult = ReadWriteHandler.RWH(sTransmitStatus, textBox1);
            string valueBin = functionGetRealTimePrinterStatus(sResult);
            if (valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Error possible to recover - No error\r\n";
            }
            else
            {
                textBox1.Text += "Error possible to recover - Error occurs\r\n";
            }
            if (valueBin[5].ToString() == "0")
            {
                textBox1.Text += "Error impossible to recover - No error\r\n";
            }
            else
            {
                textBox1.Text += "Error impossible to recover - Error occurs\r\n";
            }
        }

        private void menuItemPaperSensorStatus_Click(object sender, RoutedEventArgs e)
        {
            sTransmitStatus = "\x10\x04\x04";
            sResult = ReadWriteHandler.RWH(sTransmitStatus, textBox1);
            string valueBin = functionGetRealTimePrinterStatus(sResult);
            if (valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Paper near end sensor - Paper present\r\n";
            }
            else
            {
                textBox1.Text += "Paper near end sensor - No paper\r\n";
            }

            if (valueBin[3].ToString() == "0")
            {
                textBox1.Text += "Paper near end sensor - Paper present\r\n";
            }
            else
            {
                textBox1.Text += "Paper near end sensor - No paper\r\n";
            }
            if (valueBin[5].ToString() == "0")
            {
                textBox1.Text += "Paper end sensor - Paper present\r\n";
            }
            else
            {
                textBox1.Text += "Paper end sensor - No paper\r\n";
            }

            if (valueBin[6].ToString() == "0")
            {
                textBox1.Text += "Paper end sensor - Paper present\r\n";
            }
            else
            {
                textBox1.Text += "Paper end sensor - No paper\r\n";
            }

        }

        private void menuItemPresenterSensorStatus_Click(object sender, RoutedEventArgs e)
        {
            sTransmitStatus = "\x10\x04\x05";
            sResult = ReadWriteHandler.RWH(sTransmitStatus, textBox1);
            string valueBin = functionGetRealTimePrinterStatus(sResult);
            if (valueBin[3].ToString() == "0")
            {
                textBox1.Text += "Presenter out sensor - Paper present\r\n";
            }
            else
            {
                textBox1.Text += "Presenter out sensor - No paper\r\n";
            }
        }

        private void menuItemRetractorSensorStatus_Click(object sender, RoutedEventArgs e)
        {
            sTransmitStatus = "\x10\x04\x06";
            sResult = ReadWriteHandler.RWH(sTransmitStatus, textBox1);
            string valueBin = functionGetRealTimePrinterStatus(sResult);
            if (valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Retracted paper sensor 1 - Paper present\r\n";
            }
            else
            {
                textBox1.Text += "Retracted paper sensor 1 - No paper\r\n";
            }
            if (valueBin[5].ToString() == "0")
            {
                textBox1.Text += "Retracted paper sensor 2 - Paper present\r\n";
            }
            else
            {
                textBox1.Text += "Retracted paper sensor 2 - No paper\r\n";
            }

            if (valueBin[6].ToString() == "0")
            {
                textBox1.Text += "Retract box empty sensor - Not empty\r\n";
            }
            else
            {
                textBox1.Text += "Retract box empty sensor - Empty\r\n";
            }
        }

        private void menuItemInputMediumStatus_Click(object sender, RoutedEventArgs e)
        {
            sTransmitStatus = "\x10\x04\x07";
            sResult = ReadWriteHandler.RWH(sTransmitStatus, textBox1);
            string valueBin = functionGetRealTimePrinterStatus(sResult);
            if (valueBin[3].ToString() == "0" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Paper of the input medium - Paper is inserted (available)\r\n";
            }


            if (valueBin[3].ToString() == "0" && valueBin[2].ToString() == "1")
            {
                textBox1.Text += "Paper of the input medium - Paper is not inserted (not available)\r\n";
            }
            if (valueBin[3].ToString() == "1" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Paper of the input medium - Paper is inserted but jammed (jammed) (status is not available in BJ2003 printers) \r\n";
            }
            
            
        }

        private void menuItemOutputMediumStatus_Click(object sender, RoutedEventArgs e)
        {
            sTransmitStatus = "\x10\x04\x08";
            sResult = ReadWriteHandler.RWH(sTransmitStatus, textBox1);
            string valueBin = functionGetRealTimePrinterStatus(sResult);

            if (valueBin[5].ToString() == "0" && valueBin[3].ToString() == "0" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Status of the output medium - The printer contains a document tht is in processing (available)\r\n";
            }

            if (valueBin[5].ToString() == "0"&&valueBin[3].ToString() == "0" && valueBin[2].ToString() == "1")
            {
                textBox1.Text += "Status of the output medium - There is no document in processing. Coursor is at TOF and on document nothing is printed (not available)\r\n";
            }

            if (valueBin[5].ToString() == "0" && valueBin[3].ToString() == "1" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Status of the output medium - The document is jammed (jammed)\r\n";
            }

            if (valueBin[5].ToString() == "0" && valueBin[3].ToString() == "1" && valueBin[2].ToString() == "1")
            {
                textBox1.Text += "Status of the output medium - The document is in presenter taking position (presented) (only in receipt printers)\r\n";
            }


            if (valueBin[5].ToString() == "1" && valueBin[3].ToString() == "0" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Status of the output medium - No document available. The last Document is taken (taken) (only in receipt printers)\r\n";
            }

            if (valueBin[5].ToString() == "1" && valueBin[3].ToString() == "0" && valueBin[2].ToString() == "1")
            {
                textBox1.Text += "tatus of the output medium - No document available. The last document is retracted (retracted) (only in receipt printers)\r\n";
            }
        }

        private void menuItemExtendedErrorStatus_Click(object sender, RoutedEventArgs e)
        {
            sTransmitStatus = "\x10\x04\x09";
            sResult = ReadWriteHandler.RWH(sTransmitStatus, textBox1);
            string valueBin = functionGetRealTimePrinterStatus(sResult);

            if (valueBin[6].ToString() == "0" && valueBin[5].ToString() == "0" && valueBin[3].ToString() == "0" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Extended error status - No error\r\n";
            }

            if (valueBin[6].ToString() == "0" && valueBin[5].ToString() == "0" && valueBin[3].ToString() == "0" && valueBin[2].ToString() == "1")
            {
                textBox1.Text += "Extended error status - Cutter errror (Paper jam while cutting)\r\n";
            }

            if (valueBin[6].ToString() == "0" && valueBin[5].ToString() == "0" && valueBin[3].ToString() == "1" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Extended error status - Carrier error\r\n";
            }

            if (valueBin[6].ToString() == "0" && valueBin[5].ToString() == "0" && valueBin[3].ToString() == "1" && valueBin[2].ToString() == "1")
            {
                textBox1.Text += "Extended error status - Paper jam before cutting\r\n";
            }


            if (valueBin[6].ToString() == "0" && valueBin[5].ToString() == "1" && valueBin[3].ToString() == "0" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Extended error status - Black Mark detecting error (only if Black Mark is enabled via memory switch)\r\n";
            }

            if (valueBin[6].ToString() == "0" && valueBin[5].ToString() == "1" && valueBin[3].ToString() == "0" && valueBin[2].ToString() == "1")
            {
                textBox1.Text += "Extended error status - Presenter error (Paper jam after cutting)\r\n";
            }
            if (valueBin[6].ToString() == "0" && valueBin[5].ToString() == "1" && valueBin[3].ToString() == "1" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Extended error status - Retractor error optional (Paper jam after cutting)\r\n";
            }


            if (valueBin[6].ToString() == "0" && valueBin[5].ToString() == "1" && valueBin[3].ToString() == "1" && valueBin[2].ToString() == "1")
            {
                textBox1.Text += "Extended error status - TOF position not found\r\n";
            }

            if (valueBin[6].ToString() == "1" && valueBin[5].ToString() == "0" && valueBin[3].ToString() == "0" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Extended error status - Operation After Power On error\r\n";
            }
            if (valueBin[6].ToString() == "1" && valueBin[5].ToString() == "0" && valueBin[3].ToString() == "0" && valueBin[2].ToString() == "1")
            {
                textBox1.Text += "Extended error status - Start of job timeout\r\n";
            }


            if (valueBin[6].ToString() == "1" && valueBin[5].ToString() == "0" && valueBin[3].ToString() == "1" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Extended error status - High voltage error\r\n";
            }

            if (valueBin[6].ToString() == "1" && valueBin[5].ToString() == "0" && valueBin[3].ToString() == "1" && valueBin[2].ToString() == "1")
            {
                textBox1.Text += "Extended error status - Low voltage error\r\n";
            }
            if (valueBin[6].ToString() == "1" && valueBin[5].ToString() == "1" && valueBin[3].ToString() == "0" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Extended error status - Thermistor error\r\n";
            }


            if (valueBin[6].ToString() == "1" && valueBin[5].ToString() == "1" && valueBin[3].ToString() == "0" && valueBin[2].ToString() == "1")
            {
                textBox1.Text += "Extended error status - Printer type error\r\n";
            }

            if (valueBin[6].ToString() == "1" && valueBin[5].ToString() == "1" && valueBin[3].ToString() == "1" && valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Extended error status - Paper motion error\r\n";
            }
        }

        private void menuItemCarrierHomeAndPaperMotionSensorStatus_Click(object sender, RoutedEventArgs e)
        {
            sTransmitStatus = "\x10\x04\x0A";
            sResult = ReadWriteHandler.RWH(sTransmitStatus, textBox1);
            string valueBin = functionGetRealTimePrinterStatus(sResult);
            if (valueBin[2].ToString() == "0")
            {
                textBox1.Text += "Carrier home sensor - Not in home (only in impact printer)\r\n";
            }
            else
            {
                textBox1.Text += "Carrier home sensor - In home (only in impact printer)\r\n";
            }
            if (valueBin[3].ToString() == "0")
            {
                textBox1.Text += "Cutter home sensor - Not in home (only in reciept printer)\r\n";
            }
            else
            {
                textBox1.Text += "Cutter home sensor - In home (only in reciept printer)\r\n";
            }

            if (valueBin[5].ToString() == "0")
            {
                textBox1.Text += "Paper motion sensor - Not in slot (only in journal printer)\r\n";
            }
            else
            {
                textBox1.Text += "Paper motion sensor - In slot\r\n (only in journal printer)";
            }
        }

        

        private void menuItemESCs1CharFontA_Click(object sender, RoutedEventArgs e)
        {
            labelPrintModeFont.Content = "Размер шрифта - 14x24";
            menuItemESCs1CharFontB.IsChecked = false;
            string message1 = "\x1B\x21\x00";//Установить режим печати
            

            sResult = ReadWriteHandler.RWH(message1, textBox1);
        }

        private void menuItemESCs1CharFontB_Click(object sender, RoutedEventArgs e)
        {
            labelPrintModeFont.Content = "Размер шрифта - 10x17";
            menuItemESCs1CharFontA.IsChecked = false;
            string message1 = "\x1B\x21\x01";//Установить режим печати


            sResult = ReadWriteHandler.RWH(message1, textBox1);
        }

        private void menuItemESCs1Emphasized_Click(object sender, RoutedEventArgs e)
        {
            if (menuItemESCs1Emphasized.IsChecked == true)
            {
                labelPrintModeEmphasized.Content = "Выделение - Включено";

                string message1 = "\x1B\x21\x1F";//Установить режим печати


                sResult = ReadWriteHandler.RWH(message1, textBox1);
            }
            else
            {
                labelPrintModeEmphasized.Content = "Выделение - Выключено";

                string message1 = "\x1B\x21\x1E";//Установить режим печати


                sResult = ReadWriteHandler.RWH(message1, textBox1);
            }
        }

        private void menuItemPrintModeUnderline_Click(object sender, RoutedEventArgs e)
        {
            if (menuItemESCs1Underline.IsChecked == true)
            {
                labelPrintModeUnderline.Content = "Подчёркивание - Включено";

                string message1 = "\x1B\x21\x62";//Установить режим печати


                sResult = ReadWriteHandler.RWH(message1, textBox1);
            }
            else
            {
                labelPrintModeEmphasized.Content = "Подчёркивание - Выключено";

                string message1 = "\x1B\x21\x46";//Установить режим печати


                sResult = ReadWriteHandler.RWH(message1, textBox1);
            }
        }
        }
        }
    

