using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.BLL.Managers;
using VidyaBase.DOMAIN;

namespace VidyaBase.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionOwnedGameController : ControllerBase
    {
        private readonly CollectionOwnedGameManager _collectionOwnedGameManager = new CollectionOwnedGameManager();

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            try
            {
                CollectionOwnedGame collectionOwnedGame = await _collectionOwnedGameManager.GetByIdAsync(id);
                return Ok(new JsonResult(collectionOwnedGame));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery(Name = "skip")] int skip, [FromQuery(Name = "take")] int take)
        {
            try
            {
                if (take == 0)
                    take = 1;

                IEnumerable<CollectionOwnedGame> collectionOwnedGames = await _collectionOwnedGameManager.GetAsync(skip, take);
                return Ok(new JsonResult(collectionOwnedGames));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CollectionOwnedGame collectionOwnedGame)
        {
            try
            {
                if (collectionOwnedGame == null)
                    throw new NullReferenceException();

                collectionOwnedGame = await _collectionOwnedGameManager.CreateAsync(collectionOwnedGame);
                return Ok(new JsonResult(collectionOwnedGame));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CollectionOwnedGame collectionOwnedGame)
        {
            try
            {
                if (collectionOwnedGame == null)
                    throw new NullReferenceException();

                collectionOwnedGame = await _collectionOwnedGameManager.UpdateAsync(collectionOwnedGame);
                return Ok(new JsonResult(collectionOwnedGame));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] CollectionOwnedGame collectionOwnedGame)
        {
            try
            {
                if (collectionOwnedGame == null)
                    throw new NullReferenceException();

                collectionOwnedGame = await _collectionOwnedGameManager.DeleteAsync(collectionOwnedGame);
                return Ok(new JsonResult(collectionOwnedGame));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

