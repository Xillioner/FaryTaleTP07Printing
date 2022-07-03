using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibUsbDotNet.Main;
using LibUsbDotNet;
using System.Windows.Controls;
using System.Threading;
using System.Windows;

namespace Fary_Tale_TP_07_Printing
{
    public class ReadWriteHandler
    {
        public static string RWH(string testWriteString, TextBox TextBox1)
        {
            string sResult="";
            ErrorCode ecRead;
            //UsbEndpointReader reader = FindDeviceTP07.MyTp07.OpenEndpointReader(ReadEndpointID.Ep01);//?
            //byte[] readBuffer=new byte[1024];
            //UsbTransfer usbReadTransfer;
            ErrorCode ecWrite;
            //UsbEndpointWriter writer = FindDeviceTP07.MyTp07.OpenEndpointWriter(WriteEndpointID.Ep02);//!
            byte[] bytesToSend = Encoding.Default.GetBytes(testWriteString);
            //UsbTransfer usbWriteTransfer;
            /*int transferOut;
            int transferIn;*/


            try
            {

                if (!String.IsNullOrEmpty(testWriteString))
                {
                    int bytesWritten;
                    ecWrite = FindDeviceTP07.writer.Write(Encoding.Default.GetBytes(testWriteString), 100, out bytesWritten);//2000
                    if (ecWrite != ErrorCode.None) throw new Exception(UsbDevice.LastErrorString);

                    byte[] readBuffer = new byte[1024];
                    while (ecWrite == ErrorCode.None)
                    {
                        int bytesRead;

                        // If the device hasn't sent data in the last 100 milliseconds,
                        // a timeout error (ec = IoTimedOut) will occur. 
                        ecRead = FindDeviceTP07.reader.Read(readBuffer, 100, out bytesRead);

                        //if (bytesRead == 0) throw new Exception("No more bytes!");
                        if (bytesRead == 0) break;

                        // Write that output to the console.
                        //Console.Write(Encoding.Default.GetString(readBuffer, 0, bytesRead));
                        sResult += Encoding.Default.GetString(readBuffer, 0, bytesRead);
                      /*
                        Application.Current.Dispatcher.BeginInvoke(new ThreadStart(delegate
                        {
                            TextBox1.AppendText(Encoding.Default.GetString(readBuffer, 0, bytesRead));
                            TextBox1.ScrollToEnd();

                        }));
                        */
                    }
                        
                    //Console.WriteLine("\r\nDone!\r\n");

                    /*
                    Application.Current.Dispatcher.BeginInvoke(new ThreadStart(delegate
                    {
                        //здесь был вывод ссобщения done
                        //TextBox1.AppendText("\r\nDone!\r\n");
                        //TextBox1.ScrollToEnd();

                    }));
                     */
                }
                else
                    throw new Exception("Nothing to do.");

                //sResult = "";
                if (TextBox1 != null)
                {
                    Application.Current.Dispatcher.BeginInvoke(new ThreadStart(delegate
                        {
                            //TextBox1.AppendText(sResult + "\r\n");
                            //TextBox1.ScrollToEnd();

                        }));


                    
                }
                return sResult;
            }

            catch (Exception Exception)
            {
                sResult = Exception.Message;

                //message1 = "";
                //message1 = ec != ErrorCode.None ? ec + ":" : string.Empty + ex.Message;
                //MessageBox.Show(message1);
                Application.Current.Dispatcher.BeginInvoke(new ThreadStart(delegate
                {
                    TextBox1.AppendText(sResult + "\r\n");
                    TextBox1.ScrollToEnd();

                }));
                return sResult;


            }





        }
    }
}


