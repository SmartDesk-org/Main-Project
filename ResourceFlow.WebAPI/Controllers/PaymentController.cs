using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Payments;
using ResourceFlow.Application.Interfaces.Company;
using ResourceFlow.Application.Services.Company;
using ResourceFlow.Application.Services.Payments;
using ResourceFlow.Infrastructure.Extensions;

namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;
        private readonly ICompanyService _companyService;

        public PaymentController(PaymentService paymentService, ICompanyService companyService)
        {
            _paymentService = paymentService;
            _companyService = companyService;
        }

        [HttpPost("create-intent")]
        public async Task<IActionResult> CreateIntent([FromBody] CreatePaymentIntentRequestDto dto)
        {
            Console.WriteLine($"CompanYidRecieved  {dto.CompanyId}");
            var res = await _paymentService.CreatePaymentIntent(dto.CompanyId);
            return Ok(res);
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> Confirm([FromBody] ConfirmPaymentRequestDto dto)
        {
            var res = await _paymentService.ConfirmPaymentAsync(dto.PaymentIntentId, dto.CompanyId);

            

             await _companyService.ActivateCompanyAsync(dto.CompanyId);

            return StatusCode(res.StatusCode, res);
        }

        [HttpPost("confirmRenewel")]
        public async Task<IActionResult> confirmRenewel([FromBody] ConfirmPaymentRequestDto dto)
        {
            var res = await _paymentService.ConfirmPaymentAsync(dto.PaymentIntentId, dto.CompanyId);

            int userId = User.GetUserId();

            await _companyService.ActivateRenewelAsync(userId);

            return StatusCode(res.StatusCode, res);
        }
    }
}
