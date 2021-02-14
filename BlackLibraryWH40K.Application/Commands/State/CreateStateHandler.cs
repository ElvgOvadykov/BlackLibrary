using System.Threading;
using System.Threading.Tasks;
using BlackLibraryWH40K.Application.Commands.State;
using BlackLibraryWH40K.Store;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlackLibraryWH40K.Application.Commands.State
{
    /// <summary>
    /// Обработчик команды добавления стороны
    /// </summary>
    public class CreateStateHandler : IRequestHandler<CreateState, int>
    {
        private readonly BlackLibraryContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public CreateStateHandler(BlackLibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Реализация команды
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateState request, CancellationToken cancellationToken)
        {
            var state = request.State;
            await _context.State.AddAsync(state, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return state.Id;
        }
    }
}