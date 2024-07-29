namespace MyConsoleApp
{
    internal class Program
    {
        public static bool work = true;
        public static bool debug = true;

        static void Main(string[] args)
        {
            //Получаем время сейчас
            DateTime Time = DateTime.Now;

            //Устанавливаем рабочую дирректорию
            try
            {
                Directory.SetCurrentDirectory(Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()) + "Users");
            }
            catch { }
            //Выводим время и уведомление что консоль начала работу
            Console.WriteLine($"{Time}"); PrintCustomTxT.Notification("INFO", "Console app start work\n");

            //Консоль будет работать и запрашивать команды всегда, если bool Program.Work = true
            var cmdManager = new CommandManager();
            while (work)
            {
                cmdManager.InputCommand();
            }
        }
    }
}