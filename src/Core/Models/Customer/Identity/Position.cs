using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Customer.Identity
{
    [Table("position")]
    public class Position : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Action { get; set; }
    }
}