using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Tickets.Models
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable(nameof(Movie));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(150);
            builder.Property(x=>x.StartDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(x=>x.EndDate).IsRequired().HasDefaultValue(DateTime.UtcNow.AddDays(5));
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x=>x.MovieCategory).IsRequired();

        }
    }
}
