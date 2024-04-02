using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Gateway
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GatewayController> _logger;

        public GatewayController(HttpClient httpClient, ILogger<GatewayController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<GameInfo>> Get()
        {
            try
            {
                // Make a GET request to the microservice's endpoint
                HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7223/Micro");

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content to a list of GameInfo objects
                    var gameInfoList = await response.Content.ReadAsAsync<List<GameInfo>>();
                    return gameInfoList;
                }
                else
                {
                    _logger.LogError($"Failed to retrieve data from microservice. Status code: {response.StatusCode}");
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

        private IEnumerable<GameInfo> GenerateFailureResponse()
        {
            // Generate a placeholder list of GameInfo objects indicating failure to retrieve data
            return new List<GameInfo>
            {
                new GameInfo
                {
                    Title = "Failed to retrieve from Microservice",
                    Author = "Failed to retrieve from Microservice",
                    Description = "Failed to retrieve from Microservice",
                    HowTo = "Failed to retrieve from Microservice",
                    LeaderBoardStack = new Stack<KeyValuePair<string, int>>()
                }
            };
        }
    }
}