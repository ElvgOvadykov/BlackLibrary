using System.Threading;
using System.Threading.Tasks;
using BlackLibraryWH40K.Helper.Exceptions;
using BlackLibraryWH40K.Store;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlackLibraryWH40K.Application.Commands.Worlds
{
    /// <summary>
    /// Обработчик команды обновления информации о мире
    /// </summary>
    public class UpdateWorldHandler : AsyncRequestHandler<UpdateWorld>
    {
        private readonly BlackLibraryContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public UpdateWorldHandler(BlackLibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Реализация команды
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task Handle(UpdateWorld request, CancellationToken cancellationToken)
        {
            _context.World.Update(request.World);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}