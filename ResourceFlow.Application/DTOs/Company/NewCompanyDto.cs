using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Company
{
    public class NewCompanyDto
    {
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public bool IsActive { get; set; } = false;

        [EmailAddress]
        public string? Email { get; set; } = default;

        public string? PassWord { get; set; } = default;
        public string? ConfirmPassword { get; set; } = default;


        public int SelectedSubscriptionId { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }

    }

}
