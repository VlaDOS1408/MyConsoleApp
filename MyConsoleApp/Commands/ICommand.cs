using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyConsoleApp.Commands;

namespace MyConsoleApp.Commands
{
    internal interface ICommand
    {
        public void Execute(List<string> args);
    }
}
