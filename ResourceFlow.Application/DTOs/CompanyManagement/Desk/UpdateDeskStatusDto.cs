using ResourceFlow.Domain.Enums.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.CompanyManagement.Desk
{
    public class UpdateDeskStatusDto
    {
        public ResourceStatus Status { get; set; }
    }
}
