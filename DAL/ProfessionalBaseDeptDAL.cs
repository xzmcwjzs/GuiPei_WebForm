using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public class ProfessionalBaseDeptDAL
   {
        SqlHelper db = new SqlHelper();
        #region GetDeptDataTableByCode(string professional_base_code)
        public DataTable GetDeptDataTableByCode(string professional_base_code)
        {
            
            string sql = string.Format("select * from GP_Professional_Base_Dept where professional_base_code=@professional_base_code order by dept_code asc");
            SqlParameter[] prams = { db.MakeInParam("@professional_base_code", SqlDbType.NVarChar, 50, professional_base_code) };

            DataTable dt = db.RunDataTable(sql, prams);
            return dt;
        }
       #endregion

        #region GetDeptList(string professional_base_code)
        public List<ProfessionalBaseDeptModel> GetDeptList(string professional_base_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,professional_base_code,professional_base_name,dept_code,dept_name,dept_time,is_required from GP_Professional_Base_Dept ");
            strSql.Append(" where professional_base_code=@professional_base_code order by dept_code asc");
            SqlParameter[] parameters = {
					new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50)};
            parameters[0].Value = professional_base_code;
            DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
            List<ProfessionalBaseDeptModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<ProfessionalBaseDeptModel>();
                ProfessionalBaseDeptModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new ProfessionalBaseDeptModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        } 
        #endregion

        #region DataRowToModel(DataRow row)
        public ProfessionalBaseDeptModel DataRowToModel(DataRow row)
        {
            ProfessionalBaseDeptModel model = new ProfessionalBaseDeptModel();
            if (row != null)
            {
                if (row["id"] != null)
                {
                    model.id = row["id"].ToString();
                }
                if (row["professional_base_code"] != null)
                {
                    model.professional_base_code = row["professional_base_code"].ToString();
                }
                if (row["professional_base_name"] != null)
                {
                    model.professional_base_name = row["professional_base_name"].ToString();
                }
                if (row["dept_code"] != null)
                {
                    model.dept_code = row["dept_code"].ToString();
                }
                if (row["dept_name"] != null)
                {
                    model.dept_name = row["dept_name"].ToString();
                }
                if (row["dept_time"] != null)
                {
                    model.dept_time = row["dept_time"].ToString();
                }
                if (row["is_required"] != null)
                {
                    model.is_required = row["is_required"].ToString();
                }
            }
            return model;
        } 
        #endregion


        #region  DataTable GetDt()
        public DataTable GetDt()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from GP_Professional_Base_Dept ");

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
