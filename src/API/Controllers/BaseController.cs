using AutoMapper;
using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IManager _repository;
        protected readonly ILoggerManager _logger;
        protected readonly IMapper _mapper;
        private UserManager<User> _userManager;

        public BaseController(IManager repository, ILoggerManager logger, IMapper mapper,UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<User> GetUser()
        { 
            return await _userManager.FindByNameAsync(HttpContext?.User?.Identity?.Name);
        }
    }
}
