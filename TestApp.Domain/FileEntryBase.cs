using System;

namespace TestApp.Domain
{
    public class FileEntryBase
    {
        public string CustomerNo { get; set; }
        public DateTime PostingDate { get; set; }
        public decimal Amount { get; set; }
    }
}
