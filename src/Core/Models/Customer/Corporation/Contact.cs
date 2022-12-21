using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    [Table("contact")]
    public class Contact : BaseEntity
    {
        public string? UserID { get; set; }
        public string? Address { get; set; }
        public string? Tax { get; set; }
        public string? Phone { get; set; }
        public string? CorporationName { get; set; }
        public string? Email { get; set; }
    }
}