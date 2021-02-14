using System.Threading.Tasks;
using BlackLibraryWH40K.Store.Model;

namespace BlackLibraryWH40K.Application.Queries.Chapters
{
    /// <summary>
    /// Интерфейс запросов орденов 
    /// </summary>
    public interface IChaptersQueries
    {
        /// <summary>
        /// Возвращает список всех орденов
        /// </summary>
        /// <returns></returns>
        Task<Chapter[]> GetAll();

        /// <summary>
        /// Возвращает орден по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Chapter> GetById(int id);
    }
}