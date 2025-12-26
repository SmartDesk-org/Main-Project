using AutoMapper;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Feedback;
using ResourceFlow.Application.Interfaces.Feedbacks;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.Feedbacks;
using ResourceFlow.Domain.Enums;

namespace ResourceFlow.Application.Services.Feedbacks
{
    public class FeedbackService : IFeedbackservice
    {
        private readonly IGenericRepository<Feedback> _feedbackRepo;
        IFeedbackDapperRepository _feedbackDapperRepo;
        private readonly IGenericRepository<User> _userRepo;
        private readonly IMapper _mapper;

        public FeedbackService(
            IGenericRepository<Feedback> feedbackRepo,
            IFeedbackDapperRepository feedbackDapperRepo,
            IGenericRepository<User> userRepo,
            IMapper mapper)
        {
            _feedbackRepo = feedbackRepo;
            _feedbackDapperRepo = feedbackDapperRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        // ---------------------------------------------
        // CREATE
        // ---------------------------------------------
        public async Task<Response<Feedback>> CreateAsync(NewFeedbackDto dto,int userId)
        {
            var user = await _userRepo.SingleOrDefaultAsync(u => u.UserId == userId && u.IsDeleted == false && u.RoleId== (int)RoleEnum.CompanyAdmin && u.IsActive == true && u.IsBlocked == false);

            if (user == null)
                return new Response<Feedback>(401, "Only company admin can see feedbacks");

            if (dto == null)
                return new Response<Feedback>(400, "Invalid data");

            var entity = _mapper.Map<Feedback>(dto);
            entity.CompanyId = user.CompanyId ?? 0;
            var result = await _feedbackRepo.AddAsync(entity);

            return new Response<Feedback>(201, "Feedback added successfully", result);
        }

        // ---------------------------------------------
        // GET ALL
        // ---------------------------------------------
        public async Task<Response<IEnumerable<FeedbackResponseDto>>> GetAllAsync()
        {
            var data = await _feedbackDapperRepo.GetAllAsync();

            if (data == null || !data.Any())
                return new Response<IEnumerable<FeedbackResponseDto>>(404, "No feedbacks found");

            return new Response<IEnumerable<FeedbackResponseDto>>(200, "Feedbacks fetched successfully", data);
        }

        // ---------------------------------------------
        // GET PUBLISHED
        // ---------------------------------------------
        public async Task<Response<IEnumerable<FeedbackResponseDto>>> GetPublishedAsync()
        {
            var data = await _feedbackDapperRepo.GetPublishedAsync();

            if (data == null || !data.Any())
                return new Response<IEnumerable<FeedbackResponseDto>>(404, "No published feedbacks found");

            return new Response<IEnumerable<FeedbackResponseDto>>(200, "Published feedbacks fetched", data);
        }

        // ---------------------------------------------
        // TOGGLE PUBLISH
        // ---------------------------------------------
        public async Task<Response<bool>> TogglePublishAsync(int feedbackId)
        {
            var feedback = await _feedbackRepo.GetByIdAsync(feedbackId);

            if (feedback == null)
                return new Response<bool>(404, "Feedback not found");

            feedback.IsPublished = !feedback.IsPublished;
            await _feedbackRepo.UpdateAsync(feedback);

            return new Response<bool>(200, "Publish status updated", true);
        }

        // ---------------------------------------------
        // DELETE (SOFT DELETE)
        // ---------------------------------------------
        public async Task<Response<bool>> DeleteAsync(int feedbackId)
        {
            var feedback = await _feedbackRepo.GetByIdAsync(feedbackId);

            if (feedback == null)
                return new Response<bool>(404, "Feedback not found");

            feedback.IsDeleted = true;
            await _feedbackRepo.UpdateAsync(feedback);

            return new Response<bool>(200, "Feedback deleted successfully", true);
        }

        public async Task<Response<IEnumerable<FeedbackResponseDto>>> GetAllForCompany(int userId)
        {
            var user =await  _userRepo.SingleOrDefaultAsync(u =>u.UserId==userId  && u.RoleId==(int)RoleEnum.CompanyAdmin && u.IsDeleted == false && u.IsActive == true);

            if (user == null)
                return new Response<IEnumerable<FeedbackResponseDto>>(401, "Only company admin can see feedbacks");

            var feedbacks =await  _feedbackDapperRepo.GetByCompanyAsync(user.CompanyId ?? 0);
            if (!feedbacks.Any())
                return new Response<IEnumerable<FeedbackResponseDto>>(404, "No response found");

            return new Response<IEnumerable<FeedbackResponseDto>>(200, "Feedbacks fetched successfully", feedbacks);
        }
    }
}
