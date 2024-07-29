namespace MyConsoleApp.Commands
{
    internal abstract class BaseCommand
    {
        public abstract string Name { get; }

        public abstract string Description { get; }

        public virtual void Execute(List<string> args)
        {
            PrintCustomTxT.Notification("DEBG", $"Command {Name} does not contain an implementation.");
        }
    }
}
