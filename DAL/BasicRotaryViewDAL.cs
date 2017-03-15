using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
using Common;
namespace DAL
{
   public class BasicRotaryViewDAL
    {
        SqlHelper db = new SqlHelper();
//        #region  GetPagedListBasic
//        public List<Model.BasicRotaryViewModel> GetPagedListBasic(string training_base_code, string dept_code, string instructor, string instructor_tag, string name, string sex, string minzu, string high_education, string high_school, string identity_type, string send_unit, string collaborative_unit, string training_time, string plan_training_time,
// int pageIndex, int pageSize, out int rowCount, out int pageCount)
//        {

//            List<Model.BasicRotaryViewModel> list = null;
//            if (sex == string.Empty || sex == "") sex = null;
//            if (name == string.Empty || name == "") name = null;
//            if (minzu == string.Empty || minzu == "") minzu = null;
//            if (high_education == string.Empty || high_education == "") high_education = null;
//            if (high_school == string.Empty || high_school == "") high_school = null;
//            if (identity_type == string.Empty || identity_type == "") identity_type = null;
//            if (send_unit == string.Empty || send_unit == "") send_unit = null;
//            if (collaborative_unit == string.Empty || collaborative_unit == "") collaborative_unit = null;
//            if (training_time == string.Empty || training_time == "") training_time = null;
//            if (plan_training_time == string.Empty || plan_training_time == "") plan_training_time = null;

////name, sex, minzu, high_education, high_school, identity_type, send_unit, collaborative_unit, training_time, plan_training_time

//            DataTable dt = db.RunPagedDataPro("GetPageList", " id,name,real_name,sex,age,datebirth,minzu,province,city,area,detail_address,id_number,telephon,mail,bk_school,bk_major,graduation_time,high_education,high_school,high_major,high_education_time,identity_type,send_unit,training_base_province_code,training_base_province_name,training_base_code,training_base_name,collaborative_unit,professional_base_name,professional_base_code,training_time,plan_training_time,writor,register_date", "Basic_Rotary_view", "training_base_code='" + training_base_code
//                + "' and rotary_dept_code='" + dept_code + "' and instructor='" + instructor + "' and instructor_tag='" + instructor_tag 
//                + "' and real_name like ISNULL('%"+name+"%',real_name) and sex like ISNULL('%"+sex+"%',sex) and minzu like ISNULL('%"+minzu+"%',minzu)"
//            + "and high_education like ISNULL('%" + high_education + "%',high_education) and high_school like ISNULL('%" + high_school + "%',high_school)"
//            + "and identity_type like ISNULL('%" + identity_type + "%',identity_type) and send_unit like isnull('%" + send_unit + "%',send_unit)"
//            + "and collaborative_unit like isnull('%" + collaborative_unit + "%',collaborative_unit) and training_time like isnull('%" + training_time + "%',training_time) and plan_training_time like isnull('%" + plan_training_time + "%',plan_training_time)"
//               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

//            //将数据表转为泛型集合
//            if (dt.Rows.Count > 0)
//            {
//                list = new List<BasicRotaryViewModel>();
//                Model.BasicRotaryViewModel model = null;//声明实体对象
//                foreach (DataRow dr in dt.Rows)
//                {
//                    model = new Model.BasicRotaryViewModel();
//                    model.id = dr["id"].ToString();
//                    model.name = dr["name"].ToString();
//                    model.real_name = dr["real_name"].ToString();
//                    model.sex = dr["sex"].ToString();
//                    model.age = dr["age"].ToString();
//                    model.datebirth = dr["datebirth"].ToString();
//                    model.minzu = dr["minzu"].ToString();
//                    model.province = dr["province"].ToString();
//                    model.city = dr["city"].ToString();
//                    model.area = dr["area"].ToString();
//                    model.id_number = dr["id_number"].ToString();
//                    model.detail_address = dr["detail_address"].ToString();
//                    model.telephon = dr["telephon"].ToString();
//                    model.mail = dr["mail"].ToString();
//                    model.bk_major = dr["bk_major"].ToString();
//                    model.bk_school = dr["bk_school"].ToString();
//                    model.graduation_time = dr["graduation_time"].ToString();
//                    model.high_education = dr["high_education"].ToString();
//                    model.high_school = dr["high_school"].ToString();
//                    model.high_major = dr["high_major"].ToString();
//                    model.high_education_time = dr["high_education_time"].ToString();
//                    model.identity_type = dr["identity_type"].ToString();
//                    model.send_unit = dr["send_unit"].ToString();
//                    model.training_base_province_code = dr["training_base_province_code"].ToString();
//                    model.training_base_province_name = dr["training_base_province_name"].ToString();
//                    model.training_base_code = dr["training_base_code"].ToString();
//                    model.training_base_name = dr["training_base_name"].ToString();
//                    model.collaborative_unit = dr["collaborative_unit"].ToString();
//                    model.professional_base_code = dr["professional_base_code"].ToString();
//                    model.professional_base_name = dr["professional_base_name"].ToString();
//                    model.training_time = dr["training_time"].ToString();
//                    model.plan_training_time = dr["plan_training_time"].ToString();
//                    model.writor = dr["writor"].ToString();
//                    model.register_date = dr["register_date"].ToString();
//                    list.Add(model);
//                }
//            }
//            return list;
//        }
//        #endregion

        #region Basic分页
        public List<Model.BasicRotaryViewModel> GetPagedListBasic(string training_base_code, string dept_code, string instructor_tag,
            string name, string sex, string minzu, string high_education, string high_school, string identity_type, string send_unit, string collaborative_unit, string training_time, string plan_training_time,
        int start, int end)
        {
            string sql = "select id,name,real_name, sex,age,datebirth,minzu,province,city, area,detail_address,id_number,telephon,mail,bk_school,bk_major,graduation_time,high_education, high_school, high_major,high_education_time,identity_type, send_unit,training_base_province_code, training_base_province_name,training_base_code,training_base_name,collaborative_unit,professional_base_name, professional_base_code,training_time, plan_training_time,writor,register_date from (select row_number() over(order by register_date desc) as num,* from Basic_Rotary_view where  training_base_code='" + training_base_code + "' and rotary_dept_code='" + dept_code + "' and instructor_tag='" + instructor_tag + "'";

            if (!string.IsNullOrEmpty(name))
            {
                sql += "and name = '" + name + "'";
            }
            if (!string.IsNullOrEmpty(sex))
            {
                sql += "and sex = '" + sex + "'";
            }
            if (!string.IsNullOrEmpty(minzu))
            {
                sql += "and minzu like '%" + minzu + "%'";
            }
            if (!string.IsNullOrEmpty(high_education))
            {
                sql += "and high_education = '" + high_education + "'";
            }
            if (!string.IsNullOrEmpty(high_school))
            {
                sql += "and high_school like '%" + high_school + "%'";
            }
            if (!string.IsNullOrEmpty(identity_type))
            {
                sql += "and identity_type = '" + identity_type + "'";
            }
            if (!string.IsNullOrEmpty(send_unit))
            {
                sql += "and send_unit like '%" + send_unit + "%'";
            }
            if (!string.IsNullOrEmpty(collaborative_unit))
            {
                sql += "and collaborative_unit like '%" + collaborative_unit + "%'";
            }
            if (!string.IsNullOrEmpty(training_time))
            {
                sql += "and training_time like '%" + training_time + "%'";
            }
            if (!string.IsNullOrEmpty(plan_training_time))
            {
                sql += "and plan_training_time like '%" + plan_training_time + "%'";
            }

            sql += ")as t where t.num>=@start and t.num<=@end";
            sql += " group by id,name,real_name, sex,age,datebirth,minzu,province,city, area,detail_address,id_number,telephon,mail,bk_school,bk_major,graduation_time,high_education, high_school, high_major,high_education_time,identity_type, send_unit,training_base_province_code, training_base_province_name,training_base_code,training_base_name,collaborative_unit,professional_base_name, professional_base_code,training_time, plan_training_time,writor,register_date";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<BasicRotaryViewModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<BasicRotaryViewModel>();
                Model.BasicRotaryViewModel model = null;//声明实体对象
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Model.BasicRotaryViewModel();
                    model.id = dr["id"].ToString();
                    model.name = dr["name"].ToString();
                    model.real_name = dr["real_name"].ToString();
                    model.sex = dr["sex"].ToString();
                    model.age = dr["age"].ToString();
                    model.datebirth = dr["datebirth"].ToString();
                    model.minzu = dr["minzu"].ToString();
                    model.province = dr["province"].ToString();
                    model.city = dr["city"].ToString();
                    model.area = dr["area"].ToString();
                    model.id_number = dr["id_number"].ToString();
                    model.detail_address = dr["detail_address"].ToString();
                    model.telephon = dr["telephon"].ToString();
                    model.mail = dr["mail"].ToString();
                    model.bk_major = dr["bk_major"].ToString();
                    model.bk_school = dr["bk_school"].ToString();
                    model.graduation_time = dr["graduation_time"].ToString();
                    model.high_education = dr["high_education"].ToString();
                    model.high_school = dr["high_school"].ToString();
                    model.high_major = dr["high_major"].ToString();
                    model.high_education_time = dr["high_education_time"].ToString();
                    model.identity_type = dr["identity_type"].ToString();
                    model.send_unit = dr["send_unit"].ToString();
                    model.training_base_province_code = dr["training_base_province_code"].ToString();
                    model.training_base_province_name = dr["training_base_province_name"].ToString();
                    model.training_base_code = dr["training_base_code"].ToString();
                    model.training_base_name = dr["training_base_name"].ToString();
                    model.collaborative_unit = dr["collaborative_unit"].ToString();
                    model.professional_base_code = dr["professional_base_code"].ToString();
                    model.professional_base_name = dr["professional_base_name"].ToString();
                    model.training_time = dr["training_time"].ToString();
                    model.plan_training_time = dr["plan_training_time"].ToString();
                    model.writor = dr["writor"].ToString();
                    model.register_date = dr["register_date"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }


        public int GetRecordCountBasic(string training_base_code, string dept_code, string instructor_tag,
            string name, string sex, string minzu, string high_education, string high_school, string identity_type, string send_unit, string collaborative_unit, string training_time, string plan_training_time)
        {
            string sql = "select COUNT(name) from (select name from Basic_Rotary_view where training_base_code='" + training_base_code
                + "' and rotary_dept_code='" + dept_code + "' and instructor_tag='"+instructor_tag+"'";
            if (!string.IsNullOrEmpty(name))
            {
                sql += "and name = '" + name + "'";
            }
            if (!string.IsNullOrEmpty(sex))
            {
                sql += "and sex = '" + sex + "'";
            }
            if (!string.IsNullOrEmpty(minzu))
            {
                sql += "and minzu like '%" + minzu + "%'";
            }
            if (!string.IsNullOrEmpty(high_education))
            {
                sql += "and high_education = '" + high_education + "'";
            }
            if (!string.IsNullOrEmpty(high_school))
            {
                sql += "and high_school like '%" + high_school + "%'";
            }
            if (!string.IsNullOrEmpty(identity_type))
            {
                sql += "and identity_type = '" + identity_type + "'";
            }
            if (!string.IsNullOrEmpty(send_unit))
            {
                sql += "and send_unit like '%" + send_unit + "%'";
            }
            if (!string.IsNullOrEmpty(collaborative_unit))
            {
                sql += "and collaborative_unit like '%" + collaborative_unit + "%'";
            }
            if (!string.IsNullOrEmpty(training_time))
            {
                sql += "and training_time like '%" + training_time + "%'";
            }
            if (!string.IsNullOrEmpty(plan_training_time))
            {
                sql += "and plan_training_time like '%" + plan_training_time + "%'";
            }
            sql += " group by name)as a";
            int count=Convert.ToInt32(db.RunExecuteScalar(sql));
            return count;
        }
        #endregion
        #region GetPagedListRotary
        public List<Model.BasicRotaryViewModel> GetPagedListRotary(string training_base_code, string dept_code, string instructor, string instructor_tag, string name, string sex, string high_education, string identity_type, string send_unit, string collaborative_unit, string training_time, string plan_training_time, string rotary_begin_time, string rotary_end_time, string outdept_status,
          int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {

            List<Model.BasicRotaryViewModel> list = null;

            if (sex == string.Empty || sex == "") sex = null;
            if (name == string.Empty || name == "") name = null;
            if (high_education == string.Empty || high_education == "") high_education = null;
            if (identity_type == string.Empty || identity_type == "") identity_type = null;
            if (send_unit == string.Empty || send_unit == "") send_unit = null;
            if (collaborative_unit == string.Empty || collaborative_unit == "") collaborative_unit = null;
            if (training_time == string.Empty || training_time == "") training_time = null;
            if (plan_training_time == string.Empty || plan_training_time == "") plan_training_time = null;

            if (rotary_begin_time == string.Empty || rotary_begin_time == "")
            {
                rotary_begin_time = null;
            }
            else {
                rotary_begin_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(rotary_begin_time,"yyyy-MM");
            }
            if (rotary_end_time == string.Empty || rotary_end_time == "")
            {
                rotary_end_time = null;
            }
            else {
                rotary_end_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(rotary_end_time,"yyyy-MM");
            }
            if (outdept_status == string.Empty || outdept_status == "") outdept_status = null;
            //+"and rotary_begin_time >= isnull('"+rotary_begin_time+"',rotary_begin_time) and rotary_end_time<=isnull('"+rotary_end_time+"',rotary_end_time)"
            DataTable dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,sex,high_education,high_major,rotary_begin_time,rotary_end_time," +
               "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
               "instructor,instructor_tag,GP_Students_Rotary_id,GP_Students_Rotary_writor,GP_Students_Rotary_register_date,outdept_status,outdept_application,questionnaire_status", "Basic_Rotary_view", "training_base_code='" + training_base_code
                + "' and rotary_dept_code='" + dept_code + "' and instructor='" + instructor + "' and instructor_tag='" + instructor_tag
                + "'and real_name like ISNULL('%" + name + "%',real_name) and sex like ISNULL('%" + sex + "%',sex)"
            + "and high_education like ISNULL('%" + high_education + "%',high_education)"
            + "and identity_type like ISNULL('%" + identity_type + "%',identity_type) and send_unit like isnull('%" + send_unit + "%',send_unit)"
            + "and collaborative_unit like isnull('%" + collaborative_unit + "%',collaborative_unit) and training_time like isnull('%" + training_time + "%',training_time) and plan_training_time like isnull('%" + plan_training_time + "%',plan_training_time)"
           +"and rotary_begin_time like isnull('%"+rotary_begin_time+"%',rotary_begin_time) and rotary_end_time like isnull('%"+rotary_end_time+"%',rotary_end_time)"
            + "and outdept_status like isnull('%" + outdept_status + "%',outdept_status)"
                , "GP_Students_Rotary_register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);
           //将数据表转为泛型集合
            if (dt.Rows.Count > 0)
            {
                list = new List<BasicRotaryViewModel>();
                Model.BasicRotaryViewModel model = null;//声明实体对象
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Model.BasicRotaryViewModel();
                    model.id = dr["id"].ToString();
                    model.name = dr["name"].ToString();
                    model.real_name = dr["real_name"].ToString();
                    model.sex = dr["sex"].ToString();
                    model.high_education = dr["high_education"].ToString();
                    model.high_major = dr["high_major"].ToString();

                    model.rotary_begin_time = dr["rotary_begin_time"].ToString();
                    model.rotary_end_time = dr["rotary_end_time"].ToString();

                    model.training_base_code = dr["training_base_code"].ToString();
                    model.training_base_name = dr["training_base_name"].ToString();

                    model.professional_base_code = dr["professional_base_code"].ToString();
                    model.professional_base_name = dr["professional_base_name"].ToString();
                    model.GP_Students_Rotary_id = dr["GP_Students_Rotary_id"].ToString();
                    model.rotary_dept_code = dr["rotary_dept_code"].ToString();
                    model.rotary_dept_name = dr["rotary_dept_name"].ToString();
                    model.instructor = dr["instructor"].ToString();
                    model.instructor_tag = dr["instructor_tag"].ToString();
                    model.GP_Students_Rotary_writor = dr["GP_Students_Rotary_writor"].ToString();
                    model.GP_Students_Rotary_register_date = dr["GP_Students_Rotary_register_date"].ToString();
                    model.outdept_status = dr["outdept_status"].ToString();
                    model.outdept_application = dr["outdept_application"].ToString();
                    model.questionnaire_status = dr["questionnaire_status"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion

        #region GetModel
        public Model.BasicRotaryViewModel GetModelByGP_Students_Rotary_id(string GP_Students_Rotary_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Basic_Rotary_View ");
            strSql.Append(" where GP_Students_Rotary_id=@GP_Students_Rotary_id");
            SqlParameter[] parameters = {
					new SqlParameter("@GP_Students_Rotary_id", SqlDbType.NVarChar,50)};
            
            parameters[0].Value = GP_Students_Rotary_id;
            

            Model.BasicRotaryViewModel model = new Model.BasicRotaryViewModel();
            DataSet ds = db.RunDataSet(strSql.ToString(), parameters,"tbName");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


       

        #endregion

        #region GetList
        public DataSet GetListByGP_Students_Rotary_id(string GP_Students_Rotary_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Basic_Rotary_View ");
            strSql.Append(" where GP_Students_Rotary_id=@GP_Students_Rotary_id");
            SqlParameter[] parameters = {
					new SqlParameter("@GP_Students_Rotary_id", SqlDbType.NVarChar,50)};

            parameters[0].Value = GP_Students_Rotary_id;


            Model.BasicRotaryViewModel model = new Model.BasicRotaryViewModel();
            return db.RunDataSet(strSql.ToString(), parameters, "tbName");

        } 
        #endregion


        #region DataRowToModel(DataRow row)
        public BasicRotaryViewModel DataRowToModel(DataRow row)
        {
            BasicRotaryViewModel model = new BasicRotaryViewModel();
            if (row != null)
            {
                if (row["id"] != null)
                {
                    model.id = row["id"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["real_name"] != null)
                {
                    model.real_name = row["real_name"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["age"] != null)
                {
                    model.age = row["age"].ToString();
                }
                if (row["datebirth"] != null)
                {
                    model.datebirth = row["datebirth"].ToString();
                }
                if (row["minzu"] != null)
                {
                    model.minzu = row["minzu"].ToString();
                }
                if (row["province"] != null)
                {
                    model.province = row["province"].ToString();
                }
                if (row["city"] != null)
                {
                    model.city = row["city"].ToString();
                }
                if (row["area"] != null)
                {
                    model.area = row["area"].ToString();
                }
                if (row["detail_address"] != null)
                {
                    model.detail_address = row["detail_address"].ToString();
                }
                if (row["id_number"] != null)
                {
                    model.id_number = row["id_number"].ToString();
                }
                if (row["telephon"] != null)
                {
                    model.telephon = row["telephon"].ToString();
                }
                if (row["mail"] != null)
                {
                    model.mail = row["mail"].ToString();
                }
                if (row["bk_school"] != null)
                {
                    model.bk_school = row["bk_school"].ToString();
                }
                if (row["bk_major"] != null)
                {
                    model.bk_major = row["bk_major"].ToString();
                }
                if (row["graduation_time"] != null)
                {
                    model.graduation_time = row["graduation_time"].ToString();
                }
                if (row["high_education"] != null)
                {
                    model.high_education = row["high_education"].ToString();
                }
                if (row["high_school"] != null)
                {
                    model.high_school = row["high_school"].ToString();
                }
                if (row["high_major"] != null)
                {
                    model.high_major = row["high_major"].ToString();
                }
                if (row["high_education_time"] != null)
                {
                    model.high_education_time = row["high_education_time"].ToString();
                }
                if (row["identity_type"] != null)
                {
                    model.identity_type = row["identity_type"].ToString();
                }
                if (row["send_unit"] != null)
                {
                    model.send_unit = row["send_unit"].ToString();
                }
                if (row["training_base_province_code"] != null)
                {
                    model.training_base_province_code = row["training_base_province_code"].ToString();
                }
                if (row["training_base_province_name"] != null)
                {
                    model.training_base_province_name = row["training_base_province_name"].ToString();
                }
                if (row["training_base_code"] != null)
                {
                    model.training_base_code = row["training_base_code"].ToString();
                }
                if (row["training_base_name"] != null)
                {
                    model.training_base_name = row["training_base_name"].ToString();
                }
                if (row["collaborative_unit"] != null)
                {
                    model.collaborative_unit = row["collaborative_unit"].ToString();
                }
                if (row["professional_base_name"] != null)
                {
                    model.professional_base_name = row["professional_base_name"].ToString();
                }
                if (row["professional_base_code"] != null)
                {
                    model.professional_base_code = row["professional_base_code"].ToString();
                }
                if (row["training_time"] != null)
                {
                    model.training_time = row["training_time"].ToString();
                }
                if (row["plan_training_time"] != null)
                {
                    model.plan_training_time = row["plan_training_time"].ToString();
                }
                if (row["writor"] != null)
                {
                    model.writor = row["writor"].ToString();
                }
                if (row["register_date"] != null)
                {
                    model.register_date = row["register_date"].ToString();
                }
                if (row["GP_Students_Rotary_id"] != null)
                {
                    model.GP_Students_Rotary_id = row["GP_Students_Rotary_id"].ToString();
                }
                if (row["GP_Students_Rotary_name"] != null)
                {
                    model.GP_Students_Rotary_name = row["GP_Students_Rotary_name"].ToString();
                }
                if (row["GP_Students_Rotary_real_name"] != null)
                {
                    model.GP_Students_Rotary_real_name = row["GP_Students_Rotary_real_name"].ToString();
                }
                if (row["rotary_begin_time"] != null)
                {
                    model.rotary_begin_time = row["rotary_begin_time"].ToString();
                }
                if (row["rotary_end_time"] != null)
                {
                    model.rotary_end_time = row["rotary_end_time"].ToString();
                }
                if (row["GP_Students_Rotary_training_base_code"] != null)
                {
                    model.GP_Students_Rotary_training_base_code = row["GP_Students_Rotary_training_base_code"].ToString();
                }
                if (row["GP_Students_Rotary_training_base_name"] != null)
                {
                    model.GP_Students_Rotary_training_base_name = row["GP_Students_Rotary_training_base_name"].ToString();
                }
                if (row["GP_Students_Rotary_professional_base_code"] != null)
                {
                    model.GP_Students_Rotary_professional_base_code = row["GP_Students_Rotary_professional_base_code"].ToString();
                }
                if (row["GP_Students_Rotary_professional_base_name"] != null)
                {
                    model.GP_Students_Rotary_professional_base_name = row["GP_Students_Rotary_professional_base_name"].ToString();
                }
                if (row["rotary_dept_code"] != null)
                {
                    model.rotary_dept_code = row["rotary_dept_code"].ToString();
                }
                if (row["rotary_dept_name"] != null)
                {
                    model.rotary_dept_name = row["rotary_dept_name"].ToString();
                }
                if (row["instructor"] != null)
                {
                    model.instructor = row["instructor"].ToString();
                }
                if (row["instructor_tag"] != null)
                {
                    model.instructor_tag = row["instructor_tag"].ToString();
                }
                if (row["GP_Students_Rotary_register_date"] != null)
                {
                    model.GP_Students_Rotary_register_date = row["GP_Students_Rotary_register_date"].ToString();
                }
                if (row["GP_Students_Rotary_writor"] != null)
                {
                    model.GP_Students_Rotary_writor = row["GP_Students_Rotary_writor"].ToString();
                }
                if (row["outdept_status"] != null)
                {
                    model.outdept_status = row["outdept_status"].ToString();
                }
                if (row["outdept_application"] != null)
                {
                    model.outdept_application = row["outdept_application"].ToString();
                }
                if (row["questionnaire_status"] != null)
                {
                    model.questionnaire_status = row["questionnaire_status"].ToString();
                }
                if (row["urgent"] != null)
                {
                    model.urgent = row["urgent"].ToString();
                }
                if (row["urgent_telephon"] != null)
                {
                    model.urgent_telephon = row["urgent_telephon"].ToString();
                }
                if (row["image_path"] != null)
                {
                    model.image_path = row["image_path"].ToString();
                }
                if (row["province_code"] != null)
                {
                    model.province_code = row["province_code"].ToString();
                }
                if (row["city_code"] != null)
                {
                    model.city_code = row["city_code"].ToString();
                }
                if (row["area_code"] != null)
                {
                    model.area_code = row["area_code"].ToString();
                }
            }
            return model;
        } 
        #endregion

        #region Common分页
        public List<Model.BasicRotaryViewModel> CommonGetPagedList(string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
            string DeptName,string ProfessionalBaseName ,string TeachersRealName,
            string RotaryBeginTime ,string RotaryEndTime,string  OutdeptStatus,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by GP_Students_Rotary_register_date desc) as num,* from Basic_Rotary_View where GP_Students_Rotary_training_base_code like '%" + TrainingBaseCode + "%'";

            if (!string.IsNullOrEmpty(ProfessionalBaseCode))
            {
                sql += "and professional_base_code like '%" + ProfessionalBaseCode + "%'";
            }
            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and real_name like '%" + StudentsRealName + "%'";
            }
            if (!string.IsNullOrEmpty(Sex))
            {
                sql += "and sex ='" + Sex + "'";
            }
            if (!string.IsNullOrEmpty(MinZu))
            {
                sql += "and minzu like '%" + MinZu + "%'";
            }
            if (!string.IsNullOrEmpty(HighEducation))
            {
                sql += "and high_education like '%" + HighEducation + "%'";
            }
            if (!string.IsNullOrEmpty(HighSchool))
            {
                sql += "and high_school like '%" + HighSchool + "%'";
            }
            if (!string.IsNullOrEmpty(IdentityType))
            {
                sql += "and identity_type like '%" + IdentityType + "%'";
            }
            if (!string.IsNullOrEmpty(SendUnit))
            {
                sql += "and send_unit = '" + SendUnit + "'";
            }
            if (!string.IsNullOrEmpty(CollaborativeUnit))
            {
                sql += "and collaborative_unit like '%" + CollaborativeUnit + "%'";
            }
            if (!string.IsNullOrEmpty(TrainingTime))
            {
                sql += "and training_time like '%" + TrainingTime + "%'";
            }
            if (!string.IsNullOrEmpty(PlanTrainingTime))
            {
                sql += "and plan_training_time = '" + PlanTrainingTime + "'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseName))
            {
                sql += "and GP_Students_Rotary_professional_base_name like '%" + ProfessionalBaseName + "%'";
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and rotary_dept_name like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersRealName))
            {
                sql += "and instructor like '%" + TeachersRealName + "%'";
            }
            if (!string.IsNullOrEmpty(RotaryBeginTime))
            {
                sql += "and rotary_begin_time = '" + RotaryBeginTime + "'";
            }
            if (!string.IsNullOrEmpty(RotaryEndTime))
            {
                sql += "and rotary_end_time = '" + RotaryEndTime + "'";
            }
            if (!string.IsNullOrEmpty(OutdeptStatus))
            {
                sql += "and outdept_status like '%" + OutdeptStatus + "%'";
            }
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<BasicRotaryViewModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<BasicRotaryViewModel>();
                BasicRotaryViewModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new BasicRotaryViewModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int CommonGetRecordCount(string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
            string DeptName, string ProfessionalBaseName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string OutdeptStatus)
        {
            string sql = "select count(*) from Basic_Rotary_View where GP_Students_Rotary_training_base_code like '%" + TrainingBaseCode + "%'";
            if (!string.IsNullOrEmpty(ProfessionalBaseCode))
            {
                sql += "and professional_base_code like '%" + ProfessionalBaseCode + "%'";
            }
            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and real_name like '%" + StudentsRealName + "%'";
            }
            if (!string.IsNullOrEmpty(Sex))
            {
                sql += "and sex ='" + Sex + "'";
            }
            if (!string.IsNullOrEmpty(MinZu))
            {
                sql += "and minzu like '%" + MinZu + "%'";
            }
            if (!string.IsNullOrEmpty(HighEducation))
            {
                sql += "and high_education like '%" + HighEducation + "%'";
            }
            if (!string.IsNullOrEmpty(HighSchool))
            {
                sql += "and high_school like '%" + HighSchool + "%'";
            }
            if (!string.IsNullOrEmpty(IdentityType))
            {
                sql += "and identity_type like '%" + IdentityType + "%'";
            }
            if (!string.IsNullOrEmpty(SendUnit))
            {
                sql += "and send_unit = '" + SendUnit + "'";
            }
            if (!string.IsNullOrEmpty(CollaborativeUnit))
            {
                sql += "and collaborative_unit like '%" + CollaborativeUnit + "%'";
            }
            if (!string.IsNullOrEmpty(TrainingTime))
            {
                sql += "and training_time like '%" + TrainingTime + "%'";
            }
            if (!string.IsNullOrEmpty(PlanTrainingTime))
            {
                sql += "and plan_training_time = '" + PlanTrainingTime + "'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseName))
            {
                sql += "and GP_Students_Rotary_professional_base_name like '%" + ProfessionalBaseName + "%'";
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and rotary_dept_name like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersRealName))
            {
                sql += "and instructor like '%" + TeachersRealName + "%'";
            }
            if (!string.IsNullOrEmpty(RotaryBeginTime))
            {
                sql += "and rotary_begin_time = '" + RotaryBeginTime + "'";
            }
            if (!string.IsNullOrEmpty(RotaryEndTime))
            {
                sql += "and rotary_end_time = '" + RotaryEndTime + "'";
            }
            if (!string.IsNullOrEmpty(OutdeptStatus))
            {
                sql += "and outdept_status like '%" + OutdeptStatus + "%'";
            }
            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion
    }
}
