//using Microsoft.AspNetCore.Mvc;
//using ResourceFlow.Application.Common;
//using ResourceFlow.Application.DTOs.ClientMessages;
//using ResourceFlow.Application.Interfaces.ClientMessages;
//using ResourceFlow.Application.Interfaces.Repositories;
//using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
//using ResourceFlow.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ResourceFlow.Application.Services.ClientMessages
//{
//    public  class ClientComplaintService:IClientComplaintService
//    {
//        private readonly IGenericRepository<ClientComplaint> _complaintRepo;
//        private readonly IUserDapperRepository _userDapperRepo;
//        private readonly ICompanyDapperRepository _companyDapperRepo;
//        private readonly
//        public ClientComplaintService(
//            IGenericRepository<ClientComplaint> complaintRepo,
//            IUserDapperRepository userDapperRepo,
//            ICompanyDapperRepository companyDapperRepo
//            )
//        {
//            _complaintRepo = complaintRepo;
//            _userDapperRepo = userDapperRepo;
//            _companyDapperRepo = companyDapperRepo;
//        }
//        public async Task<Response<CreateClientComplaintDto> CreateComplaint(int userId,CreateClientComplaintDto dto)
//        {
//            int companyId = await _userDapperRepo.GetCompanyId(userId);
//            var isAdmin = await _companyDapperRepo.IsUserCompanyAdminAsync(userId, companyId);
//            if (!isAdmin)
//                return new Response<CreateClientComplaintDto>(403, "Only admin can add complaints");

//            var complaint=_ma
//        }
//    }
//}
