using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Core.Services
{
    public class Manager : IManager
    {
        private RepositoryContext _repositoryContext;
        private IUserAuth _userAuth;


        private UserManager<User> _userManager;
        private IMapper _mapper;
        private IConfiguration _configuration;
        protected readonly ILoggerManager _logger;


        public Manager(RepositoryContext repositoryContext, UserManager<User> userManager, IMapper mapper, IConfiguration configuration, ILoggerManager logger)
        {
            _repositoryContext = repositoryContext;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }

        public IUserAuth Authen
        {
            get
            {
                if (_userAuth is null)
                    _userAuth = new UserAuth(_userManager, _configuration, _mapper,_logger);
                return _userAuth;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();

    }


}
