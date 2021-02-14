using System.Threading;
using System.Threading.Tasks;
using BlackLibraryWH40K.Helper.Exceptions;
using BlackLibraryWH40K.Store;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlackLibraryWH40K.Application.Commands.Chapters
{
    /// <summary>
    /// Обработчик команды обновления информации о ордене космодесанта
    /// </summary>
    public class UpdateChapterHandler : AsyncRequestHandler<UpdateChapter>
    {
        private readonly BlackLibraryContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public UpdateChapterHandler(BlackLibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Реализация команды
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task Handle(UpdateChapter request, CancellationToken cancellationToken)
        {
            if (!await _context.Person.AnyAsync(s => s.Id == request.Chapter.ChapterMaster.Id, cancellationToken))
                throw new NotFoundException("Не удалось обновить информацию о магистре ордена, так как данный персонаж не был найден!");

            if (!await _context.Legion.AnyAsync(s => s.Number == request.Chapter.Legion.Number, cancellationToken))
                throw new NotFoundException("Не удалось обновить информацию о легионе, так как данный легион не был найден!");

            if (!await _context.World.AnyAsync(s => s.Id == request.Chapter.HomeWorld.Id, cancellationToken))
                throw new NotFoundException("Не удалось обновить информацию о примархе, так как данный мир не был найден!");

            _context.Chapter.Update(request.Chapter);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}