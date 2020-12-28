using NetCoreApi5TokenAuth.Core.Entities.Abstract;

namespace NetCoreApi5TokenAuth.Core.Entities.Concrete
{
    public class Content : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
