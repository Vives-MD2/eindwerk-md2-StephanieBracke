using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.BLL.Managers;
using VidyaBase.DOMAIN;

namespace VidyaBase.RestApi.Controllers
{
    public class UserAchievementController : ControllerBase
    {
        private readonly UserAchievementManager _userAchievementManager = new UserAchievementManager();

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            try
            {
                UserAchievement userAchievement = await _userAchievementManager.GetByIdAsync(id);
                return Ok(new JsonResult(userAchievement));
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

                IEnumerable<UserAchievement> userAchievements = await _userAchievementManager.GetAsync(skip, take);
                return Ok(new JsonResult(userAchievements));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserAchievement userAchievement)
        {
            try
            {
                if (userAchievement == null)
                    throw new NullReferenceException();

                userAchievement = await _userAchievementManager.CreateAsync(userAchievement);
                return Ok(new JsonResult(userAchievement));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UserAchievement userAchievement)
        {
            try
            {
                if (userAchievement == null)
                    throw new NullReferenceException();

                userAchievement = await _userAchievementManager.UpdateAsync(userAchievement);
                return Ok(new JsonResult(userAchievement));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] UserAchievement userAchievement)
        {
            try
            {
                if (userAchievement == null)
                    throw new NullReferenceException();

                userAchievement = await _userAchievementManager.DeleteAsync(userAchievement);
                return Ok(new JsonResult(userAchievement));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
