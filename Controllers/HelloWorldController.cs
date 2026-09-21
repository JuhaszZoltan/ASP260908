using Microsoft.AspNetCore.Mvc;

namespace ASP260908.Controllers;

public class HelloWorldController : Controller
{
    //GET: ~/HelloWorld
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Welcome(string name, int number = 1)
    {
        ViewData["Message"] = $"Hello, {name}!";
        ViewData["Number"] = number;
        return View();
    }


}
