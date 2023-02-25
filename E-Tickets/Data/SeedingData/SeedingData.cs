using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Data
{
    public static class SeedingData
    {
        public static void Seed(this ModelBuilder builder)
        {

            builder.Entity<Actor>().HasData(

                        new Actor()
                        {
                            Id = 1,
                            FullName = "Leonardo Decaprio",
                            Bio = "This is A Bio for lio",
                            ProfilePicUrl = "https://www.themoviedb.org/t/p/w500/wo2hJpn04vbtmh0B9utCFdsQhxM.jpg",

                        }
                        );
            

            builder.Entity<Cinema>().HasData(

                    new Cinema()
                    {
                        Id = 1,
                        Name = "Prince Charles Cinema",
                        LogoUrl = "https://i1.sndcdn.com/avatars-000006124431-8cxru4-t500x500.jpg",
                        Description = "This is a description",

                    }
                    );


            builder.Entity<Movie>().HasData(

                    new Movie()
                    {
                        Id = 1,
                        CinemaId = 1,
                        Description = "This is a description",
                        Name = "Inception",
                        ImageUrl = "https://flxt.tmsimg.com/assets/p7825626_p_v8_af.jpg",
                        MovieCategory = MovieCategory.Fiction,
                        Price = 200,
                        ProducerId = 1,
                        StartDate = DateTime.Now.AddDays(-5),
                        EndDate = DateTime.Now.AddDays(2),


                    }
                );

            builder.Entity<Producer>().HasData(

                    new Producer()
                    {
                        Id = 1,
                        FullName = "Christopher Nolan",
                        Bio = "THis is a bio",
                        ProfilePicUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSL7HtY5CubP3o0orL-3WmKeS1geED7RUTciHKN2UY&s",

                    }
                );

            builder.Entity<ActorMovie>().HasData(

                    new ActorMovie()
                    {
                        ActorId = 1,
                        MovieId = 1
                    }
                );
  
                }
        
            }
    
        }
    

