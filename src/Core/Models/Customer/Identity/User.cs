using Microsoft.AspNetCore.Identity;

namespace Core.Models.Customer.Identity
{
    public class User : IdentityUser
    {
        public bool? IsUserCorporation { get; set; }
        //userId of user Corp
        public string? CorporationId { get; set; }
        public string? ContractId { get; set; }
    }
}