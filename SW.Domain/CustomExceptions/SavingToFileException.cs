using System;

namespace SW.Domain.CustomExceptions
{
    public class SavingToFileException : Exception
    {
        public SavingToFileException() { }
        public SavingToFileException(string message) : base(message) { }
    }
}
