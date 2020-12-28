using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreApi5TokenAuth.Core.Entities.Concrete;

namespace NetCoreApi5TokenAuth.Data.Configurations
{
    public class UserAppConfiguration : IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
            builder.Property(x => x.City).HasMaxLength(50);
        }
    }
}
