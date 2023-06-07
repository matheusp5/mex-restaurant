namespace MexRestaurant.API.Models;

public class CartProduct
{
    public int CartProductId { get; set; }
    public ApplicationUser User { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public float Total { get; set; }
}