using System;
using System.Collections.Generic;

namespace Zadanie2
{
    class Answer
    {
        public AnswerValue AnswerValue
        {
            get; private set;
        }
        private readonly string AnswerContent;

        public Answer(string answerContent, AnswerValue answerValue)
        {
            AnswerValue = answerValue ?? throw new ArgumentNullException(nameof(answerValue));
            AnswerContent = answerContent ?? throw new ArgumentNullException(nameof(answerContent));
        }

        public override string ToString()
        {
            return AnswerContent;
        }
    }
}