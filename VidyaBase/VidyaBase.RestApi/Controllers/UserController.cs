using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VidyaBase.BLL;
using VidyaBase.DOMAIN;
using VidyaBase.UI.HelperModels;

namespace VidyaBase.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager _userManager = new UserManager();

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] int id)
        {
            Console.WriteLine("Accessed GetById method");

            try
            {
                User user= await _userManager.GetByIdAsync(id);
                return Ok(new JsonResult(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByEmail([FromQuery(Name = "email")] string email)
        {
            try
            {
                User user = await _userManager.GetByEmailAsync(email);
                return Ok(new JsonResult(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery(Name = "skip")] int skip = 0, [FromQuery(Name = "take")] int take = 50)
        {
            try
            {
                if (take == 0)
                    take = 1;

                IEnumerable<User> users = await _userManager.GetAsync(skip, take);
                return Ok(new JsonResult(users));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserHelper user)
        {
            Console.WriteLine("Accessed Create method");

            try
            {
                if (user == null)
                    throw new NullReferenceException();

                var convertedUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email
                    
                };
                Console.WriteLine(convertedUser.Email);

                var dbUser= await _userManager.CreateAsync(convertedUser);
                return Ok(new JsonResult(dbUser));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            Console.WriteLine("Accessed Update method");

            try
            {
                if (user == null)
                    throw new NullReferenceException();

                user = await _userManager.UpdateAsync(user);
                return Ok(new JsonResult(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] User user)
        {
            Console.WriteLine("Accessed Delete method");

            try
            {
                if (user == null)
                    throw new NullReferenceException();

                user = await _userManager.DeleteAsync(user);
                return Ok(new JsonResult(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
