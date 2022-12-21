using System.ComponentModel.DataAnnotations;

namespace Core
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
    public class BaseResponse : BaseRequest
    {
        public string? Status { get; set;}
        public string? Message { get; set;}
        public BaseResponse(string requestID)
        {
            RequestTime= DateTime.UtcNow;
            RequestId = requestID;
        }
    }
    public class BaseRequest
    {
        public DateTime? RequestTime { get; set; }
        public string? RequestId { get; set; }
        public string? Channel { get; set; }
    }
}
