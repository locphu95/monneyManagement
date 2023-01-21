using AutoMapper;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }

        public IActionResult Index()
        {
            return null;
        }

        [Authorize]
        [HttpPost("update-profile")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest userProfile)
        {
            var getUser = this.User;
            //RefreshResponse resoultLogin = await _repository.Authen.RefreshToken(token);
            //return resoultLogin is null
            //    ? Unauthorized()
            //    : Ok(resoultLogin);

            return Ok();
        }
    }
}