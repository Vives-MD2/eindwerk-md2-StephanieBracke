using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.BLL.Managers;
using VidyaBase.DOMAIN;

namespace VidyaBase.RestApi.Controllers
{
    public class GameCategoryController : ControllerBase
    {
        private readonly GameCategoryManager _gameCategoryManager = new GameCategoryManager();

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            try
            {
                GameCategory gameCategory = await _gameCategoryManager.GetByIdAsync(id);
                return Ok(new JsonResult(gameCategory));
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

                IEnumerable<GameCategory> gameCategories = await _gameCategoryManager.GetAsync(skip, take);
                return Ok(new JsonResult(gameCategories));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] GameCategory gameCategory)
        {
            try
            {
                if (gameCategory == null)
                    throw new NullReferenceException();

                gameCategory = await _gameCategoryManager.CreateAsync(gameCategory);
                return Ok(new JsonResult(gameCategory));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] GameCategory gameCategory)
        {
            try
            {
                if (gameCategory == null)
                    throw new NullReferenceException();

                gameCategory = await _gameCategoryManager.UpdateAsync(gameCategory);
                return Ok(new JsonResult(gameCategory));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] GameCategory gameCategory)
        {
            try
            {
                if (gameCategory == null)
                    throw new NullReferenceException();

                gameCategory = await _gameCategoryManager.DeleteAsync(gameCategory);
                return Ok(new JsonResult(gameCategory));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
