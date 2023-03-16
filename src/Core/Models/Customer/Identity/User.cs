using Microsoft.AspNetCore.Identity;

namespace Core
{
    public class User : IdentityUser
    {
        public bool? IsUserCorporation { get; set; }
        //userId of user Corp
        public string? CorporationId { get; set; }
        public string? ContractId { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string? ChannelId { get; set; }
    }
    //todo add fluent
    // public class FluentUser{
    //     private User  user = new User();
    //     public FluentUser  
    // }
}