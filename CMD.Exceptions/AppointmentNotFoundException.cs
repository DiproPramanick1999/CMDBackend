using System;
using System.Runtime.Serialization;

namespace CMD.Exceptions
{
    [Serializable]
    public class AppointmentNotFoundException : ApplicationException
    {
        public AppointmentNotFoundException(string message = "No Appointment with given appointmentId found.", Exception innerException = null) : base(message, innerException)
        {
        }

        protected AppointmentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}