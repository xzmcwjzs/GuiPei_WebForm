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
   
   public class ProvinceDAL
    {
       SqlHelper db = new SqlHelper();
       public List<Model.ProvinceModel> getListModel()
       {
           List<Model.ProvinceModel> list = new List<ProvinceModel>();

           string sql = string.Format("select * from GP_Province ");
           DataTable dt = db.RunDataTable(sql);
           foreach (DataRow dr in dt.Rows)
           {
               Model.ProvinceModel model = new ProvinceModel();
               model.id = Convert.ToInt32(dr["id"]);
               model.provinceid = dr["provinceid"].ToString();
               model.province = dr["province"].ToString();
               list.Add(model);
           }

           return list;

       }
       //public DataTable getListModel1()
       //{
       //    string sql = string.Format("select id,province from GP_Province ");
       //    DataTable dt = db.RunDataTable(sql);
       //    return dt;
       //}
    }
}
