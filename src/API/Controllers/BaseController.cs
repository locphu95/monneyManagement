using AutoMapper;
using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IManager Repository;
        protected readonly ILoggerManager Logger;
        protected readonly IMapper Mapper;
        private readonly UserManager<User> _userManager;

        public BaseController(IManager repository, ILoggerManager logger, IMapper mapper,UserManager<User> userManager)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            _userManager = userManager;
        }
        [NonAction]
        public async Task<User> GetUser()
        { 
            return await _userManager.FindByNameAsync(HttpContext?.User?.Identity?.Name);
        }
    }
}
