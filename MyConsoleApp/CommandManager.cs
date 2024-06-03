using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using MyConsoleApp.Commands;

namespace MyConsoleApp
{

    internal class CommandManager
    {
        internal CommandManager()
        {
            _commands = new Dictionary<string, ICommand>{
                {"cd", new CDCommand()}, //Не работает с путями в которых несколько пробелов между 2мя словами => MyConsoleApp.FileManager
                {"color", new ColorCommand()},
                {"clear", new ClearCommand()},
                {"dir", new DirCommand()},
                {"type", new TypeCommand()},
                {"echo", new EchoCommand()},
                {"exit", new ExitCommand()}
            };
        }

        /* Реализовать этот конструктор позже. Должен будет задавать команды из вне.
        public CommandManager(string pathToConfig)
        {

        }
        */

        private string _prefix = "> ";

        private readonly Dictionary<string, ICommand> _commands;

        public string Prefix
        {
            get
            {
                return _prefix;
            }

            set
            {
                if (value != null)
                {
                    _prefix = value;
                }                
            }
        }

        

        //Форматирование введённой команды под нужный стандарт.
        private string ToCommandFormat(string? input)
        {
            if (input == null)
            {
                return "";
            }
            string output = Regex.Replace(input.Trim(), @"\s+", " ");
            return output;
        }

        //Ввод команды и методы обработки сверху
        public void InputCommand()
        {
            Console.Write(Directory.GetCurrentDirectory() + _prefix);
            ExecuteCommand(ToCommandFormat(Console.ReadLine()));
        }

        private void ExecuteCommand(string input)
        {
            //Зачем выполнять пустой запрос? Удалить!
            if (string.IsNullOrEmpty(input))
            {
                return;
            }
            List<string> parts = input.Split(' ').Cast<string>().ToList();
            //var args = parts.Skip(1).ToList(); //Удаление самой комманды
            var commandStr = parts[0].ToLower();

            try
            {
                var command = _commands[commandStr];
                command.Execute(parts);
            }
            catch (Exception ex)
            {
                PrintCustomTxT.Notification("ERRO", $"Command \"{parts[0]}\" not found");
                if(Program.debug)
                    PrintCustomTxT.Notification("DEBG", $"{ex.Message}\n");
            }

        }

        public static List<string> DeleteCommandArg(List<string> input)
        {
            return input.Skip(1).ToList();
        }
        
        /*Устаревший метод. НЕ ИСПОЛЬЗОВАТЬ!!!! ОСТАВЛЕН ТОЛЬКО ДЛЯ... ПРОСТО НУЖЕН!!!
        //Bool просто что бы return работал. Выполняет команды.
        bool PerformComm(string rawCom)
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
                    var exit = new ExitCommand();
                    exit.Execute(comand);
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

                //Хуйня, переделать
                case "echo":
                    Console.WriteLine((string.Join(" ",comand)).Substring(5) +"\n");
                    break;

                case "":
                    break;

                default:
                    PrintCustomTxT.Notification("WARN", $"Comand \"{comand[0]}\" is not found!");
                    return false;
            }

            return true;
        }
        */
    }
}
