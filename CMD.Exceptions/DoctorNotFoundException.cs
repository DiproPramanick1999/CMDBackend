using System;
using System.Runtime.Serialization;

namespace CMD.Exceptions
{
    [Serializable]
    public class DoctorNotFoundException : ApplicationException
    {
        public DoctorNotFoundException(string message = "No doctor with given doctorId found.", Exception innerException = null) : base(message, innerException)
        {
        }

        protected DoctorNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}