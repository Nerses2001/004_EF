using _004_EF.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace _004_EF.Configuration
{
    internal class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("Mobiles").HasKey(p => p.Ident);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

        }
    }
}
