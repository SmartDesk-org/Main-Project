using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Payments;
using ResourceFlow.Application.Interfaces.Company;
using ResourceFlow.Application.Services.Company;
using ResourceFlow.Application.Services.Payments;

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
        [AllowAnonymous]
        [HttpPost("create-intent")]
        public async Task<IActionResult> CreateIntent([FromBody] CreatePaymentIntentRequestDto dto)
        {
            var res = await _paymentService.CreatePaymentIntent(dto.CompanyId);
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpPost("confirm")]
        public async Task<IActionResult> Confirm([FromBody] ConfirmPaymentRequestDto dto)
        {
            var res = await _paymentService.ConfirmPaymentAsync(dto.PaymentIntentId, dto.CompanyId);

            

             await _companyService.ActivateCompanyAsync(dto.CompanyId);

            return StatusCode(res.StatusCode, res);
        }
    }
}
