
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tb_contact_us : IDataMapper<tb_contact_us>
    {
        #region tb_contact_us Properties
        public Int32 contact_id { get; set; }
        public string business_day { get; set; }
        public string business_time { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        #endregion    
        public tb_contact_us Map(System.Data.IDataReader reader)
        {
            tb_contact_us obj = new tb_contact_us();   
            obj.contact_id = Convert.ToInt32(reader["contact_id"]);
            obj.business_day = reader["business_day"] == DBNull.Value ? null : reader["business_day"].ToString();
            obj.business_time = reader["business_time"] == DBNull.Value ? null : reader["business_time"].ToString();
            obj.address = reader["address"] == DBNull.Value ? null : reader["address"].ToString();
            obj.phone = reader["phone"] == DBNull.Value ? null : reader["phone"].ToString();
            obj.email = reader["email"] == DBNull.Value ? null : reader["email"].ToString();
            return obj;
        }
    }
}