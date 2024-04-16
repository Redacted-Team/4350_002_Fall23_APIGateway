using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Gateway
{
    /// <summary>
    /// Controller responsible for handling requests and responses at the gateway.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly HttpClient _httpClient; // Making readonly ensures thread safety 
        private readonly ILogger<GatewayController> _logger; // Making readonly ensures thread safety 

        public GatewayController(HttpClient httpClient, ILogger<GatewayController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Handles GET requests to retrieve game information from the microservice.
        /// </summary>
        /// <returns>A collection of GameInfo objects.</returns>
        [HttpGet]
        public async Task<IEnumerable<GameInfo>> Get()
        {
            try
            {
                // Make a GET request to the microservice's endpoint
                HttpResponseMessage tetrisResponse = await _httpClient.GetAsync("https://localhost:2626/Tetris"); // URL might need to change for deployment 
                HttpResponseMessage snakeResponse = await _httpClient.GetAsync("https://localhost:1948/Snake");
                HttpResponseMessage pongResponse = await _httpClient.GetAsync("https://localhost:1941/Pong");

                // Check if the request was successful
                if (tetrisResponse.IsSuccessStatusCode && snakeResponse.IsSuccessStatusCode && pongResponse.IsSuccessStatusCode)
                {
                    // Deserialize the response content to a list of GameInfo objects
                    var tetrisInfoList = await tetrisResponse.Content.ReadAsAsync<List<GameInfo>>();
                    var snakeInfoList = await snakeResponse.Content.ReadAsAsync<List<GameInfo>>();
                    var pongInfoList = await pongResponse.Content.ReadAsAsync<List<GameInfo>>();
                    var gameInfoList = new List<GameInfo>();
                    gameInfoList.AddRange(tetrisInfoList);
                    gameInfoList.AddRange(snakeInfoList);
                    gameInfoList.AddRange(pongInfoList);
                    return gameInfoList;
                }
                else
                {
                    _logger.LogError($"Failed to retrieve data from microservice. Status code: {tetrisResponse.StatusCode}");
                    // Return a placeholder list of GameInfo objects indicating failure
                    return GenerateFailureResponse();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching data from microservice: {ex.Message}");
                // Return a placeholder list of GameInfo objects indicating failure
                return GenerateFailureResponse();
            }
        }

        /// <summary>
        /// Generates a placeholder list of GameInfo objects indicating failure to retrieve data.
        /// </summary>
        /// <returns>A collection of GameInfo objects indicating failure.</returns>
        private IEnumerable<GameInfo> GenerateFailureResponse()
        {
            // Using IEnumerable allows flexibility in returning a placeholder response.
            // It allows the method to return different types of collections (e.g., List, Array) if needed in the future.
            // In this case, IEnumerable provides a simple way to return a list of failed responses.

            // Generate a placeholder list of GameInfo objects indicating failure to retrieve data
            return new List<GameInfo>
            {
                new GameInfo
                {
                    Title = "Failed to retrieve from Microservice",
                    Author = "Failed to retrieve from Microservice",
                    Description = "Failed to retrieve from Microservice",
                    HowTo = "Failed to retrieve from Microservice",
                    LeaderBoardStack = new Stack<KeyValuePair<string, int>>() // Initializing an empty stack
                }
            };
        }
    }
}
