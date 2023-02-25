using E_Tickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace E_Tickets.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }

        //Order and cart 
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            new ActorConfig().Configure(builder.Entity<Actor>());
            new ActorMovieConfig().Configure(builder.Entity<ActorMovie>());
            new CinemaConfig().Configure(builder.Entity<Cinema>());
            new MovieConfig().Configure(builder.Entity<Movie>());
            new ProducerConfig().Configure(builder.Entity<Producer>());

            new OrderConfig().Configure(builder.Entity<Order>());
            new OrderItemConfig().Configure(builder.Entity<OrderItem>());
            new ShoppingCartItemConfig().Configure(builder.Entity<ShoppingCartItem>());

            builder.MapRElationships();
            builder.Seed();
            base.OnModelCreating(builder);

        }
    }
}
