using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
    public class Summary
    {
        public DateTime Date { get; }

        public string TextResult { get; }

        public Summary(DateTime date, List<string> result)
        {
            Date = date;
            TextResult = result.Aggregate((i,j) => i + ", " + j);
        }
    }
}
