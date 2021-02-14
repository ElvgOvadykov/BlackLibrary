namespace BlackLibraryWH40K.Store.Model
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Идентификационный номер
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Принадлежность к фракции
        /// </summary>
        public State State { get; set; }
    }
}