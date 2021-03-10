using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BlackLibraryWH40K.Store;
using BlackLibraryWH40K.Store.Model;
using Microsoft.EntityFrameworkCore;

namespace BlackLibraryWH40K.Application.Queries.Worlds
{
    /// <summary>
    /// Реализация запросов для работы с мирами
    /// </summary>
    public class WorldsQueries : IWorldsQueries
    {
        private readonly ReadOnlyBlackLibraryContext _context;

        public WorldsQueries(ReadOnlyBlackLibraryContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<World[]> GetAll()
        {
            return await _context.World.ToArrayAsync();
        }

        /// <inheritdoc />
        public async Task<World> GetById(int id)
        {
            return await _context.World.Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}