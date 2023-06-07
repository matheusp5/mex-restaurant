using MexRestaurant.API.Infrastructure;
using MexRestaurant.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MySQLContext>(opt =>
{
    opt.UseMySql("server=localhost;user=root;database=mex_restaurant;password=root;",new MySqlServerVersion(new Version(8, 0, 11)));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<MySQLContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();