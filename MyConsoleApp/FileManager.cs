using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    internal static class FileManager
    {
        private static DirectoryInfo activeDirectory = new DirectoryInfo(@"C:\");

        public static void PerformDirectoryOperation(List<string> input)
        {
            string path = @"C:\";

            //Удаление "cd" из входа
            input.RemoveAt(0);
            for (int i = 0; i < input.Count; i++)
            {
                input[i] = input[i + 1];
            }
            input.RemoveAt(input.Count - 1);

            if (input.Count > 1)
            {
                path = string.Join(" ", input);
            }
            else
            {
                path = input[1];
            }

            if (path == ".." && path != activeDirectory.Root.ToString())
            {
                UpDirectory();
            }
            else if (!path.Contains("\\") && !path.Contains(" "))
            {
                GoToCatalogInActiveDirectory();
            }
            else if (path.Contains("\\") ) //Directory.?
            {
                GoToAbsoluteDirectory();
            }
        }

        private static void UpDirectory()
        {
            //activeDirectory.FullName
        }

        private static void GoToCatalogInActiveDirectory()
        {

        }

        private static void GoToAbsoluteDirectory()
        {

        }
    }
}
