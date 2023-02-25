using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Tickets.Models
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.ToTable(nameof(Actor));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.FullName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Bio).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ProfilePicUrl).IsRequired();

        }
    }
}
