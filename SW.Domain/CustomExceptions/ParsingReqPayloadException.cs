using System;

namespace SW.Domain.CustomExceptions
{
    public class ParsingReqPayloadException : Exception
    {
        public ParsingReqPayloadException() { }
        public ParsingReqPayloadException(string message) : base(message) { }
    }
}
