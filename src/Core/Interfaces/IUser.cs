using Core.Models.Dtos.Users;

namespace Core
{
    public interface IUser : IDisposable
    {
        Task<UpdateProfileRequestResponse> UpdateProfile(User userinfo,UpdateProfileRequest userForRegistration);
        
    }
}