using LAPS.SJK.Dto.Cstm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAPS.SJK.Logic
{
    public class GenerateTableHTML
    {
        protected static string ExportDatatableToHtml(DataTable dt)
        {
            StringBuilder strHTMLBuilder = new StringBuilder(); 
            strHTMLBuilder.Append("<table class='display' id='' style='width: 100%;'>");
            strHTMLBuilder.Append("<thead >");
            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<th >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</th>");

            }
            strHTMLBuilder.Append("</tr>");
            strHTMLBuilder.Append("</thead >");

            foreach (DataRow myRow in dt.Rows)
            {

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }

            //Close tags.  
            strHTMLBuilder.Append("</table>"); 

            string Htmltext = strHTMLBuilder.ToString();

            return Htmltext;

        }

        public static tbl_page_content_result generatePageTableData(DataTable dt, int? post_order, string post_type)
        {
            tbl_page_content_result obj = new tbl_page_content_result();  
            obj.content_text = ExportDatatableToHtml(dt);
            obj.post_order = post_order;
            obj.post_type = post_type;
            return obj;
        }

    }
}
