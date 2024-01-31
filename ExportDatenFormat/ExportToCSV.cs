/*using System.IO;
using System.Text;
using System.Linq;
using System.Globalization;

namespace ExportDatenFormat
{
    internal class ExportToCSV
    {
        private void ExportToCsv(string fileName)
        {
            // Create a new StringBuilder to store the CSV data
            StringBuilder csvData = new StringBuilder();

            // Get the properties of the first object in the list
            var properties = dataList.First().GetType().GetProperties();

            // Create the header line
            foreach (var property in properties)
            {
                csvData.Append(property.Name + ",");
            }
            csvData.Remove(csvData.Length - 1, 1); // Remove the last comma
            csvData.AppendLine();

            // Create the data lines
            foreach (var data in dataList)
            {
                foreach (var property in properties)
                {
                    var value = property.GetValue(data);
                    csvData.Append(value == null ? "" : value.ToString() + ",");
                }
                csvData.Remove(csvData.Length - 1, 1); // Remove the last comma
                csvData.AppendLine();
            }

            // Write the CSV data to the file
            System.IO.File.WriteAllText(fileName, csvData.ToString());
        }
    }
}*/
