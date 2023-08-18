using AutoMapper;
using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IManager Repository;
        protected readonly ILoggerManager _logger;
        protected readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public BaseController(IManager repository, ILoggerManager Logger, IMapper Mapper,UserManager<User> userManager)
        {
            Repository = repository;
            _logger = Logger;
            _mapper = Mapper;
            _userManager = userManager;
        }
        [NonAction]
        public async Task<User> GetUser()
        { 
            return await _userManager.FindByNameAsync(HttpContext?.User?.Identity?.Name);
        }
    }
}
