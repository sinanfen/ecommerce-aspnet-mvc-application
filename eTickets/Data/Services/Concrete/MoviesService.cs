using eTickets.Data.Base;
using eTickets.Data.Services.Abstract;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services.Concrete
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context) { }
    }
}
