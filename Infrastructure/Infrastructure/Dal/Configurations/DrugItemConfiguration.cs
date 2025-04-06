using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class DrugItemConfiguration : IEntityTypeConfiguration<DrugItem>
{
    /// <summary>
    /// Конфигурация DrugItem
    /// </summary>
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        builder.ToTable(nameof(DrugItem));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DrugId)
            .IsRequired()
            .HasColumnName(nameof(DrugItem.DrugId));

        builder.Property(x => x.DrugStoreId)
            .IsRequired()
            .HasColumnName(nameof(DrugItem.DrugStoreId));
        
        builder.Property(x => x.Cost)
            .IsRequired()
            .HasColumnName(nameof(DrugItem.Cost));
        
        builder.Property(x => x.Count)
            .IsRequired()
            .HasColumnName(nameof(DrugItem.Count));

        builder.HasOne(x => x.Drug)
            .WithMany(y => y.DrugItems)
            .HasForeignKey(x => x.DrugId);

        builder.HasOne(x => x.DrugStore)
            .WithMany(y => y.DrugItems)
            .HasForeignKey(d => d.DrugStoreId);
    }
}