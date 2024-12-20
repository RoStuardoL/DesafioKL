using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ECommerceApi.Data;
using ECommerceApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ECommerceDb"));

builder.Services.AddScoped<IAuthService, AuthService>();

// Configure JWT authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Remove HTTPS redirection in development
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData(context);
}

app.Run();

void SeedData(AppDbContext context)
{
    if (!context.Users.Any())
    {
        context.Users.Add(new ECommerceApi.Models.User
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123")
        });
    }

    if (!context.Products.Any())
    {
        var products = new[]
        {
            new ECommerceApi.Models.Product
            {
                Id = Guid.NewGuid(),
                Name = "Premium Coffee Maker",
                Brand = "BrewMaster",
                Category = "Kitchen Appliances",
                Price = 199.99M,
                Image = "https://images.unsplash.com/photo-1495474472287-4d71bcdd2085",
                Description = "Professional-grade coffee maker with temperature control."
            },
            new ECommerceApi.Models.Product
            {
                Id = Guid.NewGuid(),
                Name = "Wireless Headphones",
                Brand = "AudioPro",
                Category = "Electronics",
                Price = 149.99M,
                Image = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e",
                Description = "High-quality wireless headphones with noise cancellation."
            }
        };

        context.Products.AddRange(products);
    }

    context.SaveChanges();
}