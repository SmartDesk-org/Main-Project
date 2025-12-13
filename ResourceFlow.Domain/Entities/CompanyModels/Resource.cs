using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.CompanyModels
{
    public class Resource:BaseEntity
    {
        public int Id { get; set; }

        public string ResourceName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public int CompanyId { get; set; }

        public virtual CompanyDetails Company { get; set; }
    }
}
