using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class EinsteinGame : WordGame
    {
        public EinsteinGame() : base()
        {
            RulesCollection = new RulesCollection<WordRule>();
            RulesCollection.AddRuleInPriorityOrder(new WordRule(3, "fizz"));
            RulesCollection.AddRuleInPriorityOrder(new WordRule(5, "buzz"));
        }
    }
}
