using AutoMapper;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IManager repository, ILoggerManager logger, IMapper mapper,UserManager<User> userManager) : base(repository, logger, mapper,userManager)
        {
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest user)
        {
            User resultLogin = await Repository.Auth.ValidateUserAsync(user);
            return resultLogin is null
                ? Unauthorized()
                : Ok(await Repository.Auth.CreateTokenAsync(resultLogin));
        }
        [Authorize]
        [HttpPost("refresh-token")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshRequest token)
        {
            RefreshResponse resultLogin = await Repository.Auth.RefreshToken(token);
            return Ok(resultLogin);
        }
        [Authorize]
        [HttpPost("revoke/{username}")]
        public async Task<IActionResult> Revoke(RevokeResquest resquest)
        {
           await Repository.Auth.Revoke(resquest);
            return NoContent();
        }

        //[Authorize]
        //[HttpPost]
        //[Route("revoke-all")]
        //public async Task<IActionResult> RevokeAll()
        //{
        //    var users = _userManager.Users.ToList();
        //    foreach (var user in users)
        //    {
        //        user.RefreshToken = null;
        //        await _userManager.UpdateAsync(user);
        //    }

        //    return NoContent();
        //}
        [HttpPost("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest model)
        {
            var userExists = await Repository.Auth.RegisterUserAsync(model);
            if (userExists is null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });
            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }
    }

}
