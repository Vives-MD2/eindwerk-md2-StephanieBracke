using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.BLL.Managers;
using VidyaBase.DOMAIN;

namespace VidyaBase.RestApi.Controllers
{
    public class WishlistGameController : ControllerBase
    {
        private readonly WishlistGameManager _wishlistGameManager = new WishlistGameManager();

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            try
            {
                WishlistGame wishlistGame = await _wishlistGameManager.GetByIdAsync(id);
                return Ok(new JsonResult(wishlistGame));
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

                IEnumerable<WishlistGame> wishlistGames = await _wishlistGameManager.GetAsync(skip, take);
                return Ok(new JsonResult(wishlistGames));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] WishlistGame wishlistGame)
        {
            try
            {
                if (wishlistGame == null)
                    throw new NullReferenceException();

                wishlistGame = await _wishlistGameManager.CreateAsync(wishlistGame);
                return Ok(new JsonResult(wishlistGame));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] WishlistGame wishlistGame)
        {
            try
            {
                if (wishlistGame == null)
                    throw new NullReferenceException();

                wishlistGame = await _wishlistGameManager.UpdateAsync(wishlistGame);
                return Ok(new JsonResult(wishlistGame));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] WishlistGame wishlistGame)
        {
            try
            {
                if (wishlistGame == null)
                    throw new NullReferenceException();

                wishlistGame = await _wishlistGameManager.DeleteAsync(wishlistGame);
                return Ok(new JsonResult(wishlistGame));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
