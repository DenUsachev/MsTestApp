using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Domain
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<CustomerEntry> Entries { get; set; }
    }
}
