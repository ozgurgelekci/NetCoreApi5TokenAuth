using Microsoft.AspNetCore.Identity;

namespace NetCoreApi5TokenAuth.Core.Entities.Concrete
{
    public class UserApp : IdentityUser
    {
        public string City { get; set; }
    }
}
