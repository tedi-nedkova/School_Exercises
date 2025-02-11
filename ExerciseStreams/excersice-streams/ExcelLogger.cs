using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace excersice_streams
{
    public class ExcelLogger : ILog
    {
        public List<string> logs = new List<string>();

        public void Log(string message)
        {
            logs.Add(message);
        }
        
        public void Save(string filePath)
        {
            using var workbook = new XLWorkbook();

            using (workbook)
            {
                var sheet = workbook.Worksheets.Add($"{logs[1]}");

                if (this.logs[0] == "Print")
                {
                    sheet.Cell(1, 1).Value = "Player Name";
                    sheet.Cell(1, 2).Value = "Player Position";

                    for (int i = 2; i < logs.Count; i++)
                    {
                        var logParts = logs[i].Split(" at position - ");
                        sheet.Cell(i, 1).Value = logParts[0];
                        sheet.Cell(i, 2).Value = logParts[1];
                    }
                }
                else
                {
                    sheet.Cell(1, 1).Value = "Event";

                    for (int i = 1; i < logs.Count; i++)
                    {
                        sheet.Cell(i + 1, 1).Value = logs[i];
                    }

                }

                workbook.SaveAs(filePath);
                this.logs.Clear();
            }

            
        }
    }
}
