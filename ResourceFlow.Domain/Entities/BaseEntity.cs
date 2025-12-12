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

<<<<<<< HEAD
        public bool IsDelete { get; set; } = false;

=======
        public bool IsDeleted { get; set; } = false;
>>>>>>> ea69d59f84af7192488e1d468688bfd7e652e26f
    }
}
