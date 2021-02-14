using MediatR;

namespace BlackLibraryWH40K.Application.Commands.Worlds
{
    /// <summary>
    /// Команда обновления информации о мире
    /// </summary>
    public class UpdateWorld : IRequest
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="world"></param>
        public UpdateWorld(Store.Model.World world)
        {
            World = world;
        }

        /// <summary>
        /// Мир
        /// </summary>
        public Store.Model.World World { get; set; }

        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <param name="world">мир</param>
        /// <returns></returns>
        public static UpdateWorld Of(Store.Model.World world) => new UpdateWorld(world);
    }
}