namespace Core.Models.Dtos.Auth
{
    public class RevokeResquest :BaseRequest
    {
        public string? UserName { get; set; }
    }
    public class RevokeResponse : BaseResponse
    {
        public RevokeResponse(string? requestID,string? channel) : base(requestID,channel)
        {
        }
    }

}
