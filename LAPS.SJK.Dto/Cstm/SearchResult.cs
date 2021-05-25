using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace LAPS.SJK.Dto.Cstm
{
    public class SearchResult : IDataMapper<SearchResult>
    {
        public string Crop(string text, int length)
        {
            if (text == null) text = string.Empty;
            text = text.Trim();
            if (text.Length > length)
            {
                text = text.Substring(0, length);
            }
            return text;
        }

        public string ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ReferenceTable { get; set; }
        public SearchResult Map(IDataReader reader)
        {
            SearchResult obj = new SearchResult();
            obj.ID = reader["ID"].ToString();
            obj.Title = reader["Title"].ToString();
            obj.Description = Crop(reader["Description"].ToString(), 250);
            obj.Url = reader["Url"].ToString();
            obj.ReferenceTable = reader["ReferenceTable"].ToString();
            return obj;
        }
    }
}
