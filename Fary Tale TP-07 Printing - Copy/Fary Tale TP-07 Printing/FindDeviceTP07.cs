using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using System.Windows;
using LibUsbDotNet.Info;

namespace Fary_Tale_TP_07_Printing
{
    public class FindDeviceTP07
    {
        public static UsbDevice MyTp07;
        #region
        //public static Guid intGid= new Guid 0xa5dcbf10-0x6530-0x11d2-901f-00c04fb951ed};
        public static UsbDeviceFinder MyTP07Finder = new UsbDeviceFinder(0x0AA7,0x4304);
        
        #endregion

       public static UsbEndpointReader reader;
       public static UsbEndpointWriter writer;
       

        public static void FDTP07()
        {
            
            string message1 = "Устройство найдено";
            ErrorCode ec = ErrorCode.None;


            try
            {
                // Find and open the usb device.
                MyTp07 = UsbDevice.OpenUsbDevice(MyTP07Finder);

                // If the device is open and ready
                if (MyTp07 == null) throw new Exception("Device Not Found.");

                // If this is a "whole" usb device (libusb-win32, linux libusb)
                // it will have an IUsbDevice interface. If not (WinUSB) the 
                // variable will be null indicating this is an interface of a 
                // device.
                IUsbDevice wholeUsbDevice = MyTp07 as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    // This is a "whole" USB device. Before it can be used, 
                    // the desired configuration and interface must be selected.

                    // Select config #1
                    wholeUsbDevice.SetConfiguration(1);

                    // Claim interface #0.
                    wholeUsbDevice.ClaimInterface(0);
                }

                // open read endpoint 1.
                reader = MyTp07.OpenEndpointReader(ReadEndpointID.Ep01);

                // open write endpoint 2.
                writer = MyTp07.OpenEndpointWriter(WriteEndpointID.Ep02);


                

            }
            catch (Exception ex)
            {
                message1 = "";
                message1 = ec != ErrorCode.None ? ec + ":" : string.Empty + ex.Message;
                MessageBox.Show(message1);
                Environment.Exit(0);
            }
        }

    }
}
