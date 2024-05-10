using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    //Лучше переписать анхуй это говнище 💀💀💀
    internal class OldFileManager
    {
        static string activeFolder = @"C:\Users\Admin\";

        //Аксессор взаимодействия с путём активной папки (поле)
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

        //Идти к папке
        public static void GoToPath(List<string> arg)
        {
            //Нерабочий, или рабочий паттерн.
            string pattern = @"[A-Z]";

            //Если в листе который типо команда менее 2х элементов он добавляет "";
            if (arg.Count() < 2)
            {
                //Вырезать увед
                PrintCustomTxT.Notification("ERRO", "The argument is not correct");
                arg.Add("");
            }

            //Поднятся по каталогу вверх, но вообще вырезает последнее слово
            void UpCatalog(string path)
            {
                int lastSlashIndex = path.LastIndexOf(@"\");
                if (lastSlashIndex > 1)
                {
                    path = path.Substring(0, lastSlashIndex);
                    PrintCustomTxT.Notification("DEBG", "IT IS WORK LINE 222");
                }
            }

            //Это вообще рай коммунизма, тут чёрт знает что! Это я про всё, а не про метод ниже.
            void GoToCatalogInActiveFolder(string path)
            {
                //Просто пишет что вы типо куда-то ушли (нет)
                PrintCustomTxT.Notification("DEBG", "Go To Catalog In Active Folder");
            }

            //Проверка что вы хотите сделать
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
