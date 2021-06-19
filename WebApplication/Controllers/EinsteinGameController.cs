using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EinsteinGameController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IWordGameService _wordGameService;
        private readonly IGameSummaryService _gameSummaryService;
        private readonly OperationLogger _operationLogger;

        private readonly EinsteinGame EinsteinGame = new EinsteinGame();
        public EinsteinGameController(IOptions<AppSettings> appSettings, IWordGameService wordGameService, 
            IGameSummaryService gameSummaryService, OperationLogger operationLogger)
        {
            _wordGameService = wordGameService;
            _gameSummaryService = gameSummaryService;
            _operationLogger = operationLogger;
            _appSettings = appSettings.Value;
        }

        [HttpGet("play/{start}")]
        public async Task<IActionResult> PlayAsync(string start)
        {
            int limitGame = _appSettings.LimitGame;
            List<string> result;
            if (int.TryParse(start, out int intStart))
            {
                try
                {
                    result = _wordGameService.PlayGame(intStart, limitGame, EinsteinGame);
                    await _gameSummaryService.SaveSummaryAsync(new Summary(DateTime.UtcNow, result));
                    return Ok(result);
                } catch (Exception ex)
                {
                    _operationLogger.LogOperations(this, "[PlayAsync]", "An error occurred while handlind /play request.", ex, false);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest($"Parameter \"{start}\" is not a integer.");
            }
        }

    }

}