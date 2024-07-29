namespace MyConsoleApp.Commands
{
    internal class ClearCommand : BaseCommand, ICommand
    {
        public override string Name => "clear";

        public override string Description => "Очистка экрана.";

        public override void Execute(List<string> args)
        {
            Console.Clear();
        }
    }
}
