namespace ECommerceApi.DTOs;

public record LoginRequest(string Email, string Password);

public class AuthResponse
{
    public required string Token { get; set; }
    public required UserDto User { get; set; }
}

public class UserDto
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
}