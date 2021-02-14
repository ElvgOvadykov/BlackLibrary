using System.Threading;
using System.Threading.Tasks;
using BlackLibraryWH40K.Store;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlackLibraryWH40K.Application.Commands.Primarch
{
    /// <summary>
    /// Обработчик команды добавления примарха
    /// </summary>
    public class CreatePrimarchHandler : IRequestHandler<CreatePrimarch, int>
    {
        private readonly BlackLibraryContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public CreatePrimarchHandler(BlackLibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Реализация команды
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreatePrimarch request, CancellationToken cancellationToken)
        {
            var primarch = request.Primarch;
            var state = await _context.State
                .FirstOrDefaultAsync(s => s.Id == request.Primarch.State.Id, cancellationToken);
            var world = await _context.World
                .FirstOrDefaultAsync(w => w.Id == request.Primarch.HomeWorld.Id, cancellationToken);
            primarch.State = state;
            primarch.HomeWorld = world;
            await _context.Primarch.AddAsync(primarch, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return primarch.Number;
        }
    }
}