using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Exceptions.Subscriptions.Company
{
    public sealed class CompanyInactiveException : Exception
    {
        public CompanyInactiveException(int companyId)
            : base($"Company '{companyId}' is inactive.")
        {
        }
    }
}
