using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class WordRule : Rule<string, int>
    {
        protected int Divider { get; }

        protected string Word { get; }

        public WordRule(int divider, string word, int priority) : base(priority)
        {
            Divider = divider;
            Word = word;
        }

        public override string Apply(int number)
        {
            if (number % Divider == 0)
            {
                return Word;
            }

            return string.Empty;
        }

    }
}
