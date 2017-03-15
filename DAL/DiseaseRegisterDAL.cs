using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class DiseaseRegisterDAL
    {
        SqlHelper db=new SqlHelper();
        #region List<DiseaseRegisterModel> GetList(string dept_code)
        public List<DiseaseRegisterModel> GetList(string dept_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,professional_base_code,professional_base_name,dept_code,dept_name,dept_time,is_required,disease_code,disease_name,required_num,master_degree,manage_patient,full_manage,outpatient from GP_Disease_Register ");
            strSql.Append(" where disease_code like @disease_code");
            SqlParameter[] parameters = {
					new SqlParameter("@disease_code", SqlDbType.NVarChar,50)};

            parameters[0].Value = dept_code+"%";
            DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
            List<DiseaseRegisterModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<DiseaseRegisterModel>();
                DiseaseRegisterModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new DiseaseRegisterModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }

            }
            return list;

        } 
        #endregion

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        #region DiseaseRegisterModel DataRowToModel(DataRow row)
        public DiseaseRegisterModel DataRowToModel(DataRow row)
        {
            DiseaseRegisterModel model = new DiseaseRegisterModel();
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
                if (row["disease_code"] != null)
                {
                    model.disease_code = row["disease_code"].ToString();
                }
                if (row["disease_name"] != null)
                {
                    model.disease_name = row["disease_name"].ToString();
                }
                if (row["required_num"] != null)
                {
                    model.required_num = row["required_num"].ToString();
                }
                if (row["master_degree"] != null)
                {
                    model.master_degree = row["master_degree"].ToString();
                }
                if (row["manage_patient"] != null)
                {
                    model.manage_patient = row["manage_patient"].ToString();
                }
                if (row["full_manage"] != null)
                {
                    model.full_manage = row["full_manage"].ToString();
                }
                if (row["outpatient"] != null)
                {
                    model.outpatient = row["outpatient"].ToString();
                }
            }
            return model;
        } 
        #endregion



    }
}
