namespace MyConsoleApp.Commands
{
    internal class DirCommand : ICommand
    {
        public void Execute(List<string> args)
        {
            //Создаём объект дирректории со всей инфой
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

            //Получаем данные о дирректориях и файлах
            var files = directoryInfo.GetFiles();
            var dirrectoryes = directoryInfo.GetDirectories();

            //Принтим это в консоль. Сначала дирректории, потом файлы.
            Console.WriteLine();
            foreach (var dir in dirrectoryes)
            {
                Console.WriteLine(ToDirFormat(dir));
            }

            foreach (var file in files)
            {
                Console.WriteLine(ToDirFormat(file));
            }
            Console.WriteLine();
        }

        //Метод превращает экзмемпляр FileSystemInfo в "[$ДАТА_ПОСЛЕДНЕГО_ИЗМЕНЕНИЯ] [$ТИП_ЭЛЕМЕНТА || $РАЗМЕР_ФАЙЛА] [$НАЗВАНИЕ_ЭЛЕМЕНТА]"
        private string ToDirFormat(FileSystemInfo elementInfo)
        {
            string dirMark = "<DIR>";

            //Да, это выглядит очень странно, но без этой проверки будет исключение если это дирректория.
            //А в конце я рудимент добавил, ну чтобы если захочу всё вернуть - он тут был.
            string fileMark = elementInfo is FileInfo ? ((elementInfo as FileInfo).Length / 1024).ToString() : new string(' ', dirMark.Length);

            //Массив с нужными данными
            string[] outputArray =
            {
                elementInfo.LastAccessTime.ToString(),
                elementInfo is DirectoryInfo ? dirMark : fileMark,
                elementInfo.Name
            };

            return string.Join("\t", outputArray);
        }
    }
}
