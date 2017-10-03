using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Domain
{
    /// <summary>
    /// Describes the Customer entry in the DB
    /// </summary>
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string CustomerNo { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<CustomerEntry> Entries { get; set; }
    }
}
