using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;//dotnet add package Newtonsoft.Json 
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GameBotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        private const string API_KEY = "d7957fcc17494080b3ce910e017d66d6";
        private const string BASE_URL = "https://api.rawg.io/api/games";

        [HttpPost("recommend")]
        //http://localhost:5005/api/Bot/recommend

        /*{
    "Genre": "action",
    "Console":"PC"

     }*/
        public async Task<IActionResult> RecommendGames([FromBody] GameRecommend request)
        {
            if (string.IsNullOrWhiteSpace(request.Genre) || string.IsNullOrWhiteSpace(request.Console))
            {
                return BadRequest("Genre and console must be provided.");
            }

            try
            {
                var response = await client.GetStringAsync(
                    $"{BASE_URL}?key={API_KEY}&genres={request.Genre}&slug={request.Console}"
                );
                var games = JsonConvert.DeserializeObject<GamesResponse>(response);
                return Ok(games.results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("search")]

        /*{
    "gameName": "Roblex"
    
      }*/
        public async Task<IActionResult> SearchGameDescription([FromBody] GameSearch request)
        {
            if (string.IsNullOrWhiteSpace(request.GameName))
            {
                return BadRequest("Game name must be provided.");
            }

            try
            {
                var response = await client.GetStringAsync(
                    $"{BASE_URL}?key={API_KEY}&page_size=5&search={request.GameName}"
                );
                var games = JsonConvert.DeserializeObject<GamesResponse>(response);
                return Ok(games.results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("top-rated")]
        //http://localhost:5005/api/Bot/top-rated
        public async Task<IActionResult> GetTopRatedGames(int topN = 5)
        {
            try
            {
                var response = await client.GetStringAsync(
                    $"{BASE_URL}?key={API_KEY}&page_size={topN}&ordering=-rating"
                );
                var games = JsonConvert.DeserializeObject<GamesResponse>(response);
                return Ok(games.results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    public class GameRecommend
    {
        public string Genre { get; set; }
        public string Console { get; set; }
        
    }

        public class GameSearch
    {
      
        public string GameName { get; set; }
    }


    public class GamesResponse
    {
        public int count { get; set; }
        public List<Game> results { get; set; }
    }

    public class Game
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string released { get; set; }
        public string background_image { get; set; }
        public double rating { get; set; }
        public string description { get; set; }
        public int playtime { get; set; }
        public List<PlatformInfo> platforms { get; set; }
        public List<GenreInfo> genres { get; set; }
    }

    public class PlatformInfo
    {
        public Platform platform { get; set; }
    }

    public class Platform
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class GenreInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    
}
