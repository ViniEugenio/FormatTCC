using FormatTCC.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormatTCC.Infrastructure.Mappings
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .Property(user => user.RegisterDate)
                .IsRequired()
                .HasColumnType("SMALLDATETIME");

            builder
                .Property(user => user.Active)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnType("BIT");

        }
    }
}
