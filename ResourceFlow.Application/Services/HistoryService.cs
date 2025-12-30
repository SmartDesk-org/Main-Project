using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.History;
using ResourceFlow.Application.Interfaces.History;
 using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;


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
            try
            {
                var result = await _historyDapperRepo.GetAllHistoryAsync(companyId);
                if (result == null || !result.Any())
                    return new Response<IEnumerable<HistoryResponseDto>>(400, "No history as of now ");
                return new Response<IEnumerable<HistoryResponseDto>>(200, "HistoryService fetched succesfully", result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
