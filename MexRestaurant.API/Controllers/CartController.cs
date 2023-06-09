using MexRestaurant.API.DTO;
using MexRestaurant.API.Infrastructure;
using MexRestaurant.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MexRestaurant.API.Controllers;

[Route("api/cart")]
public class CartController : Controller
{
    private readonly MySQLContext _mySqlContext;

    public CartController(MySQLContext mySqlContext)
    {
        _mySqlContext = mySqlContext;
    }

    [HttpPost("all")]
    public async Task<List<CartProduct>> GetAllProductsCart([FromBody] GetAllProductsDTO dto)
    {
        return await this._mySqlContext.CartProducts.Include(x => x.Product).ToListAsync();
    }

    [HttpPost("add")]
    public async Task<bool> AddProductToCart([FromBody] AddProductToCart dto, [FromServices] UserManager<ApplicationUser> _userManager)
    {
        var alreadyInCart = await this._mySqlContext.CartProducts.FirstOrDefaultAsync(x =>
            x.Product.ProductId == dto.ProductId && x.User.Id == dto.UserId);
        if (alreadyInCart == null)
        {
            var product = await this._mySqlContext.Products.FirstOrDefaultAsync(x => x.ProductId == dto.ProductId);
            var user = await _userManager.FindByIdAsync(dto.UserId);
            await this._mySqlContext.CartProducts.AddAsync(new() { Quantity = 1, Product = product, User = user, Total = product.Price});
            await this._mySqlContext.SaveChangesAsync();
        }
        else
        {
            
        }

        return true;
    }
    
    [HttpPost("remove")]
    public async Task<bool> RemoveProductToCart([FromBody] AddProductToCart dto, [FromServices] UserManager<ApplicationUser> _userManager)
    {
        var alreadyInCart = await this._mySqlContext.CartProducts.FirstOrDefaultAsync(x =>
            x.Product.ProductId == dto.ProductId && x.User.Id == dto.UserId);
        if (alreadyInCart != null)
        {
            var product = await this._mySqlContext.Products.FirstOrDefaultAsync(x => x.ProductId == dto.ProductId);
            var user = await _userManager.FindByIdAsync(dto.UserId);
            var cartItem = await this._mySqlContext.CartProducts.FirstOrDefaultAsync(x =>
                x.User.Id == user.Id && x.Product.ProductId == product.ProductId);
            this._mySqlContext.CartProducts.Remove(cartItem);
            await this._mySqlContext.SaveChangesAsync();
        }
        else
        {
            
        }

        return true;
    }
}