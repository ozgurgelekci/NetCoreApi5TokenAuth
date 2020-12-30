using System.Threading.Tasks;
using NetCoreApi5TokenAuth.Core.DTOs;
using SharedLibrary.DTOs;

namespace NetCoreApi5TokenAuth.Core.Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<ResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto);

        Task<ResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken);

        Task<ResponseDto<NoDataDto>> RevokeRefreshToken(string refreshToken);

        ResponseDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);
    }
}
