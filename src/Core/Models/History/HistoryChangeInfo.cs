using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("history_change_info")]
    public class HistoryChangeInfo : BaseEntity
    {
        public string? UserID { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? ActionType { get; set; }
        public string? DataNew { get; set; }
        public string? DataOld { get; set; }
    }
}