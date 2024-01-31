//Bei XML wird mithilfe einer XSD die Konformität der XML Datei überprüft.

using System.IO;
using System.Text;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Configuration;
using System.Xml.Schema;
using System;
using Formatting = Newtonsoft.Json.Formatting;

namespace ExportDatenFormat
{
    public partial class Form1 : Form
    {
        private DataTable dataTable;
        private string filePath;

        public Form1()
        {
            InitializeComponent();
            InitializeDataTable();
        }

        private void InitializeDataTable()
        {
            // Erstelle eine DataTable und binden an die DataGridView
            dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;

            dataTable.Columns.Add("Anzahl");
            dataTable.Columns.Add("Artikel");
            dataTable.Columns.Add("Wert");
            dataTable.Columns.Add("Währung");

        }
        /*private void ExportToCsv(string fileName)
        {

        }

        private void ExportToJson(string fileName)
        {

        }
        private void ExportToXml(string fileName)
        {
            
        }
         
         
         
         */
        
       /* private void saveDataTableToXml(DataTable dataTable, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(writer))
                {
                    dataTable.WriteXml(xmlWriter);
                }
            }
        }*/


        /*private void saveDataTableToJson(DataTable dataTable, string fileName)
        {
            string jsonData = JsonConvert.SerializeObject(dataTable, Formatting.Indented);

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(jsonData);
            }
        }*/
        /*private void exportDataTableToCsv(string fileName)
        {
            try
            {
                // 
                List<string> lines = new List<string>();
                string header = "";

                //Add headers (überschriften )
                foreach (DataColumn column in dataTable.Columns)
                {
                    header += column.ColumnName + ";";
                }
                //
                header = header.Substring(0, header.Length - 1);
                lines.Add(header);


                //Add data 
                foreach (DataRow row in dataTable.Rows)
                {
                    string line = string.Join(";", row.ItemArray);
                    lines.Add(line);
                }
                File.WriteAllLines(fileName, lines);//.toArray()
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing CSV file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            private void WriteCSV(string filePath)
            {
                // Create a new StringBuilder to hold the CSV data
                StringBuilder csvData = new StringBuilder();

                // Loop through the rows in the DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    // Loop through the columns in the row
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        // Add the column value to the CSV data, separated by commas
                        csvData.Append(row.ItemArray[i].ToString());
                        if (i < row.ItemArray.Length - 1)
                        {
                            csvData.Append(",");
                        }
                    }
                    // Add a newline character after each row
                    csvData.AppendLine();
                }

                // Write the CSV data to the file
                File.WriteAllText(filePath, csvData.ToString());
            }
        } */
        /*private void saveDataTableToJson(DataTable dataTable, string fileName)
        {


            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

            // Write the data rows
            foreach (DataRow row in dataTable.Rows)
            {
                Dictionary<string, object> rowData = new Dictionary<string, object>();

                foreach (DataColumn column in dataTable.Columns)
                {
                    rowData[column.ColumnName] = row[column];
                }

                rows.Add(rowData);
            }
            string json = JsonConvert.SerializeObject(rows, Formatting.Indented);
            File.WriteAllText(fileName, json);

        }    */

        private void WriteXML(string filePath)
        {
            // Create a new XmlDocument to hold the XML data
            XmlDocument xmlData = new XmlDocument();

            // Create a new XmlElement for the root node
            XmlElement rootNode = xmlData.CreateElement("Produkte");
            xmlData.AppendChild(rootNode);

            // Loop through the rows in the DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                // Create a new XmlElement for the row node
                XmlElement rowNode = xmlData.CreateElement("Produkt");
                rootNode.AppendChild(rowNode);

                // Loop through the columns in the row
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    // Create a new XmlElement for the column node
                    XmlElement columnNode = xmlData.CreateElement(dataTable.Columns[i].ColumnName);
                    columnNode.InnerText = row.ItemArray[i].ToString();
                    rowNode.AppendChild(columnNode);
                }
            }

            // Write the XML data to the file
            xmlData.Save(filePath);
        }
        private void WriteCSV(string filePath)
        {

            try
            {
                // 
                List<string> lines = new List<string>();
                string header = "";

                //Add headers (überschriften )
                foreach (DataColumn column in dataTable.Columns)
                {
                    header += column.ColumnName + ";";
                }
                //
                header = header.Substring(0, header.Length - 1);
                lines.Add(header);


                //Add data 
                foreach (DataRow row in dataTable.Rows)
                {
                    string line = string.Join(";", row.ItemArray);
                    lines.Add(line);
                }
                File.WriteAllLines(filePath, lines);//.toArray()
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing CSV file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void WriteJSON(string filePath)
        {
            // Create a new List<Dictionary<string, object>> to hold the JSON data
            List<Dictionary<string, object>> jsonData = new List<Dictionary<string, object>>();

            // Loop through the rows in the DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                // Create a new Dictionary<string, object> to hold the row data
                Dictionary<string, object> rowData = new Dictionary<string, object>();

                // Loop through the columns in the row
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    // Add the column name and value to the row data
                    rowData[dataTable.Columns[i].ColumnName] = row.ItemArray[i].ToString();
                }

                // Add the row data to the JSON data
                jsonData.Add(rowData);
            }

            // Write the JSON data to the file
            File.WriteAllText(filePath, JsonConvert.SerializeObject(jsonData, Formatting.Indented));
        }


        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|JSON files (*.json)|*.json|XML files (*.xml)|*.xml";
            saveFileDialog.Title = "Export";

            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            string filePath = saveFileDialog.FileName;


            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {

                filePath = saveFileDialog.FileName;
                string fileExtension = Path.GetExtension(filePath);
                WriteCSV(saveFileDialog.FileName);

                //string fileExtension = System.IO.Path.GetExtension(saveFileDialog.FileName);

                //System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.FileName.ToString());
                //file.WriteLine(dataGridView1.Text);
                //file.Close();
                switch (fileExtension)
                {
                    case ".csv":
                        // Export to CSV
                        WriteCSV(filePath);
                        break;
                    case ".json":
                        // Export to JSON
                        WriteJSON(filePath);
                        break;
                    case ".xml":
                        // Export to ExportToXML
                        WriteXML(filePath);
                        break;
                    default:
                        // Invalid selection
                        MessageBox.Show("Invalid file format selected.");
                        break;
                }
            }
            /*
            // Save the DataTable to a CSV file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv|JSON files (*.json)|*.json|XML files (*.xml)|*.xml"; ;
            //sfd.DefaultExt = ".csv";
            sfd.FileName =

            sfd.Title = "Save an Datei";
            sfd.ShowDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                int index = sfd.FilterIndex;
                switch (index)
                {
                    case 1:
                        DataTable dt = (DataTable)dataGridView1.DataSource;
                        string[] lines = new string[dt.Rows.Count + 1];

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            lines[0] += dt.Columns[i].ColumnName.ToString() + ";";
                        }

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                lines[i + 1] += dt.Rows[i][j].ToString() + ";";
                            }
                        }

                        File.WriteAllLines(sfd.FileName, lines);
                        MessageBox.Show("Data saved to " + sfd.FileName);

                        break;
                    case 2:

                        saveDataTableToXml(dataTable: dataGridView1.DataSource as DataTable, fileName);
                        break;
                    case 3:
                        saveDataTableToJson(dataGridView1.DataSource as DataTable, fileName);
                        break;

                    default:
                        break;
                }
           }*/
        }


        #region Right_Click
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Control control = sender as Control;
                // Get the current mouse position relative to the control
                Point mousePosition = new Point(e.X, e.Y);

                // Show the ContextMenuStrip at the current mouse position
                contextMenuStrip1.Show(control, mousePosition);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            exportToolStripMenuItem_Click(sender, e);
        }
        #endregion



        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

            
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



    }
}
