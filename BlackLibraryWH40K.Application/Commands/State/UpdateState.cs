using MediatR;

namespace BlackLibraryWH40K.Application.Commands.State
{
    /// <summary>
    /// Команда обновления информации о стороне
    /// </summary>
    public class UpdateState : IRequest
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="state"></param>
        public UpdateState(Store.Model.State state)
        {
            State = state;
        }

        /// <summary>
        /// Сторона
        /// </summary>
        public Store.Model.State State { get; set; }

        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static UpdateState Of(Store.Model.State state) => new UpdateState(state);
    }
}