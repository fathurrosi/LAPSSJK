using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAPS.SJK.Logic
{
    public class DataItem
    {
        public DataItem(string code)
        {
            this.Code = code;
            this.Text = code;
        }
        public DataItem(string code, string text)
        {
            this.Code = code;
            this.Text = text;
        }
        public string Code { get; set; }
        public string Text { get; set; }

        public string Description { get; set; }
    }
}
