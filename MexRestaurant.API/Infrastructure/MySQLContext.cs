using MexRestaurant.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MexRestaurant.API.Infrastructure;

public class MySQLContext : IdentityDbContext<ApplicationUser>
{
    public MySQLContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<CartProduct> CartProducts { get; set; }
}