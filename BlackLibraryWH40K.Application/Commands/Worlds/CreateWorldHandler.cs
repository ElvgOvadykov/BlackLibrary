using System.Threading;
using System.Threading.Tasks;
using BlackLibraryWH40K.Store;
using MediatR;

namespace BlackLibraryWH40K.Application.Commands.Worlds
{
    /// <summary>
    /// Обработчик команды создания мира
    /// </summary>
    public class CreateWorldHandler : IRequestHandler<CreateWorld, int>
    {
        private readonly BlackLibraryContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public CreateWorldHandler(BlackLibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Реализация команды
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateWorld request, CancellationToken cancellationToken)
        {
            var world = request.World;
            await _context.World.AddAsync(world, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return world.Id;
        }
    }
}