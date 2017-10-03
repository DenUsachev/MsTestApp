using System.Collections.Generic;
using System.Xml;
using TestApp.Domain;

namespace TestApp.Import.FileUploader
{
    public class XmlFileUploader : FileUploaderBase
    {
        private const string XPATH_LOOKUP_PATTERN = "/TableA/Entry";
        private readonly CustomerRepository _repository;

        public XmlFileUploader(CustomerRepository repository)
        {
            _repository = repository;
        }

        public override void UploadFile(string filepath)
        {
            var doc = new XmlDocument();
            doc.Load(filepath);
            var nodes = doc.SelectNodes(XPATH_LOOKUP_PATTERN);
            foreach (XmlNode node in nodes)
            {
                var entry = XmlFileEntry.FromXmlNode(node).ToCustomerEntry();
                _repository.Add(entry);
            }
        }
    }
}
