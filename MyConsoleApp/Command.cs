using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{

    internal class Command
    {
        static string PreComTxt = ">>> ";

        //Метод форматирования введённой команды. Нужен если в будущем понадобится производить какие-то дополнительные манипуляции с текстом, кроме .Trim и .ToLower
        static string CmdFormat(string input)
        {
            string output = input.Trim().ToLower();
            return output;
        }

        //Ввод команды и методы обработки сверху
        public static void InComm()
        {
            Console.Write(FileManager.ActiveFolder + PreComTxt);
            PerformComm(CmdFormat(Console.ReadLine()));
        }

        //Bool просто что бы return работал. Выполняет команды.
        static bool PerformComm(string rawCom)
        {
            if (rawCom == null)
                return false;

            List<string> Comand = rawCom.Split(" ").Cast<string>().ToList();

            switch (Comand[0])
            {
                case "color":
                    ChangeConsoleColor(Comand);
                    break;

                case "exit":
                    Console.ResetColor();
                    Program.Work = false;
                    break;

                case "clear":
                    Console.Clear();
                    break;

                case "cd":
                    FileManager.GoToPath(Comand);
                    break;

                case "":
                    break;
                default:
                    PrintCustomTxT.Notification("WARN", $"Comand \"{Comand[0]}\" is not found!");
                    return false;
            }

            return true;
        }

        static void ChangeConsoleColor(List<string> comand)
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
