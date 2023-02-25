using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Tickets.Data.ViewModels
{
    public class LoginViewModel
    {

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
