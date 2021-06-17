using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EinsteinGameController : ControllerBase
    {
        private readonly IWordGameService _wordGameService;
        private readonly OperationLogger _operationLogger;

        private readonly EinsteinGame EinsteinGame = new EinsteinGame();
        public EinsteinGameController(IWordGameService wordGameService, OperationLogger operationLogger)
        {
            _wordGameService = wordGameService;
            _operationLogger = operationLogger;
        }

        [HttpGet("play/{start}")]
        public async Task<IActionResult> PlayAsync(string start)
        {
            int intStart;
            string result;
            if (int.TryParse(start, out intStart))
            {
                result = _wordGameService.PlayGame(intStart, 100, EinsteinGame);
                await SaveGameSummaryAsync(result);
                return Ok(result);
            }
            else
            {
                return BadRequest($"Parameter \"{start}\" is not a integer.");
            }
        }

        public async Task SaveGameSummaryAsync(string result)
        {
            string baseFilename = "einstein-game";
            string path = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Outputs";
            var files = Directory.GetFiles(path);

            bool isEmpty = !files.Any();
            if (!isEmpty)
            {
                Console.WriteLine("Outputs folder is not empty.");
            }
            else
            {
                Console.WriteLine("Outputs folder is empty.");
                await System.IO.File.WriteAllTextAsync($"{path}{Path.DirectorySeparatorChar}{baseFilename}.txt", result);
            }
            
        }
    }

}