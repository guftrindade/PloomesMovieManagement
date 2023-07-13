using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Management.Infra.Models;

namespace Movie.Management.Infra.Mappings
{
    public class MoviesMap : IEntityTypeConfiguration<Movies>
    {
        public void Configure(EntityTypeBuilder<Movies> builder)
        {
            builder.ToTable("Movies");

            builder.HasKey(x => x.Id);

            builder.Property(m => m.Id)
                .HasColumnName("Id")
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(x => x.Title)
                .HasColumnName("Title")
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(x => x.DirectedBy)
                .HasColumnName("DirectedBy")
                .HasColumnType("VARCHAR(255)");

            builder.Property(x => x.Year)
                .HasColumnName("Year")
                .HasColumnType("SMALLINT")
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasColumnType("SMALLDATETIME")
                .IsRequired();
        }
    }
}
