using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DAL
{
   public class ProfessionalBaseDAL
    {
        SqlHelper db=new SqlHelper();
        public List<Model.ProfessionalBaseModel> getListModel()
        {
            List<Model.ProfessionalBaseModel> list = new List<ProfessionalBaseModel>();

            string sql = string.Format("select * from GP_Professional_Base order by professional_base_code asc");
            DataTable dt = db.RunDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                Model.ProfessionalBaseModel model = new ProfessionalBaseModel();
                model.id = dr["id"].ToString();
                model.professional_base_code = dr["professional_base_code"].ToString();
                model.professional_base_name = dr["professional_base_name"].ToString();
                list.Add(model);
            }

            return list;

        }
    }
}
