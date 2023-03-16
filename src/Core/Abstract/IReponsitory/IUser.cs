
namespace Core
{
    public interface IUser : IGenericRepository<User>
    {
        Task<UpdateProfileRequestResponse> UpdateProfile(User userInfo,UpdateProfileRequest userForRegistration);
        
    }
}