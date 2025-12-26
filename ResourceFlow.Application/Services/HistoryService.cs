using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.History;
using ResourceFlow.Application.Interfaces.History;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services
{
    public class HistoryService:IHistoryService
    {
        private readonly IHistoryDapperRepository _historyDapperRepo;
        public HistoryService(IHistoryDapperRepository historyDapperRepo)
        {
            _historyDapperRepo = historyDapperRepo;
        }
        public async Task<Response<IEnumerable<HistoryResponseDto>>> GetAllHistoryAsync(int companyId)
        {
            var result = await _historyDapperRepo.GetAllHistoryAsync(companyId);

            if (result == null || !result.Any())
                return new Response<IEnumerable<HistoryResponseDto>>(
                    200, "No history found", Enumerable.Empty<HistoryResponseDto>()
                );

            return new Response<IEnumerable<HistoryResponseDto>>(
                200, "History fetched successfully", result
            );
        }

    }
}
