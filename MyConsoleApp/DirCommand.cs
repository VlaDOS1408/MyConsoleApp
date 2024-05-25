using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    internal class DirCommand : ICommand
    {
        public void Execute(List<string> args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            var filesInfo = directoryInfo.GetFiles();
            var dirrectoryesInfo = directoryInfo.GetDirectories();

            Console.WriteLine();

            foreach ( var directory in dirrectoryesInfo)
            {
                Console.WriteLine(ToDirFormat(directory.ToString()));
            }

            foreach (var file in filesInfo)
            {
                Console.WriteLine(ToDirFormat(file.ToString()));
            }

            Console.WriteLine();
        }

        private string ToDirFormat(string input)
        {
            //Заменить на дату создания файла
            var time = DateTime.Now;

            input = time.ToString() + "\t" + input;

            return input;
        }

    }
}
