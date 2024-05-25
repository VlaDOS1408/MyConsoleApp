using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Commands
{
    internal class ColorCommand : ICommand
    {
        public void Execute(List<string> args)
        {
            ChangeConsoleColor(args);
        }

        //Команда смены цвета в консоли
        private void ChangeConsoleColor(List<string> comand)
        {
            string color; //Просто удобное переименование
            string mode = ""; //То же самое
            if (comand.Count() < 2)
            {
                Console.Write("["); PrintCustomTxT.WriteByForegroundColor("WARN", "Yellow"); Console.WriteLine("] You didn't specify the color");
                return;
            }
            if (comand.Count() > 2)
            {
                mode = comand[2];
            }

            color = comand[1];


            if (color == "reset")
            {
                Console.ResetColor();
                PrintCustomTxT.Notification("Info", "Colors reset");
            }
            else
            {
                switch (mode)
                {
                    case "" or "foreground" or "fore":
                        try
                        {
                            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
                            PrintCustomTxT.Notification("info", $"Foreground color changed on {color}");
                        }
                        catch (ArgumentException)
                        {
                            PrintCustomTxT.Notification("WARN", $"Color \"{color}\" is not found!");
                        }
                        break;

                    case "background" or "back":
                        try
                        {
                            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
                            PrintCustomTxT.Notification("info", $"Background color changed on {color}");
                        }
                        catch (ArgumentException)
                        {
                            PrintCustomTxT.Notification("WARN", $"Color \"{color}\" is not found!");
                        }
                        break;

                    default:
                        PrintCustomTxT.Notification("warn", "You didn't specify the mode");
                        break;
                }
            }
        }
    }
}

