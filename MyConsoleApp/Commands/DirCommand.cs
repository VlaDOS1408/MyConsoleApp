namespace MyConsoleApp.Commands
{
    internal class DirCommand : ICommand
    {
        public void Execute(List<string> args)
        {
            //Создаём объект дирректории со всей инфой
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

            //Получаем данные о дирректориях и файлах
            var fileSystemInfos = directoryInfo.GetFileSystemInfos();

            //Принтим это в консоль.
            Console.WriteLine();
            foreach (var fileSystemInfo in fileSystemInfos)
            {
                if (fileSystemInfo is DirectoryInfo)
                    Console.WriteLine(ToDirFormat(fileSystemInfo as DirectoryInfo));
                else
                    Console.WriteLine(ToDirFormat(fileSystemInfo as FileInfo));
            }
            Console.WriteLine();
        }

        //Метод превращает экзмемпляр FileSystemInfo в "[$ДАТА_ПОСЛЕДНЕГО_ИЗМЕНЕНИЯ] [$ТИП_ЭЛЕМЕНТА || $РАЗМЕР_ФАЙЛА] [$НАЗВАНИЕ_ЭЛЕМЕНТА]"
        private string ToDirFormat(FileSystemInfo elementInfo)
        {
            string dirMark = "<DIR>";
            string fileMark = new string(' ', dirMark.Length);

            //Массив с нужными данными
            string[] outputArray =
            {
                elementInfo.LastAccessTime.ToString(),
                elementInfo is DirectoryInfo ? dirMark : fileMark,
                elementInfo is FileInfo ? ((elementInfo as FileInfo).Length / 1024).ToString() : "",
                elementInfo.Name
            };

            return string.Join("\t", outputArray);
        }
    }
}
