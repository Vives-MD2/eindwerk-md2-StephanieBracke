using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.BLL.Managers;
using VidyaBase.DOMAIN;

namespace VidyaBase.RestApi.Controllers
{
    public class WishlistController : ControllerBase
    {
        private readonly WishlistManager _wishlistManager = new WishlistManager();

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            try
            {
                Wishlist wishlist = await _wishlistManager.GetByIdAsync(id);
                return Ok(new JsonResult(wishlist));
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

                IEnumerable<Wishlist> wishlists = await _wishlistManager.GetAsync(skip, take);
                return Ok(new JsonResult(wishlists));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Wishlist wishlist)
        {
            try
            {
                if (wishlist == null)
                    throw new NullReferenceException();

                wishlist = await _wishlistManager.CreateAsync(wishlist);
                return Ok(new JsonResult(wishlist));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Wishlist wishlist)
        {
            try
            {
                if (wishlist == null)
                    throw new NullReferenceException();

                wishlist = await _wishlistManager.UpdateAsync(wishlist);
                return Ok(new JsonResult(wishlist));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Wishlist wishlist)
        {
            try
            {
                if (wishlist == null)
                    throw new NullReferenceException();

                wishlist = await _wishlistManager.DeleteAsync(wishlist);
                return Ok(new JsonResult(wishlist));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
