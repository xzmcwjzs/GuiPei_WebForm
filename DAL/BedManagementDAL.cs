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
   public class BedManagementDAL
    {
       SqlHelper db = new SqlHelper();
       #region bool Add(BedManagementModel model)
       public bool Add(BedManagementModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_Bed_Management(");
           strSql.Append("id,students_name,students_real_name,training_base_code,training_base_name,professional_base_code,professional_base_name,dept_code,dept_name,patient_name,patient_id,bed_id,bed_card,bed_price,bed_status,room_id,building_id,comment,writor,register_date,teacher_check,kzr_check,base_check,manager_check,TeacherId,TeacherName)");
           strSql.Append(" values (");
           strSql.Append("@id,@students_name,@students_real_name,@training_base_code,@training_base_name,@professional_base_code,@professional_base_name,@dept_code,@dept_name,@patient_name,@patient_id,@bed_id,@bed_card,@bed_price,@bed_status,@room_id,@building_id,@comment,@writor,@register_date,@teacher_check,@kzr_check,@base_check,@manager_check,@TeacherId,@TeacherName)");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50),
					new SqlParameter("@students_name", SqlDbType.NVarChar,50),
					new SqlParameter("@students_real_name", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@dept_name", SqlDbType.NVarChar,500),
					new SqlParameter("@patient_name", SqlDbType.NVarChar,50),
					new SqlParameter("@patient_id", SqlDbType.NVarChar,50),
					new SqlParameter("@bed_id", SqlDbType.NVarChar,50),
					new SqlParameter("@bed_card", SqlDbType.NVarChar,50),
					new SqlParameter("@bed_price", SqlDbType.NVarChar,50),
					new SqlParameter("@bed_status", SqlDbType.NVarChar,50),
					new SqlParameter("@room_id", SqlDbType.NVarChar,50),
					new SqlParameter("@building_id", SqlDbType.NVarChar,50),
					new SqlParameter("@comment", SqlDbType.NVarChar,1000),
					new SqlParameter("@writor", SqlDbType.NVarChar,50),
					new SqlParameter("@register_date", SqlDbType.NVarChar,50),
					new SqlParameter("@teacher_check", SqlDbType.NVarChar,50),
					new SqlParameter("@kzr_check", SqlDbType.NVarChar,50),
					new SqlParameter("@base_check", SqlDbType.NVarChar,50),
					new SqlParameter("@manager_check", SqlDbType.NVarChar,50),
                                       new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
                                       new SqlParameter("@TeacherName", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.id;
           parameters[1].Value = model.students_name;
           parameters[2].Value = model.students_real_name;
           parameters[3].Value = model.training_base_code;
           parameters[4].Value = model.training_base_name;
           parameters[5].Value = model.professional_base_code;
           parameters[6].Value = model.professional_base_name;
           parameters[7].Value = model.dept_code;
           parameters[8].Value = model.dept_name;
           parameters[9].Value = model.patient_name;
           parameters[10].Value = model.patient_id;
           parameters[11].Value = model.bed_id;
           parameters[12].Value = model.bed_card;
           parameters[13].Value = model.bed_price;
           parameters[14].Value = model.bed_status;
           parameters[15].Value = model.room_id;
           parameters[16].Value = model.building_id;
           parameters[17].Value = model.comment;
           parameters[18].Value = model.writor;
           parameters[19].Value = model.register_date;
           parameters[20].Value = model.teacher_check;
           parameters[21].Value = model.kzr_check;
           parameters[22].Value = model.base_check;
           parameters[23].Value = model.manager_check;
           parameters[24].Value = model.TeacherId;
           parameters[25].Value = model.TeacherName;

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
       #region bool Update(BedManagementModel model, string id)
       public bool Update(BedManagementModel model, string id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_Bed_Management set ");
           strSql.Append("dept_code=@dept_code,");
           strSql.Append("dept_name=@dept_name,");
           strSql.Append("patient_name=@patient_name,");
           strSql.Append("patient_id=@patient_id,");
           strSql.Append("bed_id=@bed_id,");
           strSql.Append("bed_card=@bed_card,");
           strSql.Append("bed_price=@bed_price,");
           strSql.Append("bed_status=@bed_status,");
           strSql.Append("room_id=@room_id,");
           strSql.Append("building_id=@building_id,");
           strSql.Append("comment=@comment,");
           strSql.Append("writor=@writor,");
           strSql.Append("register_date=@register_date,");
           strSql.Append("TeacherId=@TeacherId,");
           strSql.Append("TeacherName=@TeacherName");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@dept_name", SqlDbType.NVarChar,500),
					new SqlParameter("@patient_name", SqlDbType.NVarChar,50),
					new SqlParameter("@patient_id", SqlDbType.NVarChar,50),
					new SqlParameter("@bed_id", SqlDbType.NVarChar,50),
					new SqlParameter("@bed_card", SqlDbType.NVarChar,50),
					new SqlParameter("@bed_price", SqlDbType.NVarChar,50),
					new SqlParameter("@bed_status", SqlDbType.NVarChar,50),
					new SqlParameter("@room_id", SqlDbType.NVarChar,50),
					new SqlParameter("@building_id", SqlDbType.NVarChar,50),
					new SqlParameter("@comment", SqlDbType.NVarChar,1000),
					
					new SqlParameter("@writor", SqlDbType.NVarChar,50),
					new SqlParameter("@register_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
                    new SqlParameter("@TeacherName", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.dept_code;
           parameters[1].Value = model.dept_name;
           parameters[2].Value = model.patient_name;
           parameters[3].Value = model.patient_id;
           parameters[4].Value = model.bed_id;
           parameters[5].Value = model.bed_card;
           parameters[6].Value = model.bed_price;
           parameters[7].Value = model.bed_status;
           parameters[8].Value = model.room_id;
           parameters[9].Value = model.building_id;
           parameters[10].Value = model.comment;
           parameters[11].Value = model.writor;
           parameters[12].Value = model.register_date;
           parameters[13].Value = model.TeacherId;
           parameters[14].Value = model.TeacherName;
           
           parameters[15].Value = id;

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
       #region GetModelById(string id)
       public BedManagementModel GetModelById(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select id,students_name,students_real_name,training_base_code,training_base_name,professional_base_code,professional_base_name,dept_code,dept_name,patient_name,patient_id,bed_id,bed_card,bed_price,bed_status,room_id,building_id,comment,writor,register_date,teacher_check,kzr_check,base_check,manager_check,TeacherId,TeacherName from GP_Bed_Management ");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
           parameters[0].Value = id;

           BedManagementModel model = new BedManagementModel();
           DataSet ds = db.RunDataSet(strSql.ToString(), parameters, "tbName");
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

       #region DataRowToModel(DataRow row)
       public BedManagementModel DataRowToModel(DataRow row)
       {
           BedManagementModel model = new BedManagementModel();
           if (row != null)
           {
               if (row["id"] != null)
               {
                   model.id = row["id"].ToString();
               }
               if (row["students_name"] != null)
               {
                   model.students_name = row["students_name"].ToString();
               }
               if (row["students_real_name"] != null)
               {
                   model.students_real_name = row["students_real_name"].ToString();
               }
               if (row["training_base_code"] != null)
               {
                   model.training_base_code = row["training_base_code"].ToString();
               }
               if (row["training_base_name"] != null)
               {
                   model.training_base_name = row["training_base_name"].ToString();
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
               if (row["patient_name"] != null)
               {
                   model.patient_name = row["patient_name"].ToString();
               }
               if (row["patient_id"] != null)
               {
                   model.patient_id = row["patient_id"].ToString();
               }
               if (row["bed_id"] != null)
               {
                   model.bed_id = row["bed_id"].ToString();
               }
               if (row["bed_card"] != null)
               {
                   model.bed_card = row["bed_card"].ToString();
               }
               if (row["bed_price"] != null)
               {
                   model.bed_price = row["bed_price"].ToString();
               }
               if (row["bed_status"] != null)
               {
                   model.bed_status = row["bed_status"].ToString();
               }
               if (row["room_id"] != null)
               {
                   model.room_id = row["room_id"].ToString();
               }
               if (row["building_id"] != null)
               {
                   model.building_id = row["building_id"].ToString();
               }
               if (row["comment"] != null)
               {
                   model.comment = row["comment"].ToString();
               }
               if (row["writor"] != null)
               {
                   model.writor = row["writor"].ToString();
               }
               if (row["register_date"] != null)
               {
                   model.register_date = row["register_date"].ToString();
               }
               if (row["teacher_check"] != null)
               {
                   model.teacher_check = row["teacher_check"].ToString();
               }
               if (row["kzr_check"] != null)
               {
                   model.kzr_check = row["kzr_check"].ToString();
               }
               if (row["base_check"] != null)
               {
                   model.base_check = row["base_check"].ToString();
               }
               if (row["manager_check"] != null)
               {
                   model.manager_check = row["manager_check"].ToString();
               }
               if (row["TeacherId"] != null)
               {
                   model.TeacherId = row["TeacherId"].ToString();
               }
               if (row["TeacherName"] != null)
               {
                   model.TeacherName = row["TeacherName"].ToString();
               }
           }
           return model;
       } 
       #endregion
        #region 分页
        public List<Model.BedManagementModel> GetPagedList(string students_name, string training_base_code, string dept_name,
            string patient_name,string bed_id,string bed_status,string room_id,string building_id,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by register_date desc) as num,* from GP_Bed_Management where students_name='" + students_name + "' and training_base_code='" + training_base_code + "'";

            if (!string.IsNullOrEmpty(dept_name))
            {
                sql += "and dept_name like '%" + dept_name + "%'";
            }
            if (!string.IsNullOrEmpty(patient_name))
            {
                sql += "and patient_name like '%" + patient_name + "%'";
            }
            if (!string.IsNullOrEmpty(bed_id))
            {
                sql += "and bed_id like '%" + bed_id + "%'";
            }
            if (!string.IsNullOrEmpty(bed_status))
            {
                sql += "and bed_status like '%" + bed_status + "%'";
            }
            if (!string.IsNullOrEmpty(room_id))
            {
                sql += "and room_id like '%" + room_id + "%'";
            }
            if (!string.IsNullOrEmpty(building_id))
            {
                sql += "and building_id like '%" + building_id + "%'";
            }
            sql += ")as t where t.num>=@start and t.num<=@end";
           

            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<BedManagementModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<BedManagementModel>();
                BedManagementModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new BedManagementModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int GetRecordCount(string name, string training_base_code, string dept_name, 
            string patient_name,string bed_id,string bed_status,string room_id,string building_id)
        {
            string sql = "select count(*) from GP_Bed_Management where training_base_code='" + training_base_code
                + "' and students_name='" + name + "'";
            if (!string.IsNullOrEmpty(dept_name))
            {
                sql += "and dept_name like '%" + dept_name + "%'";
            }
            if (!string.IsNullOrEmpty(patient_name))
            {
                sql += "and patient_name like '%" + patient_name + "%'";
            }
            if (!string.IsNullOrEmpty(bed_id))
            {
                sql += "and bed_id like '%" + bed_id + "%'";
            }
            if (!string.IsNullOrEmpty(bed_status))
            {
                sql += "and bed_status like '%" + bed_status + "%'";
            }
            if (!string.IsNullOrEmpty(room_id))
            {
                sql += "and room_id like '%" + room_id + "%'";
            }
            if (!string.IsNullOrEmpty(building_id))
            {
                sql += "and building_id like '%" + building_id + "%'";
            }
            return Convert.ToInt32(db.RunExecuteScalar(sql));
        } 
        #endregion

        #region Common分页
        public List<Model.BedManagementModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
            string patient_name, string bed_id, string bed_status, string room_id, string building_id,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by register_date desc) as num,* from GP_Bed_Management where training_base_code like '%" + TrainingBaseCode + "%'";

            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and students_real_name like '%" + StudentsRealName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseCode))
            {
                sql += "and professional_base_code like '%" + ProfessionalBaseCode + "%'";
            }
            if (!string.IsNullOrEmpty(DeptCode))
            {
                sql += "and dept_code like '%" + DeptCode + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersName))
            {
                sql += "and TeacherId like '%" + TeachersName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseName))
            {
                sql += "and professional_base_name like '%" + ProfessionalBaseName + "%'";
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and dept_name like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersRealName))
            {
                sql += "and TeacherName like '%" + TeachersRealName + "%'";
            }
            if (!string.IsNullOrEmpty(patient_name))
            {
                sql += "and patient_name like '%" + patient_name + "%'";
            }
            if (!string.IsNullOrEmpty(bed_id))
            {
                sql += "and bed_id like '%" + bed_id + "%'";
            }
            if (!string.IsNullOrEmpty(bed_status))
            {
                sql += "and bed_status like '%" + bed_status + "%'";
            }
            if (!string.IsNullOrEmpty(room_id))
            {
                sql += "and room_id like '%" + room_id + "%'";
            }
            if (!string.IsNullOrEmpty(building_id))
            {
                sql += "and building_id like '%" + building_id + "%'";
            }
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<BedManagementModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<BedManagementModel>();
                BedManagementModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new BedManagementModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
            string patient_name, string bed_id, string bed_status, string room_id, string building_id)
        {
            string sql = "select count(*) from GP_Bed_Management where training_base_code like '%" + TrainingBaseCode+ "%'";
            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and students_real_name like '%" + StudentsRealName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseCode))
            {
                sql += "and professional_base_code like '%" + ProfessionalBaseCode + "%'";
            }
            if (!string.IsNullOrEmpty(DeptCode))
            {
                sql += "and dept_code like '%" + DeptCode + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersName))
            {
                sql += "and TeacherId like '%" + TeachersName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseName))
            {
                sql += "and professional_base_name like '%" + ProfessionalBaseName + "%'";
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and dept_name like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersRealName))
            {
                sql += "and TeacherName like '%" + TeachersRealName + "%'";
            }
            if (!string.IsNullOrEmpty(patient_name))
            {
                sql += "and patient_name like '%" + patient_name + "%'";
            }
            if (!string.IsNullOrEmpty(bed_id))
            {
                sql += "and bed_id like '%" + bed_id + "%'";
            }
            if (!string.IsNullOrEmpty(bed_status))
            {
                sql += "and bed_status like '%" + bed_status + "%'";
            }
            if (!string.IsNullOrEmpty(room_id))
            {
                sql += "and room_id like '%" + room_id + "%'";
            }
            if (!string.IsNullOrEmpty(building_id))
            {
                sql += "and building_id like '%" + building_id + "%'";
            }
            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion
        #region UpdateCheckByTeacher(BedManagementModel model)
        public bool UpdateCheckByTeacher(BedManagementModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GP_Bed_Management set ");
            strSql.Append("teacher_check=@teacher_check");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@teacher_check", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.teacher_check;
            parameters[1].Value = model.id;

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
    }
}
