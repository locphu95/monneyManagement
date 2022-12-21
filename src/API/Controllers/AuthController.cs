using AutoMapper;
using Core;
using Core.Models.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
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
        [HttpPost("refresh-token")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshRequest token)
        {
            RefreshResponse resoultLogin = await _repository.Authen.RefreshToken(token);
            return resoultLogin is null
                ? Unauthorized()
                : Ok(await _repository.Authen.RefreshToken(token));
        }
    }

}
