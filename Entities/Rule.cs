using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public abstract class Rule<TKey, TValue> : IRule
    {
        public int Priority { get; set; }

        public Rule()
        {
            //NOOP
        }
        public Rule(int priority)
        {
            Priority = priority;
        }

        public void SetPriority(int priority)
        {
            Priority = priority;
        }

        public abstract TKey Apply(TValue value);
    }
}
