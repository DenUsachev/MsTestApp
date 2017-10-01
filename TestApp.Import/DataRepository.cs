using System;
using TestApp.Domain;
using TestApp.Import.Interfaces;

namespace TestApp.Import
{
    public class DataRepository : IDataRepository<CustomerEntry>
    {
        public CustomerEntry Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Add(CustomerEntry entry)
        {
            throw new NotImplementedException();
        }

        public void Delete(CustomerEntry entry)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
