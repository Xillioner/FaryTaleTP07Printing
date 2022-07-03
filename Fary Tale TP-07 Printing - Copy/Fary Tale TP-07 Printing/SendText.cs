using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Fary_Tale_TP_07_Printing
{
    class SendText
    {
        public static void ST(TextBox TextBox1)
        {
            string sResult;

            string message1 = "\x1B\x40";//esc инициализация принтера
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "\x1B\x61\x01";//esc a 1-по середине
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            //message1 = "Всем привет!!!\x0A";//\x1D\x49\x41 //Print Density     : 100%\x0A
            message1 = "\x1B\x74\x11";//выбор кодовой страницы
            var fromEncoding = Encoding.UTF8;
            var bytes = fromEncoding.GetBytes(message1);
            var toEncoding = Encoding.GetEncoding(866);
            message1 = toEncoding.GetString(bytes);
            
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыь\x0A";//\x1D\x49\x41 //Print Density     : 100%\x0A
            
             fromEncoding = Encoding.GetEncoding(866);
             bytes = fromEncoding.GetBytes(message1);
             toEncoding = Encoding.GetEncoding(1251); 
            message1 = toEncoding.GetString(bytes);
                        
            /*
            string str = "Привет любимая Ирка, I love you.";
            byte[] bytes2=Encoding.UTF8.GetBytes(str);
            byte[] newbytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(866), bytes2);
             message1 = Encoding.GetEncoding(1251).GetString(newbytes);
            */
            


            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "------------------------------------\x0A";//\x1D\x49\x41 //Print Density     : 100%\x0A
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "KDIAG(2.3/03)  test print\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "Run: 1  06.07.2015\\22:35:38\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "------------------------------------\x0A";//\x1D\x49\x41 //Print Density     : 100%\x0A
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "\x1B\x61\x00";//esc a 1-по середине 0-слева
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "Printer Name      : _TP07\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "Serial Number     : _71020039\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "Revision Level    : _2\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "Firmware Version  : _07.06\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "Black mark/offset : off / -16\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "Print Density     : 100%\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "\x1B\x33\x00";//настроить пробелы микрошагами
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "\x1B\x20\x00";//настраивает правый символ пробела
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "ЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫ\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "ЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫ\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±±\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "ЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭЭ\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "ЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮЮ\x0A";
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "\x1B\x20\x02";//настраивает правый символ пробела
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "\x1B\x33\x22";///настроить пробелы микрошагами
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            message1 = "\x0C";///перевод страницы
            
             
             fromEncoding = Encoding.GetEncoding(437);
             bytes = fromEncoding.GetBytes(message1);
             toEncoding = Encoding.GetEncoding(1251);
             message1 = toEncoding.GetString(bytes);
            sResult = ReadWriteHandler.RWH(message1, TextBox1);


            message1 = "\x1D\x56\x30";///выбрать режим обрезки и резки бумаги 
            sResult = ReadWriteHandler.RWH(message1, TextBox1);

            
        }

    }
}
