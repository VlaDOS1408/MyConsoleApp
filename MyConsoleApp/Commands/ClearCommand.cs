using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
