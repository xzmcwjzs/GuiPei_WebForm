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
    public class StudentsPersonalInformationDAL
    {
        SqlHelper db = new SqlHelper();
        #region  DataTable GetDataTable(StudentsModel studentsModel)
        public DataTable GetDataTable(StudentsModel studentsModel)
        {
            string name = studentsModel.students_name.ToString().Trim();
            string sql = string.Format("select * from GP_Students_Personal_Information where name=@name");
            SqlParameter[] prams = { db.MakeInParam("@name", SqlDbType.NVarChar, 50, name) };

            DataTable dt = db.RunDataTable(sql, prams);
            return dt;
        }
        #endregion

        #region  InsertStudentsPersonalInformation(StudentsPersonalInformationModel studentspersonalinformationModel)
        public int InsertStudentsPersonalInformation(StudentsPersonalInformationModel studentspersonalinformationModel)
        {
            int count = 0;
            string sql = string.Format("insert into GP_Students_Personal_Information (id,name,real_name,sex,age,datebirth,"
                + "minzu,province,city,area,detail_address,id_number,telephon,mail,bk_school,bk_major,graduation_time,"
                + "high_education,high_school,high_major,high_education_time,identity_type,send_unit,training_base_province_code,"
            + "training_base_province_name,training_base_code,training_base_name,collaborative_unit,"
                + "professional_base_code,professional_base_name,training_time,plan_training_time,writor,register_date,urgent,urgent_telephon,image_path,province_code,city_code,area_code) values(@id,@name,@real_name,@sex,@age,@datebirth,"
                + "@minzu,@province,@city,@area,@detail_address,@id_number,@telephon,@mail,@bk_school,@bk_major,@graduation_time,"
                + "@high_education,@high_school,@high_major,@high_education_time,@identity_type,@send_unit,@training_base_province_code,"
            + "@training_base_province_name,@training_base_code,@training_base_name,@collaborative_unit,"
                + "@professional_base_code,@professional_base_name,@training_time,@plan_training_time,@writor,@register_date,@urgent,@urgent_telephon,@image_path,@province_code,@city_code,@area_code)");
            SqlParameter[] prams ={db.MakeInParam("@id",SqlDbType.NVarChar,50,studentspersonalinformationModel.id),
                                 db.MakeInParam("@name",SqlDbType.NVarChar,50,studentspersonalinformationModel.name),
                                 db.MakeInParam("@real_name",SqlDbType.NVarChar,50,studentspersonalinformationModel.real_name),
                                 db.MakeInParam("@sex",SqlDbType.NVarChar,50,studentspersonalinformationModel.sex),
                                 db.MakeInParam("@age",SqlDbType.NVarChar,50,studentspersonalinformationModel.age),
                                 db.MakeInParam("@datebirth",SqlDbType.NVarChar,50,studentspersonalinformationModel.datebirth),
                                 db.MakeInParam("@minzu",SqlDbType.NVarChar,50,studentspersonalinformationModel.minzu),
                                 db.MakeInParam("@province",SqlDbType.NVarChar,50,studentspersonalinformationModel.province),
                                 db.MakeInParam("@city",SqlDbType.NVarChar,50,studentspersonalinformationModel.city),
                                 db.MakeInParam("@area",SqlDbType.NVarChar,50,studentspersonalinformationModel.area),
                                 db.MakeInParam("@detail_address",SqlDbType.NVarChar,500,studentspersonalinformationModel.detail_address),
                                 db.MakeInParam("@id_number",SqlDbType.NVarChar,50,studentspersonalinformationModel.id_number),
                                 db.MakeInParam("@telephon",SqlDbType.NVarChar,50,studentspersonalinformationModel.telephon),
                                 db.MakeInParam("@mail",SqlDbType.NVarChar,50,studentspersonalinformationModel.mail),
                                 db.MakeInParam("@bk_school",SqlDbType.NVarChar,50,studentspersonalinformationModel.bk_school),
                                 db.MakeInParam("@bk_major",SqlDbType.NVarChar,50,studentspersonalinformationModel.bk_major),
                                 db.MakeInParam("@graduation_time",SqlDbType.NVarChar,50,studentspersonalinformationModel.graduation_time),
                                 db.MakeInParam("@high_education",SqlDbType.NVarChar,50,studentspersonalinformationModel.high_education),
                                 db.MakeInParam("@high_school",SqlDbType.NVarChar,50,studentspersonalinformationModel.high_school),
                                 db.MakeInParam("@high_major",SqlDbType.NVarChar,50,studentspersonalinformationModel.high_major),
                                 db.MakeInParam("@high_education_time",SqlDbType.NVarChar,50,studentspersonalinformationModel.high_education_time),
                                 db.MakeInParam("@identity_type",SqlDbType.NVarChar,50,studentspersonalinformationModel.identity_type),
                                 db.MakeInParam("@send_unit",SqlDbType.NVarChar,50,studentspersonalinformationModel.send_unit),
                                 db.MakeInParam("@training_base_province_code",SqlDbType.NVarChar,50,studentspersonalinformationModel.training_base_province_code),
                                 db.MakeInParam("@training_base_province_name",SqlDbType.NVarChar,50,studentspersonalinformationModel.training_base_province_name),
                                 db.MakeInParam("@training_base_code",SqlDbType.NVarChar,50,studentspersonalinformationModel.training_base_code),
                                 db.MakeInParam("@training_base_name",SqlDbType.NVarChar,50,studentspersonalinformationModel.training_base_name),
                                 db.MakeInParam("@collaborative_unit",SqlDbType.NVarChar,50,studentspersonalinformationModel.collaborative_unit),
                                 db.MakeInParam("@professional_base_code",SqlDbType.NVarChar,50,studentspersonalinformationModel.professional_base_code),
                                  db.MakeInParam("@professional_base_name",SqlDbType.NVarChar,50,studentspersonalinformationModel.professional_base_name),
                                 db.MakeInParam("@training_time",SqlDbType.NVarChar,50,studentspersonalinformationModel.training_time),
                                  db.MakeInParam("@plan_training_time",SqlDbType.NVarChar,50,studentspersonalinformationModel.plan_training_time),
                                  db.MakeInParam("@writor",SqlDbType.NVarChar,50,studentspersonalinformationModel.writor),
                                  db.MakeInParam("@register_date",SqlDbType.NVarChar,50,studentspersonalinformationModel.register_date),
                                  db.MakeInParam("@urgent",SqlDbType.NVarChar,50,studentspersonalinformationModel.urgent),
                                  db.MakeInParam("@urgent_telephon",SqlDbType.NVarChar,50,studentspersonalinformationModel.urgent_telephon),
                                  db.MakeInParam("@image_path",SqlDbType.NVarChar,50,studentspersonalinformationModel.image_path),
                                  db.MakeInParam("@province_code",SqlDbType.NVarChar,50,studentspersonalinformationModel.province_code),
                                  db.MakeInParam("@city_code",SqlDbType.NVarChar,50,studentspersonalinformationModel.city_code),
                                  db.MakeInParam("@area_code",SqlDbType.NVarChar,50,studentspersonalinformationModel.area_code)};
            count = db.RunExecuteNonQuery(sql, prams);
            return count;
        }
        #endregion

        #region GetDataTableByIdNumber(string id_number)
        public DataSet GetDataTableByIdNumber(string id_number)
        {
            string sql = string.Format("select * from GP_Students_Personal_Information where id_number=@id_number");
            SqlParameter[] prams = { db.MakeInParam("@id_number", SqlDbType.NVarChar, 50, id_number) };
            string table = "tb";
            DataSet ds = db.RunDataSet(sql, prams, table);
            return ds;
        }
        #endregion

        #region GetPagedList(string students_name, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        /// <summary>
        /// 获得分页数据并输出总行数和总页数
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public List<Model.StudentsPersonalInformationModel> GetPagedList(string students_name, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {

            List<Model.StudentsPersonalInformationModel> list = null;
            DataTable dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,sex,age,datebirth,"
                + "minzu,province,city,area,detail_address,id_number,telephon,mail,bk_school,bk_major,graduation_time,"
                + "high_education,high_school,high_major,high_education_time,identity_type,send_unit,training_base_province_code,"
            + "training_base_province_name,training_base_code,training_base_name,collaborative_unit,"
                + "professional_base_code,professional_base_name,training_time,plan_training_time,writor,register_date", "GP_Students_Personal_Information", "name='" + students_name
                + "'", "name", "id", pageIndex, pageSize, out rowCount, out pageCount);

            //将数据表转为泛型集合
            if (dt.Rows.Count > 0)
            {
                list = new List<StudentsPersonalInformationModel>();
                Model.StudentsPersonalInformationModel model = null;//声明实体对象
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Model.StudentsPersonalInformationModel();
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
        #endregion

        #region  GetModelById(string id)
        public Model.StudentsPersonalInformationModel GetModelById(string id)
        {

            string sql = string.Format("select * from GP_Students_Personal_Information where id=@id");
            SqlParameter[] prams = { db.MakeInParam("@id", SqlDbType.NVarChar, 50, id) };
            DataTable dt = db.RunDataTable(sql, prams);
            StudentsPersonalInformationModel studentsPersonalInformationModel = new StudentsPersonalInformationModel();
            studentsPersonalInformationModel = (StudentsPersonalInformationModel)ConvertTo.convertToModel(dt, studentsPersonalInformationModel);

            return studentsPersonalInformationModel;
        }
        #endregion

        #region  UpdateStudentsPersonalInformation(StudentsPersonalInformationModel model)
        public bool UpdateStudentsPersonalInformation(StudentsPersonalInformationModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GP_Students_Personal_Information set ");
            strSql.Append("real_name=@real_name,");
            strSql.Append("sex=@sex,");
            strSql.Append("age=@age,");
            strSql.Append("datebirth=@datebirth,");
            strSql.Append("minzu=@minzu,");
            strSql.Append("province=@province,");
            strSql.Append("city=@city,");
            strSql.Append("area=@area,");
            strSql.Append("detail_address=@detail_address,");
            strSql.Append("id_number=@id_number,");
            strSql.Append("telephon=@telephon,");
            strSql.Append("mail=@mail,");
            strSql.Append("bk_school=@bk_school,");
            strSql.Append("bk_major=@bk_major,");
            strSql.Append("graduation_time=@graduation_time,");
            strSql.Append("high_education=@high_education,");
            strSql.Append("high_school=@high_school,");
            strSql.Append("high_major=@high_major,");
            strSql.Append("high_education_time=@high_education_time,");
            strSql.Append("identity_type=@identity_type,");
            strSql.Append("send_unit=@send_unit,");
            strSql.Append("training_base_province_code=@training_base_province_code,");
            strSql.Append("training_base_province_name=@training_base_province_name,");
            strSql.Append("training_base_code=@training_base_code,");
            strSql.Append("training_base_name=@training_base_name,");
            strSql.Append("collaborative_unit=@collaborative_unit,");
            strSql.Append("professional_base_code=@professional_base_code,");
            strSql.Append("professional_base_name=@professional_base_name,");
            strSql.Append("training_time=@training_time,");
            strSql.Append("plan_training_time=@plan_training_time,");
            strSql.Append("writor=@writor,");
            strSql.Append("register_date=@register_date,");
            strSql.Append("urgent=@urgent,");
            strSql.Append("urgent_telephon=@urgent_telephon,");
            strSql.Append("image_path=@image_path,");
            strSql.Append("province_code=@province_code,");
            strSql.Append("city_code=@city_code,");
            strSql.Append("area_code=@area_code");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@real_name", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.NVarChar,50),
					new SqlParameter("@age", SqlDbType.NVarChar,50),
					new SqlParameter("@datebirth", SqlDbType.NVarChar,50),
					new SqlParameter("@minzu", SqlDbType.NVarChar,50),
					new SqlParameter("@province", SqlDbType.NVarChar,50),
					new SqlParameter("@city", SqlDbType.NVarChar,50),
					new SqlParameter("@area", SqlDbType.NVarChar,50),
					new SqlParameter("@detail_address", SqlDbType.NVarChar,500),
					new SqlParameter("@id_number", SqlDbType.NVarChar,50),
					new SqlParameter("@telephon", SqlDbType.NVarChar,50),
					new SqlParameter("@mail", SqlDbType.NVarChar,50),
					new SqlParameter("@bk_school", SqlDbType.NVarChar,50),
					new SqlParameter("@bk_major", SqlDbType.NVarChar,50),
					new SqlParameter("@graduation_time", SqlDbType.NVarChar,50),
					new SqlParameter("@high_education", SqlDbType.NVarChar,50),
					new SqlParameter("@high_school", SqlDbType.NVarChar,50),
					new SqlParameter("@high_major", SqlDbType.NVarChar,50),
					new SqlParameter("@high_education_time", SqlDbType.NVarChar,50),
					new SqlParameter("@identity_type", SqlDbType.NVarChar,50),
					new SqlParameter("@send_unit", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_province_code", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_province_name", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@collaborative_unit", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@training_time", SqlDbType.NVarChar,50),
					new SqlParameter("@plan_training_time", SqlDbType.NVarChar,50),
					new SqlParameter("@writor", SqlDbType.NVarChar,50),
					new SqlParameter("@register_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@urgent", SqlDbType.NVarChar,50),
                    new SqlParameter("@urgent_telephon", SqlDbType.NVarChar,50),
                    new SqlParameter("@image_path", SqlDbType.NVarChar,50),
                    new SqlParameter("@province_code", SqlDbType.NVarChar,50),
                    new SqlParameter("@city_code", SqlDbType.NVarChar,50),
                    new SqlParameter("@area_code", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.real_name;
            parameters[1].Value = model.sex;
            parameters[2].Value = model.age;
            parameters[3].Value = model.datebirth;
            parameters[4].Value = model.minzu;
            parameters[5].Value = model.province;
            parameters[6].Value = model.city;
            parameters[7].Value = model.area;
            parameters[8].Value = model.detail_address;
            parameters[9].Value = model.id_number;
            parameters[10].Value = model.telephon;
            parameters[11].Value = model.mail;
            parameters[12].Value = model.bk_school;
            parameters[13].Value = model.bk_major;
            parameters[14].Value = model.graduation_time;
            parameters[15].Value = model.high_education;
            parameters[16].Value = model.high_school;
            parameters[17].Value = model.high_major;
            parameters[18].Value = model.high_education_time;
            parameters[19].Value = model.identity_type;
            parameters[20].Value = model.send_unit;
            parameters[21].Value = model.training_base_province_code;
            parameters[22].Value = model.training_base_province_name;
            parameters[23].Value = model.training_base_code;
            parameters[24].Value = model.training_base_name;
            parameters[25].Value = model.collaborative_unit;
            parameters[26].Value = model.professional_base_code;
            parameters[27].Value = model.professional_base_name;
            parameters[28].Value = model.training_time;
            parameters[29].Value = model.plan_training_time;
            parameters[30].Value = model.writor;
            parameters[31].Value = model.register_date;
            parameters[32].Value = model.urgent;
            parameters[33].Value = model.urgent_telephon;
            parameters[34].Value = model.image_path;
            parameters[35].Value = model.province_code;
            parameters[36].Value = model.city_code;
            parameters[37].Value = model.area_code;
            parameters[38].Value = model.id;
            int rows = db.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region GetModelByNameTBCode(string name, string training_base_code)
        public Model.StudentsPersonalInformationModel GetModelByNameTBCode(string name, string training_base_code) {
            string sql = string.Format("select * from GP_Students_Personal_Information where name=@name and training_base_code=@training_base_code");
            SqlParameter[] prams = { db.MakeInParam("@name", SqlDbType.NVarChar, 50, name),
                                    db.MakeInParam("@training_base_code", SqlDbType.NVarChar, 50, training_base_code)
                                   };
            DataTable dt = db.RunDataTable(sql, prams);
            StudentsPersonalInformationModel studentsPersonalInformationModel = new StudentsPersonalInformationModel();
            studentsPersonalInformationModel = (StudentsPersonalInformationModel)ConvertTo.convertToModel(dt, studentsPersonalInformationModel);

            return studentsPersonalInformationModel;
        }
        #endregion

        #region Common分页
        public List<Model.StudentsPersonalInformationModel> CommonGetPagedList(string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime,string PlanTrainingTime,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by register_date desc) as num,* from GP_Students_Personal_Information where training_base_code like '%" + TrainingBaseCode + "%'";

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
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<StudentsPersonalInformationModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<StudentsPersonalInformationModel>();
                StudentsPersonalInformationModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new StudentsPersonalInformationModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int CommonGetRecordCount(string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime)
        {
            string sql = "select count(*) from GP_Students_Personal_Information where training_base_code like '%" + TrainingBaseCode + "%'";
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

            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion


        #region DataRowToModel(DataRow row)
        public StudentsPersonalInformationModel DataRowToModel(DataRow row)
        {
            StudentsPersonalInformationModel model = new StudentsPersonalInformationModel();
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


        #region GetDtByTPT(string training_base_code, string professional_base_code, string training_time)
        public DataTable GetDtByTPT(string training_base_code, string professional_base_code, string training_time)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name,RealName from GP_StudentsPersonalInformation2 ");
            strSql.Append(" where TrainingBaseCode=@TrainingBaseCode and ProfessionalBaseCode=@ProfessionalBaseCode and TrainingTime like @TrainingTime ");
            SqlParameter[] parameters = {
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingTime", SqlDbType.NVarChar,50)			};
            parameters[0].Value = training_base_code;
            parameters[1].Value = professional_base_code;
            parameters[2].Value = training_time+"%";

            DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        } 
        #endregion


    }

}