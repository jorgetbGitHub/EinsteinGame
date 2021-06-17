using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class EinsteinGame : WordGame
    {
        public EinsteinGame() : base()
        {
            var rules = new WordRule[2];
            rules[0] = new WordRule(3, "fizz", 0);
            rules[1] = new WordRule(5, "buzz", 1);

            RulesCollection = new RulesCollection<WordRule>(rules);
        }
    }
}
