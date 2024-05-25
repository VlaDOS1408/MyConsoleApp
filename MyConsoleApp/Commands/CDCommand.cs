using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Commands
{
    //Adapter of FileManager class
    internal class CDCommand : FileManager, ICommand
    {
        public void Execute(List<string> args)
        {
            this.PerformDirectoryOperation(args);
        }
    }
}
