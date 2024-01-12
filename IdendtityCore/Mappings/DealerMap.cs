using IdendtityCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdendtityCore.Mappings
{
    public class DealerMap : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasKey(r => r.DealerId);

            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.DealerName).HasName("DealerNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("Dealer");


            // Limit the size of columns to use efficient database types
            //builder.Property(u => u.DealerId).HasMaxLength(256);//guid
            builder.Property(u => u.DealerName).HasMaxLength(256);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

         
        }
    }
}
