using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public abstract class WordGame : IWordGame
    {
        protected RulesCollection<WordRule> RulesCollection { get; set; }

        public WordGame()
        {
            //NOOP
        }
        public WordGame(RulesCollection<WordRule> rulesCollection)
        {
            RulesCollection = rulesCollection;
        }

        public string Play(int number)
        {
            string word = string.Empty;
            for (int i = 0; i < RulesCollection.Length(); i++)
            {
                try
                {
                    word += RulesCollection.GetRuleByPriority(i).Apply(number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[WordGame] An error occurred during Play execution method. Exception: {ex.Message} | {ex.StackTrace}.");
                }
            }

            return word == string.Empty ? number.ToString() : word;
        }
    }
}
