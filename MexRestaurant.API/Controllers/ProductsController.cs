using MexRestaurant.API.Infrastructure;
using MexRestaurant.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MexRestaurant.API.Controllers;

[Route("api/products")]
public class ProductsController : Controller
{
    private readonly MySQLContext _mySqlContext;

    public ProductsController(MySQLContext mySqlContext)
    {
        _mySqlContext = mySqlContext;
    }

    [HttpGet("all")]
    public async Task<List<Product>> AllProducts()
    {
        return await this._mySqlContext.Products.ToListAsync();
    }

    [HttpGet("id/{id:int}")]
    public async Task<Product?> Product([FromRoute] int id)
    {
        return await this._mySqlContext.Products.FirstOrDefaultAsync(prd => prd.ProductId == id);
    }
}