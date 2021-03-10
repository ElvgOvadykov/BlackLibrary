using System.Linq;
using System.Threading.Tasks;
using BlackLibraryWH40K.Store;
using Microsoft.EntityFrameworkCore;

namespace BlackLibraryWH40K.Application.Queries.Primarch
{
    /// <summary>
    /// Реализация запросов для работы с примархами
    /// </summary>
    public class PrimarchQueries : IPrimarchQueries
    {
        private readonly ReadOnlyBlackLibraryContext _context;

        public PrimarchQueries(ReadOnlyBlackLibraryContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Store.Model.Primarch[]> GetAllAsync()
        {
            return await _context.Primarch
                .Include(x => x.State)
                .Include(x => x.HomeWorld)
                .ToArrayAsync(); ;
        }

        /// <inheritdoc />
        public async Task<Store.Model.Primarch> GetByNumberAsync(int number)
        {
            return await _context.Primarch
                .Include(x => x.State)
                .Include(x => x.HomeWorld)
                .FirstOrDefaultAsync(p => p.Number == number);
        }
    }
}