using Microsoft.AspNetCore.Mvc;

namespace MexRestaurant.API.Controllers;

[Route("api")]
public class HomeController : Controller
{
    [HttpGet("hello")]
    public string Index()
    {
        return "Hello, World!";
    }
}