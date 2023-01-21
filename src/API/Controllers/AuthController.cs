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
            User resoultLogin = await _repository.Authen.ValidateUserAsync(user);
            return resoultLogin is null
                ? Unauthorized()
                : Ok(await _repository.Authen.CreateTokenAsync(resoultLogin));
        }
        [Authorize]
        [HttpPost("refresh-token")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshRequest token)
        {
            RefreshResponse resoultLogin = await _repository.Authen.RefreshToken(token);
            return resoultLogin is null
                ? Unauthorized()
                : Ok(resoultLogin);
        }
        [Authorize]
        [HttpPost]
        [Route("revoke/{username}")]
        public async Task<IActionResult> Revoke(RevokeResquest resquest)
        {
            RevokeResponse response = await _repository.Authen.Revoke(resquest);
            if (response == null) return BadRequest("Invalid user name");
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
        [HttpPost]
        [Route("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest model)
        {
            var userExists = await _repository.Authen.RegisterUserAsync(model);
            if (userExists == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });
            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }

    }

}
