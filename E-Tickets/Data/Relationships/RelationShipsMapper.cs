using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Data
{
    public static class RelationShipsMapper
    {
        public static void MapRElationships(this ModelBuilder builder)
        {
            //many to many relationship between Actor and Movie
            builder.Entity<ActorMovie>()
                .HasOne(m => m.Movie).WithMany(am => am.ActorsMovies)
                .HasForeignKey(f => f.MovieId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<ActorMovie>()
                .HasOne(a => a.Actor).WithMany(am => am.ActorsMovies)
                .HasForeignKey(f => f.ActorId).OnDelete(DeleteBehavior.ClientSetNull);

            //one to many relationship between Cinema and Movie
            builder.Entity<Movie>()
                .HasOne(c => c.Cinema).WithMany(m => m.Movies)
                .HasForeignKey(f => f.CinemaId).OnDelete(DeleteBehavior.ClientSetNull);

            //one to many relationship between Producer and Movie
            builder.Entity<Movie>()
                .HasOne(p => p.Producer).WithMany(m => m.Movies)
                .HasForeignKey(f => f.ProducerId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
