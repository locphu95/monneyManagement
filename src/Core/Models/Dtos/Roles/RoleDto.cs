using Microsoft.AspNetCore.Http;

namespace Core
{
    public class AddRoleRequest : BaseRequest
    {
        public string? UserId { get; set; }
        public string? RoleName { get; set; }
    }
    public class AddRoleResponse : BaseResponse
    {
        public AddRoleResponse(string requestID, string channelId) : base(requestID, channelId)
        {
        }
    }
    public class UpdateRoleRequest : BaseRequest
    {
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
    }
    public class UpdateRoleResponse : BaseResponse
    {
        public UpdateRoleResponse(string requestID, string channelId) : base(requestID, channelId)
        {
        }
    }
}