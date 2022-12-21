using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    [Table("detail_expense")]
    public class DetailExpense : BaseEntity
    {
        public string? CategoryIExpenseId { get; set; }
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
        public bool? IsTax { get; set; }
        public bool? TaxPercentage { get; set; }
        public string? Period { get; set; }
        public bool? IsPaymented { get; set; }
        public string? PaymentWithExpenseId { get; set; }
    }
}