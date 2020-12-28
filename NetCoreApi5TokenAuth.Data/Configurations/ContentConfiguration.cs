using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreApi5TokenAuth.Core.Entities.Concrete;

namespace NetCoreApi5TokenAuth.Data.Configurations
{
    public class ContentConfiguration:IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
