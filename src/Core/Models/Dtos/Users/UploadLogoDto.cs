using Microsoft.AspNetCore.Http;

namespace Core.Models.Dtos.Users
{
    public class UploadLogoRequest : BaseRequest
    {
        public string? UserId { get; set; }
        public IFormFile? Logo { get; set;}
    }
    public class UploadLogoResponse : BaseResponse
    {
        public UploadLogoResponse(string requestID, string channelId) : base(requestID, channelId)
        {
        }
    }
}