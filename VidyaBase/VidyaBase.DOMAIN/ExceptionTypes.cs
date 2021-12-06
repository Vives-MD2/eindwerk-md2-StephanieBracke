using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{

    public enum ExceptionTypes
    {
        Warning,
        Fatal,
    }
    public class VidyaException : Exception
    {
        public ExceptionTypes EType { get; private set; } = ExceptionTypes.Fatal;

        public VidyaException(string message, ExceptionTypes eType = ExceptionTypes.Fatal) : base(message)
        {

        }
        public VidyaException(string message, Exception inner, ExceptionTypes eType = ExceptionTypes.Fatal) : base(message, inner)
        {

        }
    }
}
