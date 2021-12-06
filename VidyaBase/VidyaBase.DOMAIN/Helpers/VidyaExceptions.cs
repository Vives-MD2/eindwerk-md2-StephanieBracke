using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{

    public enum VidyaExceptions
    {
        Warning,
        Fatal,
    }
    public class VidyaException : Exception
    {
        public VidyaExceptions EType { get; private set; } = VidyaExceptions.Fatal;

        public VidyaException(string message, VidyaExceptions eType = VidyaExceptions.Fatal) : base(message)
        {

        }
        public VidyaException(string message, Exception inner, VidyaExceptions eType = VidyaExceptions.Fatal) : base(message, inner)
        {

        }
    }
}
