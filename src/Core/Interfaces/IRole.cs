using Core.Models.Dtos.Users;

namespace Core
{
    public interface IRole
    {
        Task<UpdateProfileRequestResponse> UpdateProfile(User userinfo,UpdateProfileRequest userForRegistration);
        
    }
}