namespace TestApp.Import.Interfaces
{
    /// <summary>
    /// DB Repository interface
    /// </summary>
    /// <typeparam name="T">Type of entries which are stored in the repository</typeparam>
    public interface IDataRepository<T> where T : class
    {
        T Get(int id);

        bool Add(T entry);

        void Delete(T entry);

        void Update(T entry);
    }
}
