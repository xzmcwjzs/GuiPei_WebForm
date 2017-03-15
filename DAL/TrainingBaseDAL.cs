using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
   public class TrainingBaseDAL
    {
        SqlHelper db = new SqlHelper();
        public List<Model.TrainingBaseModel> getProvinceNameListModel()
        {
            List<Model.TrainingBaseModel> list = new List<TrainingBaseModel>();

            string sql = string.Format("select province_code,province_name from GP_Training_Base Group By province_code,province_name");
            DataTable dt = db.RunDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                Model.TrainingBaseModel model = new TrainingBaseModel();
                
                model.province_code = dr["province_code"].ToString();
                model.province_name = dr["province_name"].ToString();
               
                list.Add(model);
            }

            return list;

        }

        public List<Model.TrainingBaseModel> getHospitalNameListModel(string province_code)
        {
            List<Model.TrainingBaseModel> list = new List<TrainingBaseModel>();

            string sql = string.Format("select id,hospital_code,hospital_name from GP_Training_Base where hospital_code like @province_code");
            SqlParameter[] prams = { db.MakeInParam("@province_code", SqlDbType.NVarChar, 50, province_code+"%") };
           
            DataTable dt = db.RunDataTable(sql, prams);
            foreach (DataRow dr in dt.Rows)
            {
                Model.TrainingBaseModel model = new TrainingBaseModel();
                model.id =dr["id"].ToString();
                model.hospital_code = dr["hospital_code"].ToString();
                model.hospital_name = dr["hospital_name"].ToString();

                list.Add(model);
            }

            return list;

        }

        #region   GetDt()
        public DataTable GetDt()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from GP_Training_Base ");
            
            DataTable dt = db.RunDataTable(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        } 
        #endregion
    }
}
