using System.Linq;
using System.Threading.Tasks;
using BlackLibraryWH40K.Store;
using BlackLibraryWH40K.Store.Model;
using Microsoft.EntityFrameworkCore;

namespace BlackLibraryWH40K.Application.Queries.Chapters
{
    public class ChaptersQueries : IChaptersQueries
    {
        private readonly BlackLibraryContext _context;

        public ChaptersQueries(BlackLibraryContext context)
        {
            _context = context;
        }

        public async Task<Chapter[]> GetAll()
        {
            return await _context.Chapter.ToArrayAsync();
        }

        public async Task<Chapter> GetById(int id)
        {
            return await _context.Chapter.Where(c=>c.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}