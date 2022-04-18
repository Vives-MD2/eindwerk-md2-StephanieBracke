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
    public class AchievementController : ControllerBase
    {
        private readonly AchievementManager _achievementManager = new AchievementManager();

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            try
            {
                Achievement achievement = await _achievementManager.GetByIdAsync(id);
                return Ok(new JsonResult(achievement));
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

                IEnumerable<Achievement> achievements = await _achievementManager.GetAsync(skip, take);
                return Ok(new JsonResult(achievements));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Achievement achievement)
        {
            try
            {
                if (achievement == null)
                    throw new NullReferenceException();

                achievement = await _achievementManager.CreateAsync(achievement);
                return Ok(new JsonResult(achievement));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Achievement achievement)
        {
            try
            {
                if (achievement == null)
                    throw new NullReferenceException();

                achievement = await _achievementManager.UpdateAsync(achievement);
                return Ok(new JsonResult(achievement));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Achievement achievement)
        {
            try
            {
                if (achievement == null)
                    throw new NullReferenceException();

                achievement = await _achievementManager.DeleteAsync(achievement);
                return Ok(new JsonResult(achievement));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
