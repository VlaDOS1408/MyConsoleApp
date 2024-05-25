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

            //Устанавливаем дирректорию для файловой системы
            Directory.SetCurrentDirectory(@"C:\Users\");

            //Выводим время и уведомление что консоль начала работу
            Console.WriteLine($"{Time}"); PrintCustomTxT.Notification("INFO", "Console app start work");

            //Консоль будет работать и запрашивать команды всегда, если bool Program.Work = true
            while (Work)
            {
                Command.InComm();
            }
        }
    }
}