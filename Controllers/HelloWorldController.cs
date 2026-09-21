using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace ASP260908.Controllers
{
    public class HelloWorldController : Controller
    {
        //GET: ~/HelloWorld
        public IActionResult Index()
        {
            return View();
        }


    }
}
