using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.BLL.Managers;
using VidyaBase.DOMAIN;

namespace VidyaBase.RestApi.Controllers
{
    public class GameController : ControllerBase
    {
        private readonly GameManager _gameManager = new GameManager();

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            try
            {
                Game game= await _gameManager.GetByIdAsync(id);
                return Ok(new JsonResult(game));
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

                IEnumerable<Game> games= await _gameManager.GetAsync(skip, take);
                return Ok(new JsonResult(games));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Game game)
        {
            try
            {
                if (game == null)
                    throw new NullReferenceException();

                game= await _gameManager.CreateAsync(game);
                return Ok(new JsonResult(game));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Game game)
        {
            try
            {
                if (game == null)
                    throw new NullReferenceException();

                game = await _gameManager.UpdateAsync(game);
                return Ok(new JsonResult(game));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Game game)
        {
            try
            {
                if (game == null)
                    throw new NullReferenceException();

                game = await _gameManager.DeleteAsync(game);
                return Ok(new JsonResult(game));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
