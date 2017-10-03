using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Domain
{
    /// <summary>
    /// Describes an entry of the given table
    /// </summary>
    public class CustomerEntry
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime PostingDate { get; set; }
        [NotMapped]
        public string CustomerNo { get; set; }
        public decimal Amount { get; set; }

        public Customer Customer { get; set; }
    }
}
