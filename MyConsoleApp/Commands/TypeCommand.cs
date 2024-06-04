﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Commands
{
    internal class TypeCommand : ICommand
    {
        public void Execute(List<string> args)
        {
            string fileBorderUpText = "[START]";
            string fileBorderDownText = "[END]";

            string fileBorderLine = new string('=', Console.WindowWidth/2);

            string fileBorderUpLine = "\n" + fileBorderLine.Substring(0, fileBorderLine.Length - (fileBorderUpText.Length/2)-1) + fileBorderUpText + fileBorderLine.Substring(0, fileBorderLine.Length - fileBorderUpText.Length/2) + "\n";
            string fileBorderDownLine = "\n" + fileBorderLine.Substring(0, fileBorderLine.Length - (fileBorderDownText.Length / 2) - 1) + fileBorderDownText + fileBorderLine.Substring(0, fileBorderLine.Length - fileBorderDownText.Length / 2) + "\n\n";

            string path = string.Join(" ", args.Skip(1));
            using (var reader = new StreamReader(path))
            {
                PrintCustomTxT.WriteByForegroundColor(fileBorderUpLine+"\n", "green");
                string text = reader.ReadToEnd();

                Console.WriteLine(text);
                PrintCustomTxT.WriteByForegroundColor(fileBorderDownLine, "green");
            }
        }
    }
}
