using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MyConsoleApp
{

    internal class Command
    {
        static string PreComTxt = "> ";

        //Форматирование введённой команды под нужный стандарт.
        static string CmdFormat(string? input)
        {

            string output = Regex.Replace(input.Trim(), @"\s+", " ");

            return output;
        }

        //Ввод команды и методы обработки сверху
        public static void InComm()
        {
            Console.Write(Directory.GetCurrentDirectory() + PreComTxt);
            PerformComm(CmdFormat(Console.ReadLine()));
        }

        //Bool просто что бы return работал. Выполняет команды.
        static bool PerformComm(string rawCom)
        {
            //ДОБАВИТЬ ИГНОРИРОВАНИЕ РЕГИСТРА БУКВ!!!!!!!!!!!!!!!!!!!!!!
            if (rawCom == null)
                return false;

            //Обработанная комманда
            var comand = rawCom.Split(" ").Cast<string>().ToList();

            //Смотрит что за команду отправил юзер (Первое слово)
            switch (comand[0])
            {
                case "color":
                    ColorCommand color = new ColorCommand();
                    color.Execute(comand);
                    break;

                case "exit":
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;

                case "clear":
                    Console.Clear();
                    break;

                case "cd":
                    CDCommand cd = new CDCommand();
                    cd.Execute(comand);
                    break;

                case "dir":
                    var dir = new DirCommand();
                    dir.Execute(comand);
                    break;

                case "":
                    break;

                default:
                    PrintCustomTxT.Notification("WARN", $"Comand \"{comand[0]}\" is not found!");
                    return false;
            }

            return true;
        }
    }
}
