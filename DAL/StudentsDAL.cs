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
   public class StudentsDAL
    {
       SqlHelper db = new SqlHelper();
        public DataTable GetDataTable(StudentsModel model)
        {
            string sql = string.Format("select * from GP_Students_login where students_name=@students_name and students_password=@students_password");
            SqlParameter[] prams = { db.MakeInParam("@students_name",SqlDbType.NVarChar,50,model.students_name),
                                  db.MakeInParam("@students_password",SqlDbType.NVarChar,50,model.students_password)};
            DataTable dt = db.RunDataTable(sql, prams);
            return dt;
        }

        public int UpdatePassword(string students_name, string students_password)
        {
            string sql = string.Format("update GP_Students_login set students_password=@students_password where students_name=@students_name");
            SqlParameter[] prams = { db.MakeInParam("@students_name",SqlDbType.NVarChar,50,students_name),
                                  db.MakeInParam("@students_password",SqlDbType.NVarChar,50,students_password)};
            int n = db.RunExecuteNonQuery(sql, prams);
            return n;
        }
    }
}
