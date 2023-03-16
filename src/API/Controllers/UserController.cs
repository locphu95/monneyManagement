using AutoMapper;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager) : base(repository, logger, mapper, userManager)
        {
        }

        [Authorize]
        [HttpPost("update-profile")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest userProfile)
        {
            var getUser = await GetUser();
            if (getUser.Id != userProfile.UserID)
                return Unauthorized();
            var resultLogin = await Repository.UserService.UpdateProfile(getUser, userProfile);
            return Ok(resultLogin);
        }
    }
}