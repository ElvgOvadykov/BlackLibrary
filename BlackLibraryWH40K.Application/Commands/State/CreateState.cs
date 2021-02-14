using MediatR;

namespace BlackLibraryWH40K.Application.Commands.State
{
    /// <summary>
    /// Команда для добавления стороны
    /// </summary>
    public class CreateState : IRequest<int>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="state"></param>
        public CreateState(Store.Model.State state)
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
        /// <param name="State"></param>
        /// <returns></returns>
        public static CreateState Of(Store.Model.State State) => new CreateState(State);
    }
}