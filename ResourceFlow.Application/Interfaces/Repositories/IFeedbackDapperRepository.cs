using ResourceFlow.Application.DTOs.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories
{
    public  interface IFeedbackDapperRepository
    {
        Task<IEnumerable<FeedbackResponseDto>> GetAllAsync();
        Task<IEnumerable<FeedbackResponseDto>> GetPublishedAsync();
        Task<IEnumerable<FeedbackResponseDto>> GetByCompanyAsync(int companyId);
    }
}
