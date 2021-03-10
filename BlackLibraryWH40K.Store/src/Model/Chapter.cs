using System.Collections.Generic;

namespace BlackLibraryWH40K.Store.Model
{
    /// <summary>
    /// Орден космодесанта
    /// </summary>
    public class Chapter
    {
        /// <summary>
        /// Идентификационный номер
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название ордена
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Боевой клич
        /// </summary>
        public string Warcry { get; set; }

        /// <summary>
        /// Магистр ордена
        /// </summary>
        public Person ChapterMaster { get; set; }

        /// <summary>
        /// Легион прородитель
        /// </summary>
        public Legion Legion { get; set; }

        /// <summary>
        /// Приемники
        /// </summary>
        public ICollection<Chapter> Successors { get; set; }

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