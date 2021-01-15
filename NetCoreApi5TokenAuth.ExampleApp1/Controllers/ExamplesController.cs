using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace NetCoreApi5TokenAuth.ExampleApp1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamplesController : ControllerBase
    {
        public IActionResult GetExample()
        {
            var userName = HttpContext.User.Identity.Name;
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            return Ok($"UserName: {userName} - UserId: {userIdClaim.Value}");
        }
    }
}
