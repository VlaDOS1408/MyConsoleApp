namespace MyConsoleApp.Commands
{
    internal class ExitCommand : BaseCommand, ICommand
    {
        public override string Name => "exit";

        public override string Description => "Выход из программы.";

        public override void Execute(List<string> args)
        {
            PrintCustomTxT.Notification("INFO", "Console closed");
            Console.ResetColor();
            //Save data?
            Environment.Exit(0);
        }
    }
}
