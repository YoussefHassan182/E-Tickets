using E_Tickets.Data.Base;
using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Data
{
    public class ActorServices : EntityBaseRepository<Actor>,IActorServices
    {
        public ActorServices(AppDbContext context) : base(context)
        {
        }
    }
}
