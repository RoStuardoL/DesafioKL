using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Models;

public class User
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    [EmailAddress]
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
}