using System.Xml;
using TestApp.Domain;

namespace TestApp.Import.FileUploader
{
    /// <summary>
    /// Parses an XML file and uploads its records into DB.
    /// </summary>
    public class XmlFileUploader : FileUploaderBase
    {
        private const string XPATH_LOOKUP_PATTERN = "/TableA/Entry";

        public XmlFileUploader(CustomerRepository repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Reads XML file and saves it contents to the DB
        /// </summary>
        /// <param name="filepath">Import file path</param>
        public override void UploadFile(string filepath)
        {
            var doc = new XmlDocument();
            doc.Load(filepath);
            var nodes = doc.SelectNodes(XPATH_LOOKUP_PATTERN);
            foreach (XmlNode node in nodes)
            {
                var entry = XmlFileEntry.FromXmlNode(node).ToCustomerEntry();
                SaveEntry(entry);
            }
        }
    }
}
