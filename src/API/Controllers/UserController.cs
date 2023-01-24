﻿using AutoMapper;
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
            if (getUser is null)
                return Unauthorized();
            else if (getUser.Id != userProfile.UserID)
                return Unauthorized();
            var resoultLogin = await _repository.UserService.UpdateProfile(getUser, userProfile);
            return resoultLogin is null
               ? Unauthorized()
               : Ok(resoultLogin);
        }
    }
}