namespace Core.Models.Dtos.Auth
{
    public class RefreshRequest : BaseRequest
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
    public class RefreshResponse : BaseResponse
    {
        public RefreshResponse(string requestID,string channelId) : base(requestID, channelId)
        {
        }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
