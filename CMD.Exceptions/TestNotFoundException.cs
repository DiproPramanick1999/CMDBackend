using System;
using System.Runtime.Serialization;

namespace CMD.Exceptions
{
    [Serializable]
    public class TestNotFoundException : ApplicationException
    {
        public TestNotFoundException(string message = "No test with given testId found.", Exception innerException = null) : base(message, innerException)
        {
        }

        protected TestNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}