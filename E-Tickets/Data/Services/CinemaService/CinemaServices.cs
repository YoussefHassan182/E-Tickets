using E_Tickets.Data.Base;
using E_Tickets.Models;

namespace E_Tickets.Data.Services
{
    public class CinemaServices : EntityBaseRepository<Cinema>, ICinemaServices
    {
        public CinemaServices(AppDbContext context) : base(context)
        {
        }
    }
}
