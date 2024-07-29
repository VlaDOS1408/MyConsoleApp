namespace MyConsoleApp.Commands
{
    [Obsolete("Outdate command class. Use CDCommand.")]
    internal class FileManager
    {
        public void PerformDirectoryOperation(List<string> input)
        {
            //Логово сатаны, ждёт вас ниже
            //БЕГИТЕ ГЛУПЦЫ!!!
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
                //Не работает с путями в которых несколько пробелов между 2мя смловами
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
                GoToCatalogInActiveDirectory(newPath);
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

        private void UpDirectory()
        {
            string currentPath = Directory.GetCurrentDirectory();
            string directoryRoot = Directory.GetDirectoryRoot(currentPath);
            string newCurrentPath;

            int lastIndexOfSlash = currentPath.LastIndexOf('\\');

            if (currentPath == directoryRoot)
            {
                Console.WriteLine();
                return;
            }

            newCurrentPath = currentPath.Substring(0, lastIndexOfSlash);

            if (newCurrentPath == directoryRoot.Substring(0, directoryRoot.Length - 1))
            {
                GoToAbsoluteDirectory(directoryRoot);
            }
            else
            {
                GoToAbsoluteDirectory(newCurrentPath);
            }
        }

        private void GoToCatalogInActiveDirectory(string path)
        {
            string newPath = Directory.GetCurrentDirectory() + "\\" + path;

            GoToAbsoluteDirectory(newPath);
        }

        private void GoToAbsoluteDirectory(string path)
        {
            try
            {
                Directory.SetCurrentDirectory(path);
                Console.WriteLine();
            }
            catch
            {
                PrintCustomTxT.Notification("ERRO", "The system cannot find the specified path."); //$"Path \"{path}\" not found ({e})");
            }
        }
    }
}
