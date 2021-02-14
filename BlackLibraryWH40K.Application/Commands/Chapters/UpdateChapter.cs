using MediatR;

namespace BlackLibraryWH40K.Application.Commands.Chapters
{
    /// <summary>
    /// Команда обновления информации о ордене космодесанта
    /// </summary>
    public class UpdateChapter : IRequest
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="сhapter"></param>
        public UpdateChapter(Store.Model.Chapter сhapter)
        {
            Chapter = сhapter;
        }

        /// <summary>
        /// Орден
        /// </summary>
        public Store.Model.Chapter Chapter { get; set; }

        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <param name="сhapter"></param>
        /// <returns></returns>
        public static UpdateChapter Of(Store.Model.Chapter сhapter) => new UpdateChapter(сhapter);
    }
}