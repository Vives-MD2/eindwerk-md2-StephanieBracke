using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.BLL.Managers;
using VidyaBase.DOMAIN;

namespace VidyaBase.RestApi.Controllers
{
    public class PublisherController : ControllerBase
    {
        private readonly PublisherManager _publisherManager = new PublisherManager();

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            try
            {
                Publisher publisher = await _publisherManager.GetByIdAsync(id);
                return Ok(new JsonResult(publisher));
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

                IEnumerable<Publisher> publishers = await _publisherManager.GetAsync(skip, take);
                return Ok(new JsonResult(publishers));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Publisher publisher)
        {
            try
            {
                if (publisher == null)
                    throw new NullReferenceException();

                publisher = await _publisherManager.CreateAsync(publisher);
                return Ok(new JsonResult(publisher));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Publisher publisher)
        {
            try
            {
                if (publisher == null)
                    throw new NullReferenceException();

                publisher = await _publisherManager.UpdateAsync(publisher);
                return Ok(new JsonResult(publisher));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Publisher publisher)
        {
            try
            {
                if (publisher == null)
                    throw new NullReferenceException();

                publisher = await _publisherManager.DeleteAsync(publisher);
                return Ok(new JsonResult(publisher));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
