﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Contract.Exeption
{
    public class AppExeption : Exception
    {
        public AppExeption(string message) : base(message)
        {

        }
    }
}
