using E_Tickets.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Tickets.Models
{
    public class Producer:IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePicUrl { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Bio")]
        public string Bio { get; set; }
        //relation
        public virtual ICollection<Movie> Movies { get; set; }
    }
}

