using OfficeOpenXml;
using System.Data;

namespace Koala.Portal.Core.Helpers
{
    public static class ExcelPackageExtentionHelper
    {
        /// <summary>
        /// Excel dosyasını Data Table Nesnesine Dönüştürmek İçin Kullanılır.
        /// </summary>
        /// <param name="package">Excel Dosyası</param>
        /// <param name="sheetName">Okunacak Sayfa</param>
        /// <returns>Data Table</returns>
        public static DataTable ToDataTable(this ExcelPackage package,string sheetName)
        {
            if (!package.File.Exists)
            {
                throw new Exception("Okunmak istenilen Excel Dosyası Bulunamadı.");
            }
            
            var worksheet = package.Workbook.Worksheets.FirstOrDefault(x=>x.Name==sheetName);
            var dt = new DataTable();
            
            foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                dt.Columns.Add(firstRowCell.Text);
            }

            for (var i = 2; i < worksheet.Dimension.End.Row; i++)
            {
                
                var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                var newRow = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    newRow[j]= worksheet.Cells[i, j].Value == null ? string.Empty : worksheet.Cells[i, j].Value.ToString();
                }           
               
                dt.Rows.Add(newRow);
            }

            return dt;
        }
    }
}
