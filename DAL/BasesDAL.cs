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
   public class BasesDAL
    {
        SqlHelper db = new SqlHelper();
        public DataTable GetDataTable(BasesModel model)
        {
            string sql = string.Format("select * from GP_Bases_login where bases_name=@bases_name and bases_password=@bases_password");
            SqlParameter[] prams = { db.MakeInParam("@bases_name",SqlDbType.NVarChar,50,model.bases_name),
                                  db.MakeInParam("@bases_password",SqlDbType.NVarChar,50,model.bases_password)};
            DataTable dt = db.RunDataTable(sql, prams);
            return dt;
        }

        public int UpdatePassword(string bases_name, string bases_password)
        {
            string sql = string.Format("update GP_Bases_login set bases_password=@bases_password where bases_name=@bases_name");
            SqlParameter[] prams = { db.MakeInParam("@bases_name",SqlDbType.NVarChar,50,bases_name),
                                  db.MakeInParam("@bases_password",SqlDbType.NVarChar,50,bases_password)};
            int n = db.RunExecuteNonQuery(sql, prams);
            return n;
        }
    }
}
