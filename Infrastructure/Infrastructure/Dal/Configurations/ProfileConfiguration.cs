using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    /// <summary>
    /// Конфигурация Profile
    /// </summary>
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable(nameof(Profile));
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.ExternalId)
            .IsRequired()
            .HasColumnName(nameof(Profile.ExternalId))
            .HasMaxLength(256);
        
        builder.HasMany(x => x.FavoriteDrugs)
            .WithOne(x => x.Profile)
            .HasForeignKey(x => x.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}