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
    public class TeachersDAL
    {
        SqlHelper db = new SqlHelper();
        #region GetDataTable(TeachersModel model)
        public DataTable GetDataTable(TeachersModel model)
        {
            string sql = string.Format("select * from GP_Teachers_login where teachers_name=@teachers_name and teachers_password=@teachers_password");
            SqlParameter[] prams = { db.MakeInParam("@teachers_name",SqlDbType.VarChar,50,model.teachers_name),
                                  db.MakeInParam("@teachers_password",SqlDbType.VarChar,50,model.teachers_password)};
            DataTable dt = db.RunDataTable(sql, prams);
            return dt;
        }
        #endregion
        #region  UpdatePassword(string teachers_name, string teachers_password)
        public int UpdatePassword(string teachers_name, string teachers_password)
        {
            string sql = string.Format("update GP_Teachers_login set teachers_password=@teachers_password where teachers_name=@teachers_name");
            SqlParameter[] prams = { db.MakeInParam("@teachers_name",SqlDbType.NVarChar,50,teachers_name),
                                  db.MakeInParam("@teachers_password",SqlDbType.NVarChar,50,teachers_password)};
            int n = db.RunExecuteNonQuery(sql, prams);
            return n;
        }
        #endregion

        #region getTeachersNameList(string training_base_code,string professional_base_code)
        public List<Model.TeachersModel> getTeachersNameList(string training_base_code, string professional_base_code)
        {
            List<Model.TeachersModel> list = new List<TeachersModel>();

            string sql = string.Format("select * from GP_Teachers_login where training_base_code=@training_base_code and professional_base_code=@professional_base_code");
            SqlParameter[] prams = { db.MakeInParam("@training_base_code", SqlDbType.NVarChar, 50, training_base_code),
                                   db.MakeInParam("@professional_base_code", SqlDbType.NVarChar, 50, professional_base_code)};

            DataTable dt = db.RunDataTable(sql, prams);
            foreach (DataRow dr in dt.Rows)
            {
                Model.TeachersModel model = new TeachersModel();
                model.teachers_name = dr["teachers_name"].ToString();
                model.teachers_real_name = dr["teachers_real_name"].ToString();
                model.training_base_code = dr["training_base_code"].ToString();
                model.training_base_name = dr["training_base_name"].ToString();
                model.professional_base_code = dr["professional_base_code"].ToString();
                model.professional_base_name = dr["professional_base_name"].ToString();
                model.dept_code = dr["dept_code"].ToString();
                model.dept_name = dr["dept_name"].ToString();

                list.Add(model);
            }

            return list;

        }
        #endregion

        
    }
}
