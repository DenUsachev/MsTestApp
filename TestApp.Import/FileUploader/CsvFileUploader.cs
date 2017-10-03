using System.IO;
using TestApp.Domain;

namespace TestApp.Import.FileUploader
{
    /// <summary>
    /// Parses the CSV file and uploads its records into DB.
    /// </summary>
    public class CsvFileUploader : FileUploaderBase
    {
        public CsvFileUploader(CustomerRepository repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Reads CSV file and saves it contents to the DB
        /// </summary>
        /// <param name="filepath">Import file path</param>
        public override void UploadFile(string filepath)
        {
            using (var streamReader = new StreamReader(filepath))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    var entry = CsvFileEntry.FromCsvLine(line).ToCustomerEntry();
                    SaveEntry(entry);
                }
            }
        }
    }
}
