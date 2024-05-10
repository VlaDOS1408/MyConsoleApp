using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    internal class FileManager
    {
        static void PerformFileAction(List<string> command)
        {
            try
            {
                string pattern = @"[A-Z]";

            }
            catch (Exception ex)
            {
                PrintCustomTxT.Notification("ERRO", $"Analyse for change dirrectory error: {ex.Message}");
            }

        }

        static bool ChangeDirrectory(string newPath)
        {
            try
            {
                Directory.SetCurrentDirectory(newPath);
                return true;
            }
            catch (Exception ex)
            {
                PrintCustomTxT.Notification("ERRO", $"Change dirrectory error: {ex.Message}");
                return false;
            }
        }
    }
}
