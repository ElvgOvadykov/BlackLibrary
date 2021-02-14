using System.Threading.Tasks;
using BlackLibraryWH40K.Store.Model;

namespace BlackLibraryWH40K.Application.Queries.Primarch
{
    /// <summary>
    /// Запросы для работы с примархами
    /// </summary>
    public interface IPrimarchQueries
    {
        /// <summary>
        ///Возвращает список всех примархов
        /// </summary>
        /// <returns></returns>
        Task<Store.Model.Primarch[]> GetAllAsync();

        /// <summary>
        /// Возвращает примарха по номеру
        /// </summary>
        /// <param name="number">Номер примарха</param>
        /// <returns></returns>
        Task<Store.Model.Primarch> GetByNumberAsync(int number);
    }
}