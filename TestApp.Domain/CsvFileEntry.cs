using System;
using System.Globalization;

namespace TestApp.Domain
{
    public class CsvFileEntry : FileEntryBase
    {
        /// <summary>
        /// Performs data parsing of the text line with comma-separated values
        /// </summary>
        /// <param name="line">Line to parse</param>
        /// <returns></returns>
        public static CsvFileEntry FromCsvLine(string line)
        {
            var entry = new CsvFileEntry();
            DateTime postingDate;
            decimal amount;
            entry.CustomerNo = GetCommaSeparatedValueSafe(line, 0);
            var postingDateNodeValue = GetCommaSeparatedValueSafe(line, 1);
            var amountNodeValue = GetCommaSeparatedValueSafe(line, 2);
            if (DateTime.TryParseExact(postingDateNodeValue, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out postingDate))
            {
                entry.PostingDate = postingDate;
            }
            if (decimal.TryParse(amountNodeValue, out amount))
            {
                entry.Amount = amount;
            }
            return entry;
        }

        /// <summary>
        /// Tries to get value from comma-separated string by index.
        /// </summary>
        /// <param name="line">String with comma-separated values</param>
        /// <param name="index">Index of the value</param>
        /// <returns></returns>
        private static string GetCommaSeparatedValueSafe(string line, int index)
        {
            if (string.IsNullOrEmpty(line)) return null;
            var values = line.Split(';');
            return index <= values.Length - 1 ? values[index] : null;
        }
    }
}
