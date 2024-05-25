using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Commands
{
    internal class ClearCommand : ICommand
    {
        public void Execute(List<string> args)
        {
            Console.Clear();
        }
    }
}
