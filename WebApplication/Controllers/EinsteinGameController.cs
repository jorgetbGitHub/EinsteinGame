using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        [HttpGet("play/{start}")]
        public IActionResult Play(string start)
        {
            int intStart;
            if (int.TryParse(start, out intStart))
            {
                return Ok(PlayGame(intStart));
            }
            else
            {
                return BadRequest($"Parameter \"{start}\" is not a integer.");
            }
        }

        public string PlayGame(int start)
        {
            string result = string.Empty;
            for (int i = start; i < 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    //Divisible by 3 and 5
                    result += "fizzbuzz";

                }
                else if (i % 3 == 0)
                {
                    // Divisible by 3
                    result += "fizz";

                }
                else if (i % 5 == 0)
                {
                    // Divisible by 5
                    result += "buzz";
                }
                else
                {
                    // Neither divisible by 3 nor by 5
                    result += i.ToString();
                }

                if (i != 100)
                {
                    result += ", ";
                }
            }

            SaveGameSummary(result);
            return result;
        }

        public void SaveGameSummary(string result)
        {
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
            }
            
        }
    }

}