using E_Tickets.Data.Base;
using E_Tickets.Models;

namespace E_Tickets.Data.Services
{
    public class ProducerServices : EntityBaseRepository<Producer>, IProducerServices
    {
        public ProducerServices(AppDbContext context) : base(context)
        {
        }
    }
}
