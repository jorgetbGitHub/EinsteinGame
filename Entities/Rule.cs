using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public abstract class Rule<TKey, TValue> : IRule
    {
        public int Priority { get; }

        public Rule(int priority)
        {
            Priority = priority;
        }

        public abstract TKey Apply(TValue value);
    }
}
