using Microsoft.AspNetCore.Http;

namespace Core
{
    public class UpdateProfileRequest : BaseRequest
    {
        public string? UserID { get; set; }
        public string? Job { get; set; }
        public string? PosionId { get; set; }
        public IFormFile? Logo { get; set; }
    }
    public class UpdateProfileRequestResponse : BaseResponse
    {
        public UpdateProfileRequestResponse(string requestID, string channelId) : base(requestID, channelId)
        {
        }
    }
}