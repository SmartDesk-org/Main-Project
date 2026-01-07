using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Feedback;
using ResourceFlow.Domain.Entities.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Feedbacks
{
    public  interface IFeedbackservice
    {
        Task<Response<IEnumerable<FeedbackResponseDto>>> GetAllAsync();
        Task<Response<IEnumerable<FeedbackResponseDto>>> GetPublishedAsync();
        Task<Response<IEnumerable<FeedbackResponseDto>>> GetAllForCompany( int  userId);
        Task<Response<Feedback>> CreateAsync(NewFeedbackDto dto, int userId);
        Task<Response<bool>> TogglePublishAsync(int feedbackId);
        Task<Response<bool>> DeleteAsync(int feedbackId);
    }
}
