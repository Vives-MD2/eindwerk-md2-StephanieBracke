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
    public class CollectionController : ControllerBase
    {
        private readonly CollectionManager _collectionManager = new CollectionManager();

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            try
            {
                Collection collection = await _collectionManager.GetByIdAsync(id);
                return Ok(new JsonResult(collection));
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

                IEnumerable<Collection> collections = await _collectionManager.GetAsync(skip, take);
                return Ok(new JsonResult(collections));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Collection collection)
        {
            try
            {
                if (collection == null)
                    throw new NullReferenceException();

                collection = await _collectionManager.CreateAsync(collection);
                return Ok(new JsonResult(collection));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Collection collection)
        {
            try
            {
                if (collection == null)
                    throw new NullReferenceException();

                collection = await _collectionManager.UpdateAsync(collection);
                return Ok(new JsonResult(collection));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Collection collection)
        {
            try
            {
                if (collection == null)
                    throw new NullReferenceException();

                collection = await _collectionManager.DeleteAsync(collection);
                return Ok(new JsonResult(collection));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
