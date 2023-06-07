using Microsoft.AspNetCore.Identity;

namespace MexRestaurant.API.Models;

public class ApplicationUser : IdentityUser { public List<CartProduct> CartProducts { get; set; } }