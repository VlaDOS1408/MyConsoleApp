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
            //ДОБРО ПОЖАЛОВАТЬ В РАЙ ГОВНОКОДА!!! ВЫ САМИ ЭТОГО ЗАХОТЕЛИ!!! УАХАХАХАХАХАХ! А ВОТ ХРЕН ВАМ А НЕ КОММЕНТАРИИ!! УААХАХХАХАХАХАХ!
            //Боже, я же это сам читать буду через 5 лет ._.
            //Ладно, так и быть, добавлю комменты.

            //Создаём объект дирректирии со всей инфой
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

            //Получаем данные о дирректориях и файлах
            var files = directoryInfo.GetFiles();
            var dirrectoryes = directoryInfo.GetDirectories();

            //Это только ради "\n"
            Console.WriteLine();

            //Принтим это в консоль. Сначала дирректории, потом файлы.
            foreach ( var dir in dirrectoryes)
            {
                //Приводим сырые данные к нужному формату строки.
                Console.WriteLine(ToDirFormat(dir.Name, dir));
            }

            foreach (var file in files)
            {
                Console.WriteLine(ToDirFormat(file.Name, file));
            }

            Console.WriteLine();
        }

        //Метод превращает название елемента в "$ДАТА_ТАЙМ-СОЗДАНИЯ-ЭЛЕМЕНТА &ТИП-ЭЛЕМЕНТА &НАЗВАНИЕ-ЭЛЕМЕНТА"
        //Метод немного уёбищный, потому что изначально я его спроектировал другим.
        //Ну а ещё я юзаю динамик, потому что мне впадлу лепить что-то лишнее. Пох на оптимизацию.
        //А ещё мне по боку что оно сделанно через одно место, потому что работает - значит кайф :)
        private string ToDirFormat(string input, dynamic elementInfo)
        {
            //Беру нужные данные
            DateTime elementCreationTime = elementInfo.CreationTime;
            string elementType = (elementInfo.GetType()).ToString();
            
            //Это своего рода костыль, но мне пофиг. Работает - не лезь.
            string secondElementInArray = elementType == "System.IO.DirectoryInfo" ? "<DIR>" : "";

            //Массив с нужными данными (только для улучшения читаемости кода)
            string[] formatArray = {
            elementCreationTime.ToString(),
            secondElementInArray,
            input
            };

            //Выходные данные
            string output = string.Join("\t", formatArray);

            return output;
        }
    }
}
