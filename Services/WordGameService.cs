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
        public List<string> PlayGame(int start, int end, IWordGame wordGame)
        {
            List<string> list = new List<string>();
            for (int i = start; i < end + 1; i++)
            {
                try
                {
                    list.Add(wordGame.Play(i));
                }catch(Exception ex)
                {
                    _operationLogger.LogOperations(this, "[Play]", "An error ocurred during playing word game", ex);
                }
            }

            return list;
        }
    }
}
