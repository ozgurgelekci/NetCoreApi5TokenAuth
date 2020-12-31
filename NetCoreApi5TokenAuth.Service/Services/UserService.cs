using Microsoft.AspNetCore.Identity;
using NetCoreApi5TokenAuth.Core.DTOs;
using NetCoreApi5TokenAuth.Core.Entities.Concrete;
using NetCoreApi5TokenAuth.Core.Services.Abstract;
using NetCoreApi5TokenAuth.Service.Mappings;
using SharedLibrary.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi5TokenAuth.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;

        public UserService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto userAppDto)
        {
            var user = new UserApp
            {
                Email = userAppDto.Email,
                UserName = userAppDto.UserName
            };

            var result = await _userManager.CreateAsync(user, userAppDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return ResponseDto<UserAppDto>.Fail(new ErrorDto(errors, true), 400);
            }

            return ResponseDto<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }

        public async Task<ResponseDto<UserAppDto>> GetByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return ResponseDto<UserAppDto>.Fail("UserName not found", 404, true);
            }

            return ResponseDto<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }
    }
}
