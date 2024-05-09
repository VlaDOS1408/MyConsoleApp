using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{

    internal class PrintCustomTxT
    {
        //Writ-ит текст в каком-то foreground цвете. Принимает текст и цвет.
        public static void WriteByForegroundColor(string input_txt, string input_color)
        {
            //Сохраняет старый цвет fore, после пробует "нарисовать" текст. В случае неудачи - он пишет что ты клоун.
            ConsoleColor oldColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), input_color, true);
                Console.Write(input_txt);
                Console.ForegroundColor = oldColor;
            }
            catch (ArgumentException)
            {
                //Исправить на $"WriteByForegroundColor: ArgumentNoneCorrect(\"{input_color}\")"
                WriteByForegroundColor($"WriteByForegroundColor ArgumentException: \"{input_color}\" ", "red");
            }
        }

        /*
         * Такая-же штука как CW. Просто является шаблонной штукой для вывода уведомлений.
         * Принимает тип уведомления (Он должен быть прописан) и сам текст.
        */
        public static void Notification(string notificationType, string text)
        {
            string INFO = "Cyan"; //Ярлык цвету
            string WARN = "Yellow"; //И это
            string ERRO = "Red"; //И это
            string DEBG = "Blue";

            notificationType = notificationType.ToUpper();
            
            //Подлежит оптимизации. Можно создать объект в котором будет текст с цветом и передавать его в WBFC() (Точнее его цвет и контент).
            /*
             * Проверяет на соответствие уведомления заранее подготовленному шаблону.
             * Пишет что ты дурак если ты пытаешься вызвать несуществующее уведомление.
             * 
             * Структура вывода:
             * "[" + $"{Тип уведомления}"(Цветом) + $"] {input text}"
            */
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
