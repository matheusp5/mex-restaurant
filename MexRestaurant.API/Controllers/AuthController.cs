using System.Security.Claims;
using MexRestaurant.API.DTO;
using MexRestaurant.API.Helpers;
using MexRestaurant.API.Models;
using MexRestaurant.API.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MexRestaurant.API.Controllers;

[Route("api/auth")]
public class AuthController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    [HttpPost("register")]
    public async Task<RegisterResponse> Register([FromBody] RegisterDTO dto)
    {
        IdentityResult result = await this._userManager.CreateAsync(new()
        {
            Email = dto.Email,
            UserName = dto.Username
        }, dto.Password);

        if (result.Succeeded)
        {
            ApplicationUser user = await this._userManager.FindByEmailAsync(dto.Email);
            return new()
            {
                isSucceeded = true,
                token = JWTHelper.GenerateJwtToken(dto.Email, dto.Username, user.Id)
            };
        }

        return new()
        {
            isSucceeded = false,
            token = ""
        };
    }

    [HttpPost("login")]
    public async Task<LoginResponse> Login([FromBody] LoginDTO dto)
    {
        var user = await this._userManager.FindByEmailAsync(dto.Email);
        if (user != null)
        {
            var result = await this._signInManager.PasswordSignInAsync(user, dto.Password, false, false);

            if (result.Succeeded)
            {
                return new()
                {
                    isApproved = result.Succeeded,
                    token = JWTHelper.GenerateJwtToken(user.Email, user.UserName, user.Id)
                };
            }

        }

        return new()
        {
            isApproved = false,
            token = ""
        };
    }

    
}