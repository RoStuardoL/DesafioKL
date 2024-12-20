namespace ECommerceApi.Models;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Brand { get; set; }
    public required string Category { get; set; }
    public decimal Price { get; set; }
    public required string Image { get; set; }
    public required string Description { get; set; }
}