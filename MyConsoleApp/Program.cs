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
            //Получаем время сейчас
            DateTime Time = DateTime.Now;
            //Выводим аремя и уведомление что консоль начала работу
            Console.WriteLine($"{Time}"); PrintCustomTxT.Notification("INFO", "Console app start work\n");

            //Консоль будет работать и запрашивать команды всегда, если bool Program.Work = true
            while (Work)
            {
                Command.InComm();
            }
        }
    }
}