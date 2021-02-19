using System;
using System.Runtime.Serialization;

namespace Zadanie2
{
    [Serializable]
    class QuestionnaireException : Exception
    {
        public QuestionnaireException()
        {
        }

        public QuestionnaireException(string message) : base(message)
        {
        }

        public QuestionnaireException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QuestionnaireException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}