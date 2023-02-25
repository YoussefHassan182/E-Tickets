using E_Tickets.Data.Base;

namespace E_Tickets.Models
{
    public class ActorMovie
    {
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int ActorId { get; set; }
        public virtual Actor Actor { get; set;}
    }
}
