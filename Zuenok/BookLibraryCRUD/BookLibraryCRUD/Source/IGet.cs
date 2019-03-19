namespace BookLibraryCRUD
{
    /// <summary>
    ///     interface with access and search methods
    /// </summary>
    /// <typeparam name="T">template type, for example Book</typeparam>
    public interface IGet<out T>
    {
        /// <summary>
        ///     Get entity by ID
        /// </summary>
        /// <param name="id">ID book</param>
        /// <returns>T, for example Book</returns>
        T Get(int id);

        /// <summary>
        ///     Access to the last item in the list of books
        /// </summary>
        /// <returns>T, for example Book</returns>
        T GetLast();
    }
}