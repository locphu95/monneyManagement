using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("config_corp")]
    public class ConfigCorp : BaseEntity
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}