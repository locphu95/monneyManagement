using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("category_income")]
    public class CategoryInCome : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? RankImcome { get; set; }
        public string? SoucreType { get; set; }
        public string? SoucreName { get; set; }
    }
}