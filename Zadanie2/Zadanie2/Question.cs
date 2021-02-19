using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Question
    {
        private readonly string QuestionContent;
        public List<Answer> Answers
        {
            get; private set;
        }

        public Question(string questionContent, List<Answer> answers)
        {
            QuestionContent = questionContent ?? throw new ArgumentNullException(nameof(questionContent));
            Answers = answers ?? throw new ArgumentNullException(nameof(answers));
        }

        public override string ToString()
        {
            return QuestionContent;
        }

    }
}
