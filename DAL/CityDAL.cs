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
   public class CityDAL
    {
        SqlHelper db = new SqlHelper();
        public List<Model.CityModel> getListModel(string father)
        {
            List<Model.CityModel> list = new List<CityModel>();

            string sql = string.Format("select cityid,city from GP_City where father=@father");
            SqlParameter[] prams = { db.MakeInParam("@father", SqlDbType.NVarChar, 6, father) };
                                  
            DataTable dt = db.RunDataTable(sql, prams);
            foreach (DataRow dr in dt.Rows)
            {
                Model.CityModel model = new CityModel();
                model.cityid = dr["cityid"].ToString();
                model.city = dr["city"].ToString();
                
                list.Add(model);
            }

            return list;

        }
    }
}
