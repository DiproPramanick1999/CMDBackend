using System;
using System.Runtime.Serialization;

namespace CMD.Exceptions
{
    [Serializable]
    public class DuplicateTestRecordException : ApplicationException
    {
        public DuplicateTestRecordException(string message = "There is already a record in the table with the same name and appintmentId.", Exception innerException = null) : base(message, innerException)
        {
        }

        protected DuplicateTestRecordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}