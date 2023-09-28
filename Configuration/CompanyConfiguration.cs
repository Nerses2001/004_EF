

using _004_EF.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _004_EF.Configuration
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Manufacturies")
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(70);
        }
    }
}