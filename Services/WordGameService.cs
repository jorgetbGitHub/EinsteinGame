using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class WordGameService : IWordGameService
    {
        private readonly OperationLogger _operationLogger;
        public WordGameService(OperationLogger operationLogger)
        {
            _operationLogger = operationLogger;
        }
        public string PlayGame(int start, int end, IWordGame wordGame)
        {
            string result = string.Empty;
            for (int i = start; i < end + 1; i++)
            {
                try
                {
                    result += wordGame.Play(i);
                }catch(Exception ex)
                {
                    _operationLogger.LogOperations(this, "[Play]", "An error ocurred during playing word game", ex);
                }

                if (i != end)
                {
                    result += ", ";
                }
            }

            return result;
        }
    }
}
