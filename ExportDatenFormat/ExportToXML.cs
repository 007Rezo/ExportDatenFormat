/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Xml.Serialization;
using System.Xml;


namespace ExportDatenFormat
{
    internal class ExportToXML
    {
        private void ExportToXml(string fileName)
        {
            // Create a new XmlSerializer to serialize the dataList
            XmlSerializer xmlSerializer = new XmlSerializer(dataList.GetType());

            // Create a new MemoryStream to store the XML data
            MemoryStream memoryStream = new MemoryStream();

            // Create an XmlTextWriter to write the XML data to the MemoryStream
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            // Serialize the dataList to XML
            xmlSerializer.Serialize(xmlTextWriter, dataList);

            // Read the XML data from the MemoryStream
            memoryStream.Position = 0;
            StreamReader streamReader = new StreamReader(memoryStream);
            string xmlData = streamReader.ReadToEnd();

            // Write the XML data to the file
            System.IO.File.WriteAllText(fileName, xmlData);
        }
    }
}
*/