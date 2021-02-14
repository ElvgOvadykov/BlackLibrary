using System.Threading.Tasks;
using BlackLibraryWH40K.Store.Model;

namespace BlackLibraryWH40K.Application.Queries.Worlds
{
    /// <summary>
    /// Запросы для работы с Мирами
    /// </summary>
    public interface IWorldsQueries
    {
        /// <summary>
        ///Возвращает список всех миров
        /// </summary>
        /// <returns></returns>
        Task<World[]> GetAll();

        /// <summary>
        /// Возвращает мир по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<World> GetById(int id);
    }
}