using Microsoft.AspNetCore.Mvc;
using NetCoreApi5TokenAuth.Core.DTOs;
using NetCoreApi5TokenAuth.Core.Services.Abstract;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace NetCoreApi5TokenAuth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var createdUser = await _userService.CreateUserAsync(createUserDto);

            return ActionResultInstance(createdUser);
        }

        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            var getUser = await _userService.GetByUserNameAsync(HttpContext.User.Identity.Name);

            return ActionResultInstance(getUser);
        }
    }
}
