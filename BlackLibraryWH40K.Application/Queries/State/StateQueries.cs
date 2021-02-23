using System.Linq;
using System.Threading.Tasks;
using BlackLibraryWH40K.Store;
using Microsoft.EntityFrameworkCore;

namespace BlackLibraryWH40K.Application.Queries.State
{
    /// <summary>
    /// Реализация запросов для работы со сторонами
    /// </summary>
    public class StateQueries : IStateQueries
    {
        private readonly BlackLibraryContext _context;

        public StateQueries(BlackLibraryContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Store.Model.State[]> GetAllAsync()
        {
            return await _context.State.ToArrayAsync();
        }

        /// <inheritdoc />
        public async Task<Store.Model.State> GetByIdAsync(int id)
        {
            return await _context.State.Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}