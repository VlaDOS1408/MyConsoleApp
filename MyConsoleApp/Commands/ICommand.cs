namespace MyConsoleApp.Commands
{
    internal interface ICommand
    {
        public string Name { get; }

        public string Description { get; }

        public void Execute(List<string> args);
    }
}
