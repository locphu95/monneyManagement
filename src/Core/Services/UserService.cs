using AutoMapper;
using Core.Models.Dtos.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Core
{
    public class UserService : IUser
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private User? _user;
        protected readonly ILoggerManager _logger;

        public UserService(UserManager<User> userManager, IConfiguration configuration, IMapper mapper, ILoggerManager logger)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<UpdateProfileRequestResponse> UpdateProfile(UpdateProfileRequest userForRegistration)
        {
            //
            throw new NotImplementedException();
        }

        public Task<UploadLogoResponse> UploadImage(UploadLogoRequest updateProfileRequest)
        {

            throw new NotImplementedException();
        }
    }
}