
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl : IDataMapper<tbl>
    {
        #region tbl Properties
        public string color { get; set; }
        public Int32? Paul { get; set; }
        public Int32? John { get; set; }
        public Int32? Tim { get; set; }
        public Int32? Eric { get; set; }
        #endregion    
        public tbl Map(System.Data.IDataReader reader)
        {
            tbl obj = new tbl();   
            obj.color = reader["color"] == DBNull.Value ? null : reader["color"].ToString();
            obj.Paul = reader["Paul"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Paul"]);
            obj.John = reader["John"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["John"]);
            obj.Tim = reader["Tim"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Tim"]);
            obj.Eric = reader["Eric"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Eric"]);
            return obj;
        }
    }
}