using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class RulesCollection<TRule>
    {
        public Dictionary<int, TRule> Rules { get; }
        public RulesCollection()
        {
            Rules = new Dictionary<int, TRule>();
        }

        public RulesCollection(TRule[] rules)
        {
            Rules = new Dictionary<int, TRule>();
            foreach (TRule rule in rules)
            {
                Rules.Add(((IRule)rule).Priority, rule);      
            }

            TRule value;
            Rules.TryGetValue(1, out value);
            Console.WriteLine($"Rules were introduces into RulesCollection successfully. {value}");
        }

        public void AddRuleInPriorityOrder(TRule rule)
        {
            ((IRule)rule).SetPriority(Rules.Count);
            Rules.Add(((IRule)rule).Priority, rule);
        }

        public TRule GetRuleByPriority(int priority)
        {
            TRule rule;
            if (Rules.TryGetValue(priority, out rule))
            {
                return rule;
            }
            else
            {
                throw new Exception(); // to catch
            }
        }

        public int Length()
        {
            return Rules.Count();
        }
    }
}
