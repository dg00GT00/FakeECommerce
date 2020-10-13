using eCommerce.Errors;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)] // Swagger ignore api configuration
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}