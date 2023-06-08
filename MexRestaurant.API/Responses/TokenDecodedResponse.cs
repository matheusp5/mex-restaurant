namespace MexRestaurant.API.Responses;

public class TokenDecodedResponse
{
    public bool isSucceeded { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
}