using eCommerce.Errors;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    /// <summary>
    /// Non-production controller.
    /// Only for testing error message formats
    /// </summary>
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