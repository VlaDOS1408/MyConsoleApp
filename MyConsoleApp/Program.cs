using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace MyConsoleApp
{
    internal class Program
    {
        public static bool Work = true;
        static void Main(string[] args)
        {
            DateTime Time = DateTime.Now;
            Console.WriteLine($"{Time}"); PrintCustomTxT.Notification("INFO", "Console app start work"); // \n["); PrintCustomTxT.WriteByForegroundColor("INFO", "Cyan"); Console.WriteLine("] Console app start work\n");

            while (Work)
            {
                Command.InComm();
            }
        }
    }
}