using MediatR;

namespace BlackLibraryWH40K.Application.Commands.Chapters
{
    /// <summary>
    /// Команда создания ордена
    /// </summary>
    public class CreateChapter : IRequest<int>
    {
        public CreateChapter(Store.Model.Chapter chapter)
        {
            Chapter = chapter;
        }

        /// <summary>
        /// Орден
        /// </summary>
        public Store.Model.Chapter Chapter { get; }

        public static CreateChapter Of(Store.Model.Chapter chapter) => new CreateChapter(chapter);
    }
}