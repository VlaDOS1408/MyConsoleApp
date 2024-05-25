using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    //Это СМЕРТЬ! НИ В КОЕМ СЛУЧАЕ НЕ ЧИТАТЬ!!! ВЫ УМРЁТЕ ЕСЛИ ПРОЧИТАЕТЕ ЭТОТ КОД!!!
    //Вы были предупреждены...
    internal class DirCommand : ICommand
    {
        public void Execute(List<string> args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = directoryInfo.GetFiles();
            var dirrectoryes = directoryInfo.GetDirectories();

            foreach ( var dir in dirrectoryes)
            {
                Console.WriteLine(ToDirFormat(dir.Name, dir));
            }

            foreach (var file in files)
            {
                Console.WriteLine(ToDirFormat(file.Name, file));
            }
            Console.WriteLine();
        }

        private string ToDirFormat(string input, dynamic elementInfo)
        {
            DateTime elementCreationTime = elementInfo.CreationTime;
            string elementType = (elementInfo.GetType()).ToString();
            

            string secondElementInArray = elementType == "System.IO.DirectoryInfo" ? "<DIR>" : "";

            string[] formatArray = new string[] {
            elementCreationTime.ToString(),
            secondElementInArray,
            input
            };

            string output = string.Join("\t", formatArray);

            return output;
        }
    }
}
