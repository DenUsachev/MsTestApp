namespace TestApp.Domain
{
    public static class XmlFileEntryExtensions
    {
        public static CustomerEntry ToCustomerEntry(this XmlFileEntry entry)
        {
            return new CustomerEntry
            {
                Amount = entry.Amount,
                PostingDate = entry.PostingDate,
                CustomerNo = entry.CustomerNo
            };
        }
    }
}
