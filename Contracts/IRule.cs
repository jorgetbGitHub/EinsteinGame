using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRule
    {
        public int Priority { get; }
    }
}
