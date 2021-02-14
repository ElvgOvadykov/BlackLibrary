namespace BlackLibraryWH40K.Store.Model
{
    /// <summary>
    /// Персонаж
    /// </summary>
    public class Person
    {
        // todo добавить поле описание или биография
        /// <summary>
        /// Идентификационный номер
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Организация
        /// </summary>
        public Organization Organization { get; set; }
    }
}