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
   public class MedicalErrorDAL
    {
       SqlHelper db=new SqlHelper();

       #region Add(MedicalErrorModel model)
       public bool Add(MedicalErrorModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_MedicalError(");
           strSql.Append("Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,TeacherId,TeacherName,Comment,ErrorCategory,ErrorDetail,ErrorDate)");
           strSql.Append(" values (");
           strSql.Append("@Id,@StudentsRealName,@StudentsName,@TrainingBaseCode,@TrainingBaseName,@ProfessionalBaseCode,@ProfessionalBaseName,@DeptCode,@DeptName,@RegisterDate,@Writor,@TeacherCheck,@KzrCheck,@BaseCheck,@ManagerCheck,@TeacherId,@TeacherName,@Comment,@ErrorCategory,@ErrorDetail,@ErrorDate)");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentsRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentsName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptCode", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,500),
					new SqlParameter("@RegisterDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Writor", SqlDbType.NVarChar,50),
					new SqlParameter("@TeacherCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@KzrCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@BaseCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@ManagerCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
					new SqlParameter("@TeacherName", SqlDbType.NVarChar,50),
					new SqlParameter("@Comment", SqlDbType.NVarChar,1000),
					new SqlParameter("@ErrorCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@ErrorDetail", SqlDbType.NVarChar,2000),
					new SqlParameter("@ErrorDate", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.Id;
           parameters[1].Value = model.StudentsRealName;
           parameters[2].Value = model.StudentsName;
           parameters[3].Value = model.TrainingBaseCode;
           parameters[4].Value = model.TrainingBaseName;
           parameters[5].Value = model.ProfessionalBaseCode;
           parameters[6].Value = model.ProfessionalBaseName;
           parameters[7].Value = model.DeptCode;
           parameters[8].Value = model.DeptName;
           parameters[9].Value = model.RegisterDate;
           parameters[10].Value = model.Writor;
           parameters[11].Value = model.TeacherCheck;
           parameters[12].Value = model.KzrCheck;
           parameters[13].Value = model.BaseCheck;
           parameters[14].Value = model.ManagerCheck;
           parameters[15].Value = model.TeacherId;
           parameters[16].Value = model.TeacherName;
           parameters[17].Value = model.Comment;
           parameters[18].Value = model.ErrorCategory;
           parameters[19].Value = model.ErrorDetail;
           parameters[20].Value = model.ErrorDate;

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

         #region Delete(string Id)
       public bool Delete(string Id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from GP_MedicalError ");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Id;

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
       #region GetListById(string Id)
       public List<MedicalErrorModel> GetListById(string Id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,TeacherId,TeacherName,Comment,ErrorCategory,ErrorDetail,ErrorDate from GP_MedicalError ");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Id;

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           List<MedicalErrorModel> list = null;
           if (dt.Rows.Count > 0)
           {
               MedicalErrorModel model = null;
               list = new List<MedicalErrorModel>();
               foreach (DataRow row in dt.Rows)
               {
                   model = new MedicalErrorModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       } 
       #endregion

       #region Update(MedicalErrorModel model)
       public bool Update(MedicalErrorModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_MedicalError set ");
           strSql.Append("StudentsRealName=@StudentsRealName,");
           strSql.Append("StudentsName=@StudentsName,");
           strSql.Append("TrainingBaseCode=@TrainingBaseCode,");
           strSql.Append("TrainingBaseName=@TrainingBaseName,");
           strSql.Append("ProfessionalBaseCode=@ProfessionalBaseCode,");
           strSql.Append("ProfessionalBaseName=@ProfessionalBaseName,");
           strSql.Append("DeptCode=@DeptCode,");
           strSql.Append("DeptName=@DeptName,");
           strSql.Append("RegisterDate=@RegisterDate,");
           strSql.Append("Writor=@Writor,");
           strSql.Append("TeacherId=@TeacherId,");
           strSql.Append("TeacherName=@TeacherName,");
           strSql.Append("Comment=@Comment,");
           strSql.Append("ErrorCategory=@ErrorCategory,");
           strSql.Append("ErrorDetail=@ErrorDetail,");
           strSql.Append("ErrorDate=@ErrorDate");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@StudentsRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentsName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptCode", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,500),
					new SqlParameter("@RegisterDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Writor", SqlDbType.NVarChar,50),
					new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
					new SqlParameter("@TeacherName", SqlDbType.NVarChar,50),
					new SqlParameter("@Comment", SqlDbType.NVarChar,1000),
					new SqlParameter("@ErrorCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@ErrorDetail", SqlDbType.NVarChar,2000),
					new SqlParameter("@ErrorDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.StudentsRealName;
           parameters[1].Value = model.StudentsName;
           parameters[2].Value = model.TrainingBaseCode;
           parameters[3].Value = model.TrainingBaseName;
           parameters[4].Value = model.ProfessionalBaseCode;
           parameters[5].Value = model.ProfessionalBaseName;
           parameters[6].Value = model.DeptCode;
           parameters[7].Value = model.DeptName;
           parameters[8].Value = model.RegisterDate;
           parameters[9].Value = model.Writor;
           parameters[10].Value = model.TeacherId;
           parameters[11].Value = model.TeacherName;
           parameters[12].Value = model.Comment;
           parameters[13].Value = model.ErrorCategory;
           parameters[14].Value = model.ErrorDetail;
           parameters[15].Value = model.ErrorDate;
           parameters[16].Value = model.Id;

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

       #region DataRowToModel(DataRow row)
       public MedicalErrorModel DataRowToModel(DataRow row)
       {
           MedicalErrorModel model = new MedicalErrorModel();
           if (row != null)
           {
               if (row["Id"] != null)
               {
                   model.Id = row["Id"].ToString();
               }
               if (row["StudentsRealName"] != null)
               {
                   model.StudentsRealName = row["StudentsRealName"].ToString();
               }
               if (row["StudentsName"] != null)
               {
                   model.StudentsName = row["StudentsName"].ToString();
               }
               if (row["TrainingBaseCode"] != null)
               {
                   model.TrainingBaseCode = row["TrainingBaseCode"].ToString();
               }
               if (row["TrainingBaseName"] != null)
               {
                   model.TrainingBaseName = row["TrainingBaseName"].ToString();
               }
               if (row["ProfessionalBaseCode"] != null)
               {
                   model.ProfessionalBaseCode = row["ProfessionalBaseCode"].ToString();
               }
               if (row["ProfessionalBaseName"] != null)
               {
                   model.ProfessionalBaseName = row["ProfessionalBaseName"].ToString();
               }
               if (row["DeptCode"] != null)
               {
                   model.DeptCode = row["DeptCode"].ToString();
               }
               if (row["DeptName"] != null)
               {
                   model.DeptName = row["DeptName"].ToString();
               }
               if (row["RegisterDate"] != null)
               {
                   model.RegisterDate = row["RegisterDate"].ToString();
               }
               if (row["Writor"] != null)
               {
                   model.Writor = row["Writor"].ToString();
               }
               if (row["TeacherCheck"] != null)
               {
                   model.TeacherCheck = row["TeacherCheck"].ToString();
               }
               if (row["KzrCheck"] != null)
               {
                   model.KzrCheck = row["KzrCheck"].ToString();
               }
               if (row["BaseCheck"] != null)
               {
                   model.BaseCheck = row["BaseCheck"].ToString();
               }
               if (row["ManagerCheck"] != null)
               {
                   model.ManagerCheck = row["ManagerCheck"].ToString();
               }
               if (row["TeacherId"] != null)
               {
                   model.TeacherId = row["TeacherId"].ToString();
               }
               if (row["TeacherName"] != null)
               {
                   model.TeacherName = row["TeacherName"].ToString();
               }
               if (row["Comment"] != null)
               {
                   model.Comment = row["Comment"].ToString();
               }
               if (row["ErrorCategory"] != null)
               {
                   model.ErrorCategory = row["ErrorCategory"].ToString();
               }
               if (row["ErrorDetail"] != null)
               {
                   model.ErrorDetail = row["ErrorDetail"].ToString();
               }
               if (row["ErrorDate"] != null)
               {
                   model.ErrorDate = row["ErrorDate"].ToString();
               }
           }
           return model;
       } 
       #endregion
        #region 分页
        public List<Model.MedicalErrorModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
            string ErrorCategory, string ErrorDate,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_MedicalError where StudentsName='" + StudentsName + "' and TrainingBaseCode='" + TrainingBaseCode + "'";

            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(ErrorCategory))
            {
                sql += "and ErrorCategory ='" + ErrorCategory + "'";
            }
            if (!string.IsNullOrEmpty(ErrorDate))
            {
                sql += "and ErrorDate like '%" + ErrorDate + "%'";
            }
            
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<MedicalErrorModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<MedicalErrorModel>();
                MedicalErrorModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new MedicalErrorModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string ErrorCategory, string ErrorDate)
        {
            string sql = "select count(*) from GP_MedicalError where TrainingBaseCode='" + TrainingBaseCode
                + "' and StudentsName='" + StudentsName + "'";
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(ErrorCategory))
            {
                sql += "and ErrorCategory ='" + ErrorCategory + "'";
            }
            if (!string.IsNullOrEmpty(ErrorDate))
            {
                sql += "and ErrorDate like '%" + ErrorDate + "%'";
            }

            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion

        #region Common分页
        public List<Model.MedicalErrorModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ErrorCategory, string ErrorDate,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_MedicalError where TrainingBaseCode like '%" + TrainingBaseCode + "%'";

            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and StudentsRealName like '%" + StudentsRealName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseCode))
            {
                sql += "and ProfessionalBaseCode like '%" + ProfessionalBaseCode + "%'";
            }
            if (!string.IsNullOrEmpty(DeptCode))
            {
                sql += "and DeptCode like '%" + DeptCode + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersName))
            {
                sql += "and TeacherId like '%" + TeachersName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseName))
            {
                sql += "and ProfessionalBaseName like '%" + ProfessionalBaseName + "%'";
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersRealName))
            {
                sql += "and TeacherName like '%" + TeachersRealName + "%'";
            }
            if (!string.IsNullOrEmpty(ErrorCategory))
            {
                sql += "and ErrorCategory ='" + ErrorCategory + "'";
            }
            if (!string.IsNullOrEmpty(ErrorDate))
            {
                sql += "and ErrorDate like '%" + ErrorDate + "%'";
            }

            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<MedicalErrorModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<MedicalErrorModel>();
                MedicalErrorModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new MedicalErrorModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ErrorCategory, string ErrorDate)
        {
            string sql = "select count(*) from GP_MedicalError where TrainingBaseCode like '%" + TrainingBaseCode + "%'";
            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and StudentsRealName like '%" + StudentsRealName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseCode))
            {
                sql += "and ProfessionalBaseCode like '%" + ProfessionalBaseCode + "%'";
            }
            if (!string.IsNullOrEmpty(DeptCode))
            {
                sql += "and DeptCode like '%" + DeptCode + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersName))
            {
                sql += "and TeacherId like '%" + TeachersName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseName))
            {
                sql += "and ProfessionalBaseName like '%" + ProfessionalBaseName + "%'";
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersRealName))
            {
                sql += "and TeacherName like '%" + TeachersRealName + "%'";
            }
            if (!string.IsNullOrEmpty(ErrorCategory))
            {
                sql += "and ErrorCategory ='" + ErrorCategory + "'";
            }
            if (!string.IsNullOrEmpty(ErrorDate))
            {
                sql += "and ErrorDate like '%" + ErrorDate + "%'";
            }

            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion

        #region UpdateCheckByTeacher(MedicalErrorModel model)
        public bool UpdateCheckByTeacher(MedicalErrorModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GP_MedicalError set ");
            strSql.Append("TeacherCheck=@TeacherCheck");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@TeacherCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.TeacherCheck;
            parameters[1].Value = model.Id;

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
