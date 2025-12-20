using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories.DapperRepository
{
    public interface ICompanyDapperRepository
    {
        Task<CompanyDetails> GetAllCompany();
        Task<CompanyDetails> GetCompanyByCompanyId(int id);
       
    }
}
