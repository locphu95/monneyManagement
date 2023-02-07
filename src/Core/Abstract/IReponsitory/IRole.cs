

namespace Core
{
    public interface IRole : IDisposable
    {
        Task<UpdateProfileRequestResponse> Create(User userInfo,UpdateProfileRequest userForRegistration);
        
    }
}