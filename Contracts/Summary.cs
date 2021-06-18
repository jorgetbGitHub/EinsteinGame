using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class Summary
    {
        public DateTime Date { get; }

        public string TextResult { get; }

        public Summary(DateTime date, string textResult)
        {
            Date = date;
            TextResult = textResult;
        }
    }
}
