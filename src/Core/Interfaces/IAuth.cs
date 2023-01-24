using Microsoft.AspNetCore.Identity;

namespace Core
{
    public interface IAuth
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationRequest userForRegistration);
        Task<User> ValidateUserAsync(LoginRequest loginDto);
        Task<LoginResponse> CreateTokenAsync(User user);
        Task<RefreshResponse> RefreshToken(RefreshRequest refreshRequest);
        Task<RevokeResponse> Revoke(RevokeResquest resquest);
        Task<RevokeResponse> RevokeAll();
        
    }
}