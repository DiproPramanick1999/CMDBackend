using System;
using System.Runtime.Serialization;

namespace CMD.Exceptions
{
    [Serializable]
    public class DuplicateRecommendationRecordException : ApplicationException
    {
        public DuplicateRecommendationRecordException(string message = "There is already a record in the table with the same appintmentId and doctorId.", Exception innerException = null) : base(message, innerException)
        {
        }

        protected DuplicateRecommendationRecordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}