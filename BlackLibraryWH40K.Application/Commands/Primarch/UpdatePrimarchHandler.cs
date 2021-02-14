using System.Threading;
using System.Threading.Tasks;
using BlackLibraryWH40K.Helper.Exceptions;
using BlackLibraryWH40K.Store;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlackLibraryWH40K.Application.Commands.Primarch
{
    /// <summary>
    /// Обработчик команды обновления информации о примархе
    /// </summary>
    public class UpdatePrimarchHandler : AsyncRequestHandler<UpdatePrimarch>
    {
        private readonly BlackLibraryContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public UpdatePrimarchHandler(BlackLibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Реализация команды
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task Handle(UpdatePrimarch request, CancellationToken cancellationToken)
        {
            if(!await _context.State.AnyAsync(s=>s.Id == request.Primarch.State.Id, cancellationToken))
                throw new NotFoundException("Не удалось обновить информацию о примархе, так как данная сторона не была найдена!");

            if (!await _context.World.AnyAsync(s => s.Id == request.Primarch.HomeWorld.Id, cancellationToken))
                throw new NotFoundException("Не удалось обновить информацию о примархе, так как данный мир не был найден!");

            _context.Primarch.Update(request.Primarch);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}