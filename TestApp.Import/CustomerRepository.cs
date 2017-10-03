using System;
using System.Linq;
using System.Runtime.InteropServices;
using TestApp.Domain;
using TestApp.Import.Interfaces;

namespace TestApp.Import
{
    public class CustomerRepository : IDataRepository<CustomerEntry>
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public CustomerEntry Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Add(CustomerEntry entry)
        {
            var presentCustomer = _context.Customers.SingleOrDefault(it => it.CustomerNo == entry.CustomerNo);
            if (presentCustomer != null)
            {
                entry.Customer = presentCustomer;
            }
            else
            {
                var newCustomer = new Customer()
                {
                    CreatedAt = DateTime.Now,
                    CustomerNo = entry.CustomerNo,
                };
                _context.Customers.Add(newCustomer);
                _context.SaveChanges();
                entry.Customer = newCustomer;
            }
            _context.CustomerEntries.Add(entry);
            _context.SaveChanges();
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
