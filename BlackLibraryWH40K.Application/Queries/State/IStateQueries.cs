using System.Threading.Tasks;
using BlackLibraryWH40K.Store.Model;

namespace BlackLibraryWH40K.Application.Queries.State
{
    /// <summary>
    /// Запросы для работы со сторонами
    /// </summary>
    public interface IStateQueries
    {
        /// <summary>
        ///Возвращает список всех сторон
        /// </summary>
        /// <returns></returns>
        Task<Store.Model.State[]> GetAll();

        /// <summary>
        /// Возвращает мир по сторон
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Store.Model.State> GetById(int id);
    }
}