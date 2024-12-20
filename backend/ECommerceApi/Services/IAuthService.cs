using ECommerceApi.Models;
using ECommerceApi.DTOs;

namespace ECommerceApi.Services;

public interface IAuthService
{
    Task<AuthResponse?> LoginAsync(LoginRequest request);
    string GenerateJwtToken(User user);
}