using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    internal class FileManager
    {
        static string activeFolder = @"C:\Users\Admin\";

        public static string ActiveFolder
        {
            get
            {
                return activeFolder;
            }
            set
            {
                activeFolder = value.Replace("/", @"\");
            }
        }

        public static void GoToPath(List<string> arg)
        {
            string pattern = @"[A-Z]";

            if (arg.Count() < 2)
            {
                PrintCustomTxT.Notification("ERRO", "The argument is not correct");
                arg.Add("");
            }


            void UpCatalog(string path)
            {
                int lastSlashIndex = path.LastIndexOf(@"\");
                if (lastSlashIndex > 1)
                {
                    path = path.Substring(0, lastSlashIndex);
                    PrintCustomTxT.Notification("DEBG", "IT IS WORK LINE 222");
                }
            }

            void GoToCatalogInActiveFolder(string path)
            {
                PrintCustomTxT.Notification("DEBG", "Go To Catalog In Active Folder");
            }

            if (arg[1] == "")
            {
                UpCatalog(arg[1]);
            }
            else if (!(/*Regex.IsMatch(arg[1], pattern) &&*/ arg[1].Contains(":") && arg[1].Contains(@"\")))
            {
                GoToCatalogInActiveFolder(arg[1]);
            }
            else if (Regex.IsMatch(arg[1], pattern) && arg[1].Contains(":") && arg[1].Contains(@"\"))
            {
                ActiveFolder = arg[1];
            }
            else
            {
                PrintCustomTxT.Notification("ERRO", "The argument is not correct");
            }
        }
    }
}
