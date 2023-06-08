namespace MexRestaurant.API.Responses;

public class LoginResponse
{
    public bool isApproved { get; set; }
    public string token { get; set; }
}