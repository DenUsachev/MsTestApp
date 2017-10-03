using System;
using System.Globalization;
using System.Xml;

namespace TestApp.Domain
{
    public class XmlFileEntry
    {
        public string CustomerNo { get; set; }
        public DateTime PostingDate { get; set; }
        public decimal Amount { get; set; }

        /// <summary>
        /// Performs data parsing of XML subnodes 
        /// </summary>
        /// <param name="node">XML node to parse</param>
        /// <returns></returns>
        public static XmlFileEntry FromXmlNode(XmlNode node)
        {
            var entry = new XmlFileEntry();
            DateTime postingDate;
            decimal amount;

            entry.CustomerNo = GetXmlNodeValueSafe(node.ChildNodes, 0);

            var postingDateNodeValue = GetXmlNodeValueSafe(node.ChildNodes, 1);
            var amountNodeValue = GetXmlNodeValueSafe(node.ChildNodes, 2);
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
        /// Tries to get XML node value.
        /// </summary>
        /// <param name="nodes">List of XML Nodes</param>
        /// <param name="index">Index of the Node to get value</param>
        /// <returns></returns>
        private static string GetXmlNodeValueSafe(XmlNodeList nodes, int index)
        {
            return index <= nodes.Count - 1 ? nodes[index].InnerText : null;
        }
    }
}
