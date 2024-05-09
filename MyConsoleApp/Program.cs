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
            //Выводим аремя и уведомление что консоль начала работу
            Console.WriteLine($"{Time}"); PrintCustomTxT.Notification("INFO", "Console app start work");

            //Программа работает пока bool Program.Work = true
            while (Work)
            {
                Command.InComm();
            }
        }
    }
}