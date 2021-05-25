using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace LAPS.SJK.Logic.Helper
{
    public class ExcelHelper
    {

        public static void WriteExcel(HttpResponse response, string fileName, DataSet ds)
        {
            // dll refered NPOI.dll and NPOI.OOXML  

            IWorkbook workbook;

            string extension = Path.GetExtension(fileName);
            if (extension == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (extension == ".xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported");
            }
            if (ds == null) return;



            ICellStyle headerStyle = workbook.CreateCellStyle();
            headerStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
            headerStyle.FillPattern = FillPattern.SolidForeground;
            headerStyle.BorderBottom = BorderStyle.Thin;
            headerStyle.BorderTop = BorderStyle.Thin;
            headerStyle.BorderLeft = BorderStyle.Thin;
            headerStyle.BorderRight = BorderStyle.Thin;

            ICellStyle cellStyle = workbook.CreateCellStyle();
            //cellStyle .FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
            //cellStyle .FillPattern = FillPattern.SolidForeground;
            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderTop = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;

            int count = 1;
            foreach (DataTable dt in ds.Tables)
            {

                ISheet sheet1 = workbook.CreateSheet("Sheet " + count.ToString());

                //make a header row  
                IRow row1 = sheet1.CreateRow(0);

                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    ICell cell = row1.CreateCell(j);

                    string columnName = dt.Columns[j].ToString();
                    cell.SetCellValue(columnName);
                    cell.CellStyle = headerStyle;
                }

                //loops through data  
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet1.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {

                        ICell cell = row.CreateCell(j);
                        cell.CellStyle.WrapText = true;
                        string columnName = dt.Columns[j].ToString();
                        cell.SetCellValue(dt.Rows[i][columnName].ToString());
                        cell.CellStyle = cellStyle;
                    }
                }
                count++;
            }
            using (var exportData = new MemoryStream())
            {
                response.Clear();
                workbook.Write(exportData);
                if (extension == ".xlsx") //xlsx file format  
                {
                    response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
                    response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == ".xls")  //xls file format  
                {
                    response.ContentType = "application/vnd.ms-excel";
                    response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
                    response.BinaryWrite(exportData.GetBuffer());
                }
                response.End();
            }
        }
    }
}
