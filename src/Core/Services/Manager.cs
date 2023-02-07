using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Core.Services
{
    public class Manager : IManager
    {
        private UserContext _repositoryContext;
        private Auth? _userAuth;
        private UserService? _userService;

        private UserManager<User> _userManager;
        private IMapper _mapper;
        private IConfiguration _configuration;
        protected readonly ILoggerManager _logger;
       

        public Manager(UserContext repositoryContext, UserManager<User> userManager, IMapper mapper, IConfiguration configuration, ILoggerManager logger)
        {
            _repositoryContext = repositoryContext;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }

        public IAuth Auth
        {
            get
            {
                if (_userAuth is null)
                    _userAuth = new Auth(_userManager, _configuration, _mapper, _logger);
                return _userAuth;
            }
        }

        public IUser UserService
        {
            get
            {
                if (_userService is null)
                    _userService = new UserService(_userManager, _configuration, _mapper, _logger);
                return _userService;
            }
        }



        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repositoryContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


}
