using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DTOs;

namespace NetCoreApi5TokenAuth.API.Controllers
{

    public class BaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(ResponseDto<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
