using E_Tickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Actor:IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "Profile Picture"), Required(ErrorMessage = "THe pic Is Required")]
        public string ProfilePicUrl { get; set; }
        [Display(Name = "Full Name"), Required(ErrorMessage = "The Full Name Is Required"), MaxLength(50), MinLength(4)]
        public string FullName { get; set; }
        [Display(Name = "Bio"), Required(ErrorMessage = "The Bio Is Required"), MaxLength(50), MinLength(4)]
        public string Bio { get; set; }
        //relation
        public virtual ICollection<ActorMovie> ActorsMovies { get; set; }
    }
}
