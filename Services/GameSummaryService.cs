using Contracts;
using Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GameSummaryService : IGameSummaryService
    {
        private readonly AppSettings _appSettings;
        private readonly OperationLogger _operationLogger;

        public GameSummaryService(IOptions<AppSettings> appSettings, OperationLogger operationLogger)
        {
            _appSettings = appSettings.Value;
            _operationLogger = operationLogger;
        }

        public async Task SaveSummaryAsync(Summary summary)
        {
            string filename = GenerateFilename(summary);
            string path = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Outputs";
            await File.WriteAllTextAsync($"{path}{Path.DirectorySeparatorChar}{filename}.txt", summary.TextResult);
        }

        private string GenerateFilename(Summary summary)
        {
            return _appSettings.BaseEinsteinFilename + $"-{summary.Date.Year}-{summary.Date.Month}-{summary.Date.Day}-" + Guid.NewGuid().ToString();
        }
    }
}
