using Domain.Entities;
using Domain.Value_Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class FavoriteDrugConfiguration : IEntityTypeConfiguration<FavoriteDrug>
{
    /// <summary>
    /// Конфигурация FavoriteDrug
    /// </summary>
    public void Configure(EntityTypeBuilder<FavoriteDrug> builder)
    {
        builder.ToTable(nameof(FavoriteDrug));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProfileId)
            .IsRequired()
            .HasColumnName(nameof(FavoriteDrug.ProfileId));

        builder.Property(x => x.DrugId)
            .IsRequired()
            .HasColumnName(nameof(FavoriteDrug.DrugId));
        
        builder.Property(x => x.DrugStoreId)
            .IsRequired()
            .HasColumnName(nameof(FavoriteDrug.DrugStoreId));

        builder.HasOne(x => x.Profile)
            .WithMany(x => x.FavoriteDrugs)
            .HasForeignKey(x => x.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        /*builder.HasOne(x => x.DrugStore)
            .WithMany(y => y.FavoriteDrug)
            .HasForeignKey(d => d.DrugStoreId);*/

    }
}