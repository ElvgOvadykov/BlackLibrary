using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace BlackLibraryWH40K.Store.Model
{
    /// <summary>
    /// Примарх
    /// </summary>
    public class Primarch
    {
        /// <summary>
        /// Номер
        /// </summary>
        [Key]
        public int Number { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Псевдоним
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Принадлежность
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// Родной мир
        /// </summary>
        public World HomeWorld { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
    }
}