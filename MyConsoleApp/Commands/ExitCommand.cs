using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Commands
{
    internal class ExitCommand : ICommand
    {
        public void Execute(List<string> args)
        {
            PrintCustomTxT.Notification("INFO", "Console closed");
            Console.ResetColor();
            //Save data?
            Environment.Exit(0);
        }
    }
}
