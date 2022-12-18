using eTickets.Data.Base;
using eTickets.Data.Services.Abstract;
using eTickets.Models;

namespace eTickets.Data.Services.Concrete
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext context) : base(context) { }
    }
}
