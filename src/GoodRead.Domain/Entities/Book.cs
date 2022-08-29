using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodRead.Domain.Common;

namespace GoodRead.Domain.Entities
{
    public class Book : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(5000)]
        public string? Description { get; set; }
    }
}
