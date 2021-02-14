using BlackLibraryWH40K.Store.Model;
using MediatR;

namespace BlackLibraryWH40K.Application.Commands.Worlds
{
    /// <summary>
    /// Команда создания мира
    /// </summary>
    public class CreateWorld : IRequest<int>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="world"></param>
        public CreateWorld(World world)
        {
            World = world;
        }

        /// <summary>
        /// Мир
        /// </summary>
        public World World { get; }

        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <param name="world">Мир</param>
        /// <returns></returns>
        public static CreateWorld Of(World world) => new CreateWorld(world);
    }
}