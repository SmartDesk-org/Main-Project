using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.History;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.History
{
    public interface IHistoryService
    {
        Task<Response<IEnumerable<HistoryResponseDto>>> GetAllHistoryAsync(int companyId);
    }
}
