using MediatR;

namespace BlackLibraryWH40K.Application.Commands.Primarch
{
    /// <summary>
    /// Команда обновления информации о примархе
    /// </summary>
    public class UpdatePrimarch : IRequest
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="primarch"></param>
        public UpdatePrimarch(Store.Model.Primarch primarch)
        {
            Primarch = primarch;
        }

        /// <summary>
        /// Примарх
        /// </summary>
        public Store.Model.Primarch Primarch { get; set; }

        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <param name="primarch"></param>
        /// <returns></returns>
        public static UpdatePrimarch Of(Store.Model.Primarch primarch) => new UpdatePrimarch(primarch);
    }
}