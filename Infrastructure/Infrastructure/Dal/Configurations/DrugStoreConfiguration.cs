using Domain.Entities;
using Domain.Value_Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    /// <summary>
    /// Конфигурация DrugStore
    /// </summary>
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        builder.ToTable(nameof(DrugStore));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DrugNetwork)
            .IsRequired()
            .HasColumnName(nameof(DrugStore.DrugNetwork))
            .HasMaxLength(100);

        builder.Property(x => x.Number)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName(nameof(DrugStore.Number));

        builder.OwnsOne(x => x.Address, addressbuilder =>
        {
            addressbuilder.Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName(nameof(Address.Street));
            
            addressbuilder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName(nameof(Address.City));
            
            addressbuilder.Property(x => x.House)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName(nameof(Address.House));
            
            addressbuilder.Property(x => x.PostalCode)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName(nameof(Address.PostalCode));
            
            addressbuilder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName(nameof(Address.Country));
        });
        
        builder.HasMany(x => x.DrugItems)
            .WithOne(y => y.DrugStore)
            .HasForeignKey(d => d.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}