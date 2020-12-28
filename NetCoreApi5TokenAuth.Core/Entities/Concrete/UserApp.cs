using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NetCoreApi5TokenAuth.Core.Entities.Abstract;

namespace NetCoreApi5TokenAuth.Core.Entities.Concrete
{
    public class UserApp : IdentityUser, IEntity
    {
        public string City { get; set; }
    }
}
