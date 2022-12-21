using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos.Auth
{
    public class LoginRequest : BaseRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
    public class LoginResponse : BaseResponse
    {
        public LoginResponse(string requestID) : base(requestID)
        {
        }

        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public int? Expiration { get; set; }
    }
}

