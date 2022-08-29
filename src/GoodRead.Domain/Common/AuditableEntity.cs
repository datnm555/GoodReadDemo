using System.ComponentModel.DataAnnotations;

namespace GoodRead.Domain.Common
{
    public class AuditableEntity
    {
        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(50)]
        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
