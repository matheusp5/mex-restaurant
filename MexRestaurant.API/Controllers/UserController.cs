using System.Runtime.Serialization.Formatters;
using System.Security.Claims;
using MexRestaurant.API.DTO;
using MexRestaurant.API.Helpers;
using MexRestaurant.API.Models;
using MexRestaurant.API.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MexRestaurant.API.Controllers;

[Route("api/user")]
public class UserController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserController(UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    [HttpPost("token")]
    public TokenDecodedResponse Token([FromBody] TokenDTO dto)
    {
        try
        {
            List<Claim> claims = JWTHelper.ValidateJwtToken(dto.Token);
            string email = claims.FirstOrDefault(c => c.Type == "UserEmail").Value;
            string username = claims.FirstOrDefault(c => c.Type == "UserName").Value;
            string id = claims.FirstOrDefault(c => c.Type == "UserId").Value;

            return new()
            {
                isSucceeded = true,
                Email = email,
                Username = username,
                Id = id
            };
        }
        catch (Exception e)
        {
            return new()
            {
                isSucceeded = false,
                Email = "",
                Username = ""
            };
        }
    }

    [HttpPost("role")]
    public async Task<string> IsInRole([FromBody] IsInRoleDTO dto)
    {
        var user = await this._userManager.FindByIdAsync(dto.UserId);
        if (user != null)
        {
            if (await this._userManager.IsInRoleAsync(user, dto.Role))
            {
                return "true";
            }
        }

        return "false";
    }

}