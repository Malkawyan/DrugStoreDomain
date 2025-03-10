using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    /// <summary>
    /// Конфигурация Country
    /// </summary>
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(nameof(Country));
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName(nameof(Country.Name));
        
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnName(nameof(Country.Code));

        builder.HasMany(x => x.Drugs)
            .WithOne(y => y.Country)
            .HasForeignKey(d => d.CountryCodeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
        
}