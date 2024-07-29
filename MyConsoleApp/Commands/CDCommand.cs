using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Commands
{
    //Adapter of FileManager class
    internal class CDCommand : BaseCommand, ICommand
    {
        public override string Name => "cd";

        public override string Description => "Вывод имени либо смена текущей папки.";

        public override void Execute(List<string> args)
        {
            FileManager fileManager = new();
            fileManager.PerformDirectoryOperation(args);
        }
    }
}
