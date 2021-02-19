using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Questionnaire
    {
        private List<Question>.Enumerator QuestionsEnumerator;
        private readonly ResultValue ResultValue;

        public Questionnaire()
        {
            QuestionsEnumerator = QuestionDatabase.GetBaseQuestionSet().GetEnumerator();
            ResultValue = new ResultValue();
        }

        public void SetCheckedAnswer(Answer answer)
        {
            ResultValue.AddAnswerValue(answer.AnswerValue);
        }

        public Question ReturnNextQuestion(Answer answer)
        {
            SetCheckedAnswer(answer);

            if(QuestionsEnumerator.MoveNext())
            {
                return QuestionsEnumerator.Current;
            } 
            else
            {
                return null;
            }
        }

        public string GetResult()
        {
            return ResultValue.GetBestResult();
        }

        public Question ReturnFirstQuestion()
        {
            if (QuestionsEnumerator.MoveNext())
            {
                return QuestionsEnumerator.Current;
            }
            else
            {
                return null;
            }
        }
    }
}
