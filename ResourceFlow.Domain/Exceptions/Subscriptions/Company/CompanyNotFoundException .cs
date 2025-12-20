using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Exceptions.Subscriptions.Company
{
   
        public sealed class CompanyNotFoundException : Exception
        {
            public CompanyNotFoundException(int companyId)
                : base($"Company with id '{companyId}' was not found.")
            {
            }
        }
    
}
