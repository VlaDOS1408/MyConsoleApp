using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Commands
{
    internal class TypeCommand : BaseCommand, ICommand
    {
        public override string Name => "type";

        public override string Description => "Отображает содержимое текстовых файлов.";

        public override void Execute(List<string> args)
        {
            PrintCustomTxT.Notification("Debg", "Code absent: TypeCommand.Execute()");
        }
    }
}
