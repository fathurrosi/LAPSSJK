
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_culture_info : IDataMapper<tbl_culture_info>
    {
        #region tbl_culture_info Properties
        public string culture { get; set; }
        public string spec_culture { get; set; }
        public string name { get; set; }
        public Int32 id { get; set; }
        #endregion    
        public tbl_culture_info Map(System.Data.IDataReader reader)
        {
            tbl_culture_info obj = new tbl_culture_info();   
            obj.culture = reader["culture"] == DBNull.Value ? null : reader["culture"].ToString();
            obj.spec_culture = reader["spec_culture"] == DBNull.Value ? null : reader["spec_culture"].ToString();
            obj.name = reader["name"] == DBNull.Value ? null : reader["name"].ToString();
            obj.id = Convert.ToInt32(reader["id"]);
            return obj;
        }
    }
}