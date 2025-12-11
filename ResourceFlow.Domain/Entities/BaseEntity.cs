using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ResourceFlow.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; } = null;
        public int? ModifiedBy { get; set; }

        public DateTime? DeletedAt { get; set; } = null;
        public int? DeletedBy { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
