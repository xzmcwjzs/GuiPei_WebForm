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
    
    public class ManagersDAL
    {
         SqlHelper db = new SqlHelper();
        public DataTable GetDataTable(ManagersModel model)
        {
            string sql = string.Format("select * from GP_Managers_login where managers_name=@managers_name and managers_password=@managers_password");
            SqlParameter[] prams = { db.MakeInParam("@managers_name",SqlDbType.NVarChar,50,model.managers_name),
                                  db.MakeInParam("@managers_password",SqlDbType.NVarChar,50,model.managers_password)};
            DataTable dt = db.RunDataTable(sql, prams);
            return dt;
        }

        public int UpdatePassword(string managers_name, string managers_password)
        {
            string sql = string.Format("update GP_Managers_login set managers_password=@managers_password where managers_name=@managers_name");
            SqlParameter[] prams = { db.MakeInParam("@managers_name",SqlDbType.NVarChar,50,managers_name),
                                  db.MakeInParam("@managers_password",SqlDbType.NVarChar,50,managers_password)};
            int n = db.RunExecuteNonQuery(sql, prams);
            return n;
        }
    }
}
