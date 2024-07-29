using System.Text.RegularExpressions;
using MyConsoleApp.Commands;

namespace MyConsoleApp
{

    internal class CommandManager
    {
        internal CommandManager()
        {
            _commands = new Dictionary<string, ICommand>{
                {"cd", new CDCommand()}, //Не работает с путями в которых несколько пробелов между 2мя словами. Проблема в методе обработки введённой команды.
                {"color", new ColorCommand()},
                {"clear", new ClearCommand()},
                {"dir", new DirCommand()},
                {"type", new TypeCommand()},
                //{"echo", new EchoCommand()},
                {"exit", new ExitCommand()}
            };
        }

        private string _prefix = "> ";

        private readonly Dictionary<string, ICommand> _commands;

        public string Prefix
        {
            get { return _prefix; }

            set { if (value != null) _prefix = value; }                

        }        

        //Форматирование введённой команды под нужный стандарт.
        private string ToCommandFormat(string? input)
        {
            if (input == null)
                return "";

            return Regex.Replace(input.Trim(), @"\s+", " "); // <= Вот из-за этой чертиллы CDCommand не корректно работает с некоторыми путями.
        }

        //Ввод команды и метод обработки сверху, после сразу выполняет.
        public void InputCommand()
        {
            Console.Write(Directory.GetCurrentDirectory() + _prefix);
            ExecuteCommand(ToCommandFormat(Console.ReadLine()));
        }

        private void ExecuteCommand(string input)
        {
            //Зачем выполнять пустой запрос? Прервать!
            if (string.IsNullOrEmpty(input))
                return;

            List<string> inputParts = input.Split(' ').Cast<string>().ToList();
            //var args = parts.Skip(1).ToList(); //Удаление самой комманды
            var commandStr = inputParts[0].ToLower();

            try
            {
                var command = _commands[commandStr];
                command.Execute(inputParts);
            }
            catch (KeyNotFoundException ex)
            {
                PrintCustomTxT.Notification("ERRO", $"Command \"{commandStr}\" not found");
                if (Program.debug)
                    PrintCustomTxT.Notification("DEBG", $"{ex.Message}\n");
            }
            catch (Exception ex)
            {
                PrintCustomTxT.Notification("ERRO", ex.Message);
            }
        }

        public static List<string> DeleteCommandArg(List<string> input)
        {
            return input.Skip(1).ToList();
        }
    }
}
