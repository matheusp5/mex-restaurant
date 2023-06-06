using MexRestaurant.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MexRestaurant.API.Infrastructure;

public class SQLServerContext : IdentityDbContext<ApplicationUser>
{
    public SQLServerContext(DbContextOptions options) : base(options)
    {
    }
}