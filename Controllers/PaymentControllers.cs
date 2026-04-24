using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ott.Dto;
using Ott.Services;
using System.Security.Claims;

[ApiController]
[Route("api/subscription")]
[Authorize]
public class SubscriptionController : ControllerBase
{
    private readonly PaymentService _paymentService;

    public SubscriptionController(PaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    private int GetUserId()
    {
        return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
    }

    // POST: /api/subscription/create
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreatePaymentDTO dto)
    {
        var result = await _paymentService.CreateSubscription(GetUserId(), dto);
        return Ok(result);
    }

    // GET: /api/subscription/status
    [HttpGet("status")]
    public async Task<IActionResult> Status()
    {
        var isActive = await _paymentService.GetSubscriptionStatus(GetUserId());

        return Ok(new
        {
            IsActive = isActive
        });
    }
}