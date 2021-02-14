using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace BlackLibraryWH40K.Store.Model
{
    /// <summary>
    /// Легион космодесанта
    /// </summary>
    public class Legion
    {
        /// <summary>
        /// Номер
        /// </summary>
        [Key]
        public int Number { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Примарх
        /// </summary>
        public Primarch Primarch { get; set; }

        /// <summary>
        /// Магистр ордена
        /// </summary>
        public Person ChapterMaster { get; set; }

        /// <summary>
        /// Родной мир
        /// </summary>
        public World HomeWorld { get; set; }
    }
}