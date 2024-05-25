using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Commands
{
    internal class TypeCommand : ICommand
    {
        public void Execute(List<string> args)
        {
            PrintCustomTxT.Notification("Debg", "Code absent: TypeCommand.Execute()");
        }
    }
}
