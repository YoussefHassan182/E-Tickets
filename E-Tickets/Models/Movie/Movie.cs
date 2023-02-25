using E_Tickets.Data;
using E_Tickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Movie:IEntityBase
    {
        public int Id { get; set; }
        [Display(Name= "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Category")]
        public MovieCategory MovieCategory { get; set; }
        //relation
        public virtual ICollection<ActorMovie> ActorsMovies { get;}
        //foreign key
        public int CinemaId { get; set; }
        public virtual Cinema Cinema{ get;}
        //foreign key
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }

    }
}

