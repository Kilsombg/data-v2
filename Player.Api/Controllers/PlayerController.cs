using Microsoft.AspNetCore.Mvc;
using PrettoPall.Api.Services;
using PrettoPall.Data.Models;

namespace PrettoPall.Api.Controllers
{
    [ApiController]
    [Route("api/player")]
    public class PlayerController : ControllerBase
    {

        private readonly MongoDBService mongoDBService;

        public PlayerController(MongoDBService mongoDBService)
        {
            this.mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<Player>> Get() {
            return await mongoDBService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Player player) {
            await mongoDBService.CreateAsync(player);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId) {
                await mongoDBService.AddToPlaylistAsync(id, movieId);
                return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) {
            return Ok();
        }

    }
}

