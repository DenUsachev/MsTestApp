using System;
using System.Linq;
using TestApp.Domain;
using TestApp.Import.Interfaces;

namespace TestApp.Import
{
    /// <summary>
    /// Manages  the databaes of an application
    /// </summary>
    public class CustomerRepository : IDataRepository<CustomerEntry>
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the entity by its key
        /// </summary>
        /// <param name="id">Entity key</param>
        /// <returns></returns>
        public CustomerEntry Get(int id)
        {
            return _context.CustomerEntries.SingleOrDefault(it => it.Id == id);
        }

        /// <summary>
        /// Adds new entity to the DB
        /// </summary>
        /// <param name="entry">Entity object</param>
        public void Add(CustomerEntry entry)
        {
            var presentCustomer = _context.Customers.SingleOrDefault(it => it.CustomerNo == entry.CustomerNo);
            if (presentCustomer != null)
            {

                entry.Customer = presentCustomer;
            }
            else
            {
                var newCustomer = new Customer { CreatedAt = DateTime.Now, CustomerNo = entry.CustomerNo };
                _context.Customers.Add(newCustomer);
                _context.SaveChanges();
                entry.Customer = newCustomer;
            }
            _context.CustomerEntries.Add(entry);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes an entity from the DB
        /// </summary>
        /// <param name="entry">Entity object</param>
        public void Delete(CustomerEntry entry)
        {
            var presentEntry = _context.CustomerEntries.SingleOrDefault(it => it.Id == entry.Id);
            if (presentEntry != null)
            {
                _context.CustomerEntries.Remove(entry);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates an entity if it exists
        /// </summary>
        /// <param name="entry">Entity object</param>
        public void Update(CustomerEntry entry)
        {
            var presentEntry = _context.CustomerEntries.SingleOrDefault(it => it.Id == entry.Id);
            if (presentEntry != null)
            {
                _context.Entry(entry).CurrentValues.SetValues(entry);
                _context.SaveChanges();
            }
        }
    }
}
