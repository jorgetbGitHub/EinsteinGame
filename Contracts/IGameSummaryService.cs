﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGameSummaryService
    {
        public Task SaveSummaryAsync(Summary summary);
    }
}
