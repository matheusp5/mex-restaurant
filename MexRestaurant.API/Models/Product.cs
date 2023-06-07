namespace MexRestaurant.API.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public string ImageUrl { get; set; }
}