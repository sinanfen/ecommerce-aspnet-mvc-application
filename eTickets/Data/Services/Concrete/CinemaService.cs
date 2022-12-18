using eTickets.Data.Base;
using eTickets.Data.Services.Abstract;
using eTickets.Models;

namespace eTickets.Data.Services.Concrete
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        public CinemaService(AppDbContext context) : base(context) { }
    }
}
