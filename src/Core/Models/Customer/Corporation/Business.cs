using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    [Table("business")]
    public class Business : BaseEntity
    {
        public string? Name { get; set; }
        public decimal RankIncome { get; set; }
        public decimal? RankOutcome { get; set; }
    }
}