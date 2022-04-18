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
    public class OwnedGameController : ControllerBase
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
                {
                    take = 1;
                }

                IEnumerable<OwnedGame> ownedGames = await _ownedGameManager.GetAsync(skip, take);
                return Ok(new JsonResult(ownedGames));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId([FromQuery(Name = "userId")] int userId, [FromQuery(Name = "skip")] int skip, [FromQuery(Name = "take")] int take)
        {
            var ownedGames = new List<OwnedGame>()
            {
                new OwnedGame
                {
                    UserID = userId,
                    GameID = 1,
                    Game = new Game
                    {
                        ID = 1,
                        EAN = "00000000001",
                        Title = "SimpleMock"
                    }
                },
                new OwnedGame
                {
                    UserID = userId,
                    GameID = 2,
                    Game = new Game
                    {
                        ID = 2,
                        EAN = "00000000001",
                        Title = "Test"
                    }
                }
            };

            return Ok(new JsonResult(ownedGames));

            //try
            //{
            //    if (take == 0)
            //        take = 1;

            //    IEnumerable<OwnedGame> ownedGames = await _ownedGameManager.GetByUserIdAsync(userId, skip, take);
            //    return Ok(new JsonResult(ownedGames));
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
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
