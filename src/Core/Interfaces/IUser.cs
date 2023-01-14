using Core.Models.Dtos.Users;

namespace Core
{
    public interface IUser
    {
        Task<UpdateProfileRequestResponse> UpdateProfile(UpdateProfileRequest userForRegistration);
        Task<UploadLogoResponse> UploadImage(UploadLogoRequest updateProfileRequest);
    }
}