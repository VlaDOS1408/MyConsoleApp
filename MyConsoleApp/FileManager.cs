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
        public static void PerformDirectoryOperation(List<string> input)
        {
            string newPath;

            if (input.Count < 2)
            {
                Console.WriteLine(Directory.GetCurrentDirectory() + "\n");
                return;
            }

            //Удаление "cd" из входа
            input.RemoveAt(0);

            //Если это абсолютный путь с пробеллами
            if (input.Count > 1)
            {
                newPath = string.Join(" ", input);
            }
            else
            {
                newPath = input[0];
            }

            if (newPath == "..")
            {
                UpDirectory();
            }
            else if (!newPath.Contains("\\") && !newPath.Contains(" "))
            {
                GoToCatalogInActiveDirectory();
            }
            else if (newPath.Contains(Directory.GetDirectoryRoot(Directory.GetCurrentDirectory())))
            {
                GoToAbsoluteDirectory(newPath);
            }
            else
            {
                PrintCustomTxT.Notification("ERRO", "Uncorrect path");
            }
        }

        private static void UpDirectory()
        {
            string currentPath = Directory.GetCurrentDirectory();
            string directoryRoot = Directory.GetDirectoryRoot(currentPath);
            string newCurrentPath;

            if (currentPath == directoryRoot)
            {
                Console.WriteLine();
                return;
            }
                
            //
        }

        private static void GoToCatalogInActiveDirectory()
        {
            PrintCustomTxT.Notification("DEBG", "Code absent: GoToCatalogInActiveDirectory()");
        }

        private static void GoToAbsoluteDirectory(string path)
        {
            try
            {
                Directory.SetCurrentDirectory(path);
                Console.WriteLine();
            }
            catch(Exception e)
            {
                PrintCustomTxT.Notification("ERRO", $"Path \"{path}\"not found ({e})");
            }
        }
    }
}
