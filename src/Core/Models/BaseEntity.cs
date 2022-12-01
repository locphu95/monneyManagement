using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            Created = DateTime.UtcNow; Updated = DateTime.UtcNow; IsDeleted = false;
        }
    }
}
