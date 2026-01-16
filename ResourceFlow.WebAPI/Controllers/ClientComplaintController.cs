//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ResourceFlow.Application.DTOs.ClientMessages;
//using ResourceFlow.Application.Interfaces.ClientMessages;
//using ResourceFlow.Infrastructure.Extensions;
//using Stripe;

//namespace ResourceFlow.WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ClientComplaintController : ControllerBase
//    {
//        private readonly IClientComplaintService _service;
//        public ClientComplaintController(IClientComplaintService service)
//        {
//            _service = service;
//        }
//        [HttpPost]
//        public async Task<IActionResult> CreateComplaint(CreateClientComplaintDto dto)
//        {
//            var userId = User.GetUserId();
//            var res =await  _service.CreateComplaintAsync(userId, dto);
//            //return StatusCode(res.StatusCode, res);
//        }

//        [HttpGet]
//        public async  Task<IActionResult> GetAll( )
//        {
//            var userId = User.GetUserId();
//            var res =await  _service.CreateComplaintAsync(userId);
//            return StatusCode(res.StatusCode, res);
//        }


//        [HttpGet("{complainId}")]
//        public async  Task<IActionResult> GetById(int complainId)
//        {
//            var userId = User.GetUserId();
//            var res = await _service.CreateComplaintAsync(userId , complainId);
//            return StatusCode(res.StatusCode, res);
//        }

//        [HttpPut("{complainId}")]
//        public async Task<IActionResult> ToggleResolved(int complaintId)
//        {
//            var userId = User.GetUserId();
//            var res = await _service.CreateComplaintAsync(userId,complaintId);
//            return StatusCode(res.StatusCode, res);
//        }

//        [HttpDelete]
//        public async Task<IActionResult> Delete(int complaintId)
//        {
//            var userId = User.GetUserId();
//            var res = await _service.CreateComplaintAsync(userId, complaintId);
//            return StatusCode(res.StatusCode, res);
//        }
//    }
//}
