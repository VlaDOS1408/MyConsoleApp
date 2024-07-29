namespace MyConsoleApp.Commands
{
    internal class EchoCommand : BaseCommand, ICommand
    {
        public override string Name => "echo";

        public override string Description => "Отображает сообщение.";

        public override void Execute(List<string> args)
        {
            Console.WriteLine((string.Join(" ", args)) + "\n");
        }
    }
}
