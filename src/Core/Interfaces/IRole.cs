using Core.Models.Dtos.Users;

namespace Core
{
    public interface IRole
    {
        Task<UpdateProfileRequestResponse> Create(User userinfo,UpdateProfileRequest userForRegistration);
        
    }
}