using System;
using NetCoreApi5TokenAuth.Core.Entities.Abstract;

namespace NetCoreApi5TokenAuth.Core.Entities.Concrete
{
    public class UserRefreshToken : IEntity
    {
        public string UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
