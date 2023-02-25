using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Tickets.Models
{
    public class ProducerConfig : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.ToTable(nameof(Producer));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Bio).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ProfilePicUrl).IsRequired().HasMaxLength(100);

        }
    }
}
