﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    internal interface ICommand
    {
        public void Execute(List<string> args);
    }
}