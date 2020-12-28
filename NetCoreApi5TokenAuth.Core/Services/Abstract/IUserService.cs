using System.Threading.Tasks;
using NetCoreApi5TokenAuth.Core.DTOs;
using SharedLibrary.DTOs;

namespace NetCoreApi5TokenAuth.Core.Services.Abstract
{
    public interface IUserService
    {
        Task<ResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto userAppDto);

        Task<ResponseDto<UserAppDto>> GetByUserNameAsync(string userName);
    }
}
