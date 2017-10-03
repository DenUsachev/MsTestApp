namespace TestApp.Domain
{
    /// <summary>
    /// Extensions for the XML files for convenience
    /// </summary>
    public static class FileEntryExtensions
    {
        public static CustomerEntry ToCustomerEntry(this FileEntryBase entry)
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
