using ResourceFlow.Application.DTOs.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories.DapperRepository
{
    public interface IHistoryDapperRepository
    {
        Task<IEnumerable<HistoryResponseDto>> GetAllHistoryAsync(int companyId);
    }
}
