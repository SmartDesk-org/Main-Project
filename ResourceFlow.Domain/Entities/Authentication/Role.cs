using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceFlow.Domain.Entities;

namespace ResourceFlow.Domain.Entities.Authentication
{
    public class Role : BaseEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
