using System;
using System.Runtime.Serialization;

namespace CMD.Exceptions
{
    [Serializable]
    public class RecommendationNotFoundException : ApplicationException
    {
        public RecommendationNotFoundException(string message = "No recommendation with given recommendationId found.", Exception innerException = null) : base(message, innerException)
        {
        }

        protected RecommendationNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}