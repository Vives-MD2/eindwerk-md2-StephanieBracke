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
    public class CategoryController : ControllerBase
    {
        private readonly CategoryManager _categoryManager = new CategoryManager();

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            try
            {
                Category category = await _categoryManager.GetByIdAsync(id);
                return Ok(new JsonResult(category));
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

                IEnumerable<Category> categories = await _categoryManager.GetAsync(skip, take);
                return Ok(new JsonResult(categories));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            try
            {
                if (category == null)
                    throw new NullReferenceException();

                category = await _categoryManager.CreateAsync(category);
                return Ok(new JsonResult(category));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            try
            {
                if (category == null)
                    throw new NullReferenceException();

                category = await _categoryManager.UpdateAsync(category);
                return Ok(new JsonResult(category));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Category category)
        {
            try
            {
                if (category == null)
                    throw new NullReferenceException();

                category = await _categoryManager.DeleteAsync(category);
                return Ok(new JsonResult(category));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
