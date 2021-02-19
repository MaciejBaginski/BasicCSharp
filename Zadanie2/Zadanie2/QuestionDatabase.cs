using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    static class QuestionDatabase
    {
        static public List<Question> GetBaseQuestionSet()
        {
            List<Question> baseQuestions = new List<Question>();
            List<Answer> answers = new List<Answer>();
            AnswerValue answerValue = AnswerValue.AnswerValueCreator.CreateAnswerValue().with("junior", 4).with("mid", 10);
            Answer answer = new Answer("Super dobrze", answerValue);
            answers.Add(answer);

            answerValue = AnswerValue.AnswerValueCreator.CreateAnswerValue().with("junior", 10).with("mid", 2).with("senior", 5);
            answer = new Answer("Myślę, że dobrze", answerValue);
            answers.Add(answer);

            answerValue = AnswerValue.AnswerValueCreator.CreateAnswerValue().with("junior", 2).with("senior", 10);
            answer = new Answer("Nie umiem pisać", answerValue);
            answers.Add(answer);

            answerValue = AnswerValue.AnswerValueCreator.CreateAnswerValue().with("junior", 2).with("mid", 5).with("senior", 2);
            answer = new Answer("Ok", answerValue);
            answers.Add(answer);

            Question question = new Question("Jak Ci idzie programowańsko?", answers);
            baseQuestions.Add(question);

            answers = new List<Answer>();

            answerValue = AnswerValue.AnswerValueCreator.CreateAnswerValue().with("junior", 10).with("mid", 2).with("senior", 5);
            answer = new Answer("NIE!", answerValue);
            answers.Add(answer);

            answerValue = AnswerValue.AnswerValueCreator.CreateAnswerValue().with("junior", 2).with("senior", 10);
            answer = new Answer("Co? To ja jestem w pracy?", answerValue);
            answers.Add(answer);

            answerValue = AnswerValue.AnswerValueCreator.CreateAnswerValue().with("junior", 2).with("mid", 5).with("senior", 2);
            answer = new Answer("Tak", answerValue);
            answers.Add(answer);

            question = new Question("Chcesz przerwę?", answers);
            baseQuestions.Add(question);

            return baseQuestions;
        }
    }
}
