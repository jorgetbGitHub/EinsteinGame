using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IWordGameService
    {
        public string PlayGame(int start, int end, IWordGame wordGame);
    }
}
