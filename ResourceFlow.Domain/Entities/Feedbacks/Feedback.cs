using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.Feedbacks
{
    public  class Feedback:BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public bool IsPublished { get; set; } = false;
        public CompanyDetails? Company { get; set; }

    }
}
