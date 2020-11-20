using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class FallbackController : Controller
    {
        // GET for serving the client built client application
        public IActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/HTML");
        }
    }
}