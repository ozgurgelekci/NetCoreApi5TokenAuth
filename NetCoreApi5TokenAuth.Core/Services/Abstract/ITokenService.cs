using NetCoreApi5TokenAuth.Core.Configuration;
using NetCoreApi5TokenAuth.Core.DTOs;
using NetCoreApi5TokenAuth.Core.Entities.Concrete;

namespace NetCoreApi5TokenAuth.Core.Services.Abstract
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);

        ClientTokenDto CreateClientToken(Client client);
    }
}
