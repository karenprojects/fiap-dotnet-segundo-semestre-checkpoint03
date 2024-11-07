using CP3.Data.AppData;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;

namespace CP3.Data.Repositories
{
    public class BarcoRepository : IBarcoRepository
    {
        private readonly ApplicationContext _context;

        public BarcoRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}
