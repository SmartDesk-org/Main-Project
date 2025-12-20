using ResourceFlow.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Payments
{
    public  interface IBillingService
    {
        Task<Billing> CreateBill(int companyId, string intentId);
    }
}
