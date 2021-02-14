using MediatR;

namespace BlackLibraryWH40K.Application.Commands.Primarch
{
    /// <summary>
    /// Команда для добавления примарха
    /// </summary>
    public class CreatePrimarch : IRequest<int>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="primarch"></param>
        public CreatePrimarch(Store.Model.Primarch primarch)
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
        public static CreatePrimarch Of(Store.Model.Primarch primarch) => new CreatePrimarch(primarch);
    }
}