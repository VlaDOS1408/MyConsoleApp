using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyConsoleApp.Commands
{
    internal class EchoCommand : ICommand
    {
        public void Execute(List<string> args)
        {
            Console.WriteLine((string.Join(" ", args)).Substring(5) + "\n");
        }
    }
}
