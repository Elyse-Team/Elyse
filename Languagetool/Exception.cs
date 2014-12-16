﻿using System;

namespace Elyse.Languagetool
{
    public class Exception : System.Exception 
    { 
        public Exception()
        {
        }

        public Exception(string message)
            : base(message)
        {
        }

        public Exception(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
