using System;

namespace TestApp.Import.Interfaces
{
    public interface IDataRepository<T> where T : class
    {
        T Get(Guid id);

        void Add(T entry);

        void Delete(T entry);

        void Update(T entry);
    }
}
