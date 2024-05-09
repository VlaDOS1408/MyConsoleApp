using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{

    internal class PrintCustomTxT
    {
        public static void WriteByForegroundColor(string input_txt, string input_color)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), input_color, true);
                Console.Write(input_txt);
                Console.ForegroundColor = oldColor;
            }
            catch (ArgumentException)
            {
                WriteByForegroundColor($"WriteByForegroundColor ArgumentException: \"{input_color}\" ", "red");
            }
        }

        public static void Notification(string notificationType, string text)
        {
            string INFO = "Cyan"; //Ярлык цвету
            string WARN = "Yellow"; //И это
            string ERRO = "Red"; //И это
            string DEBG = "Blue";

            notificationType = notificationType.ToUpper();

            Console.Write("[");
            switch (notificationType)
            {
                case "INFO":
                    WriteByForegroundColor(notificationType, INFO);
                    break;

                case "WARN":
                    WriteByForegroundColor(notificationType, WARN);
                    break;

                case "ERRO":
                    WriteByForegroundColor(notificationType, ERRO);
                    break;

                case "DEBG":
                    WriteByForegroundColor(notificationType, DEBG);
                    break;

                default:
                    WriteByForegroundColor("E404", "DarkMagenta");
                    break;
            }
            Console.WriteLine($"] {text}");
        }
    }

}
