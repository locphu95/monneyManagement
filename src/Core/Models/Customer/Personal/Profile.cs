using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Customer.Personal
{
    [Table("profile")]
    public class Profile : BaseEntity
    {
        public string? UserID { get; set; }
        public string? Job { get; set; }
        public string? PosionId { get; set; }
        public string? Logo { get; set; }
    }
}