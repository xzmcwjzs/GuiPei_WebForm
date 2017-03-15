using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AreaDAL
    {
        SqlHelper db = new SqlHelper();
        public List<Model.AreaModel> getListModel(string father)
        {
            List<Model.AreaModel> list = new List<Model.AreaModel>();

            string sql = string.Format("select areaid,area from GP_Area where father=@father");
            SqlParameter[] prams = { db.MakeInParam("@father", SqlDbType.NVarChar, 6, father) };

            DataTable dt = db.RunDataTable(sql, prams);
            foreach (DataRow dr in dt.Rows)
            {
                Model.AreaModel model = new Model.AreaModel();
                model.areaid = dr["areaid"].ToString();
                model.area = dr["area"].ToString();

                list.Add(model);
            }

            return list;

        }
    }
}
