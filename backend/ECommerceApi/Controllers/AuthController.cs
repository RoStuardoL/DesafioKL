using Microsoft.AspNetCore.Mvc;
using ECommerceApi.Services;
using ECommerceApi.DTOs;

namespace ECommerceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(LoginRequest request)
    {
        var response = await _authService.LoginAsync(request);
        
        if (response == null)
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        return Ok(response);
    }
}