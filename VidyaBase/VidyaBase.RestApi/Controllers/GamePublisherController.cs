using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.BLL.Managers;
using VidyaBase.DOMAIN;

namespace VidyaBase.RestApi.Controllers
{
    public class GamePublisherController : ControllerBase
    {
        private readonly GamePublisherManager _gamePublisherManager = new GamePublisherManager();

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            try
            {
                GamePublisher gamePublisher = await _gamePublisherManager.GetByIdAsync(id);
                return Ok(new JsonResult(gamePublisher));
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

                IEnumerable<GamePublisher> gamePublishers = await _gamePublisherManager.GetAsync(skip, take);
                return Ok(new JsonResult(gamePublishers));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] GamePublisher gamePublisher)
        {
            try
            {
                if (gamePublisher == null)
                    throw new NullReferenceException();

                gamePublisher = await _gamePublisherManager.CreateAsync(gamePublisher);
                return Ok(new JsonResult(gamePublisher));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] GamePublisher gamePublisher)
        {
            try
            {
                if (gamePublisher == null)
                    throw new NullReferenceException();

                gamePublisher = await _gamePublisherManager.UpdateAsync(gamePublisher);
                return Ok(new JsonResult(gamePublisher));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] GamePublisher gamePublisher)
        {
            try
            {
                if (gamePublisher == null)
                    throw new NullReferenceException();

                gamePublisher = await _gamePublisherManager.DeleteAsync(gamePublisher);
                return Ok(new JsonResult(gamePublisher));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
