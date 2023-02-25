using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Tickets.Models
{
    public class ActorMovieConfig : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> builder)
        {
            builder.ToTable(nameof(ActorMovie));
            builder.HasKey(am => new
            {
                am.MovieId,
                am.ActorId
            });
            builder.Property(x => x.MovieId).ValueGeneratedOnAdd();
            builder.Property(x => x.ActorId).ValueGeneratedOnAdd();
            
        }
    }
}
