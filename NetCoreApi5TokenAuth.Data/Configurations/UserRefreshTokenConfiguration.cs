using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreApi5TokenAuth.Core.Entities.Concrete;

namespace NetCoreApi5TokenAuth.Data.Configurations
{
    public class UserRefreshTokenConfiguration:IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(200);

        }
    }
}
