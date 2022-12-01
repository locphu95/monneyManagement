using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("detail_income")]
    public class DetailInCome : BaseEntity
    {
        public string? CategoryIncomeId { get; set; }
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
        public bool? IsTax { get; set; }
        public bool? TaxPercentage { get; set; }
    }
}