using System;
using System.Collections.Generic;

namespace Zadanie2
{
    class ResultValue
    {
        private Dictionary<string, int> ResultValues;

        public ResultValue()
        {
            ResultValues = new Dictionary<string, int>();
        }

        public string GetBestResult()
        {
            return FindMaxValue();
        }

        private string FindMaxValue()
        {
            int max = int.MinValue;
            string bestResult = "";
            foreach (string key in ResultValues.Keys)
            {
                if (ResultValues[key] > max)
                {
                    max = ResultValues[key];
                    bestResult = key;
                }
            }

            return bestResult;
        }

        public void AddAnswerValue(AnswerValue answerValue)
        {
            foreach (string key in answerValue.GetKeys())
            {
                AddValueToDictionary(key, answerValue.GetValue(key));
            }
        }

        private void AddValueToDictionary(string key, int v)
        {
            if(ResultValues.ContainsKey(key))
            {
                ResultValues[key] += v;
            } 
            else
            {
                ResultValues[key] = v;
            }
        }
    }
}