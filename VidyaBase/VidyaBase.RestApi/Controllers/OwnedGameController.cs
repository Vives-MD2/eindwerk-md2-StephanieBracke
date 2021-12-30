using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.BLL.Managers;
using VidyaBase.DOMAIN;

namespace VidyaBase.RestApi.Controllers
{
    public class OwnedGameController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CollectionOwnedGameController : ControllerBase
        {
            private readonly OwnedGameManager _ownedGameManager = new OwnedGameManager();

            [HttpGet("GetById")]
            public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
            {
                try
                {
                    OwnedGame ownedGame = await _ownedGameManager.GetByIdAsync(id);
                    return Ok(new JsonResult(ownedGame));
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

                    IEnumerable<OwnedGame> ownedGames = await _ownedGameManager.GetAsync(skip, take);
                    return Ok(new JsonResult(ownedGames));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPost("Create")]
            public async Task<IActionResult> Create([FromBody] OwnedGame ownedGame)
            {
                try
                {
                    if (ownedGame == null)
                        throw new NullReferenceException();

                    ownedGame = await _ownedGameManager.CreateAsync(ownedGame);
                    return Ok(new JsonResult(ownedGame));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPut("Update")]
            public async Task<IActionResult> Update([FromBody] OwnedGame ownedGame)
            {
                try
                {
                    if (ownedGame == null)
                        throw new NullReferenceException();

                    ownedGame = await _ownedGameManager.UpdateAsync(ownedGame);
                    return Ok(new JsonResult(ownedGame));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpDelete("Delete")]
            public async Task<IActionResult> Delete([FromBody] OwnedGame ownedGame)
            {
                try
                {
                    if (ownedGame == null)
                        throw new NullReferenceException();

                    ownedGame = await _ownedGameManager.DeleteAsync(ownedGame);
                    return Ok(new JsonResult(ownedGame));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
