using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("category_expense")]
    public class CategoryExpense : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? RankExpense { get; set; }
        public string? SoucreType { get; set; }
        public string? SoucreName { get; set; }
    }
}