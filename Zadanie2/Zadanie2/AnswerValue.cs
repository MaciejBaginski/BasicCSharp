using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie2
{
    class AnswerValue
    {
        public Dictionary<string, int> valuePairs
        {
            get; private set;
        }
        private AnswerValue(Dictionary<string, int> valuePairs)
        {
            this.valuePairs = valuePairs ?? throw new ArgumentNullException(nameof(valuePairs));
        }

        private AnswerValue()
        {
            valuePairs = new Dictionary<string, int>();
        }

        public AnswerValue with(string name, int val)
        {
            valuePairs[name] = val;
            return this;
        }

        public List<string> GetKeys()
        {
            return valuePairs.Keys.ToList();
        } 

        public int GetValue(string key)
        {
            if(valuePairs.ContainsKey(key))
            {
                return valuePairs[key];
            } 
            else
            {
                throw new QuestionnaireException("Missing value for key: " + key);
            }
        }

        static public class AnswerValueCreator
        {
            static public AnswerValue CreateAnswerValue()
            {
                return new AnswerValue();
            }
        }
    }
}