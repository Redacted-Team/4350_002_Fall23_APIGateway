using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Gateway
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private static readonly List<GameInfo> TheInfo = new List<GameInfo>
        {
            new GameInfo { 
                //Id = 1,
                Title = "Snake",
                //Content = "~/js/snake.js",
                Author = "Fall 2023 Semester",
                DateAdded = "",
                Description = "Snake is a classic arcade game that challenges the player to control a snake-like creature that grows longer as it eats apples. The player must avoid hitting the walls or the snake's own body, which can end the game.\r\n",
                HowTo = "Control with arrow keys.",
                //Thumbnail = "/images/snake.jpg" //640x360 resolution
                LeaderBoardStack = new Stack<KeyValuePair<string, int>>(),

    },
            new GameInfo { 
                //Id = 2,
                Title = "Tetris",
                //Content = "~/js/tetris.js",
                Author = "Fall 2023 Semester",
                DateAdded = "",
                Description = "Tetris is a classic arcade puzzle game where the player has to arrange falling blocks, also known as Tetronimos, of different shapes and colors to form complete rows on the bottom of the screen. The game gets faster and harder as the player progresses, and ends when the Tetronimos reach the top of the screen.",
                HowTo = "Control with arrow keys: Up arrow to spin, down to speed up fall, space to insta-drop.",
                //Thumbnail = "/images/tetris.jpg"
                LeaderBoardStack = new Stack<KeyValuePair<string, int>>(),
                
            },
            new GameInfo { 
                //Id = 3,
                Title = "Pong",
                //Content = "~/js/pong.js",
                Author = "Fall 2023 Semester",
                DateAdded = "",
                Description = "Pong is a classic arcade game where the player uses a paddle to hit a ball against a computer's paddle. Either party scores when the ball makes it past the opponent's paddle.",
                HowTo = "Control with arrow keys.",
                //Thumbnail = "/images/pong.jpg"
                LeaderBoardStack = new Stack<KeyValuePair<string, int>>(),
            },

        };

        public async Task<GameInfo[]> GetGamesAsync()
        {
            try
            {
                var responseMessage = await this.client.GetAsync("/Micro");

                if (responseMessage != null)
                {
                    var stream = await responseMessage.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<GameInfo[]>(stream, options);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
            }
            return new GameInfo[] { };
        }

        private readonly ILogger<GatewayController> _logger;

        public GatewayController(ILogger<GatewayController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<GameInfo> Get()
        {
            return TheInfo;
        }
    }
}