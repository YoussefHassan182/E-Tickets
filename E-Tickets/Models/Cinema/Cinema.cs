using E_Tickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Cinema:IEntityBase
        
    {
        public int Id { get; set; }
        [Display(Name = "Logo Picture")]
        public string LogoUrl { get; set; }
        [Display(Name = "Cinema Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        //relation
        public virtual ICollection<Movie> Movies { get; set; }
    }
}

