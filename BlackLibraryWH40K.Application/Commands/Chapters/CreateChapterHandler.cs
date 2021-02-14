using System.Threading;
using System.Threading.Tasks;
using BlackLibraryWH40K.Store;
using MediatR;

namespace BlackLibraryWH40K.Application.Commands.Chapters
{
    /// <summary>
    /// Обработчик команды создания нового ордена
    /// </summary>
    public class CreateChapterHandler : IRequestHandler<CreateChapter, int>
    {
        private readonly BlackLibraryContext _context;

        public CreateChapterHandler(BlackLibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Реализация команды создания нового ордена
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateChapter request, CancellationToken cancellationToken)
        {
            var chapter = request.Chapter;
            await _context.Chapter.AddAsync(chapter, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return chapter.Id;
        }
    }
}