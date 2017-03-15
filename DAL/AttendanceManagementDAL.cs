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
   public  class AttendanceManagementDAL
    {
       SqlHelper db = new SqlHelper();
       #region Add(AttendanceManagementModel model)
       public bool Add(AttendanceManagementModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_AttendanceManagement(");
           strSql.Append("Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,TeacherId,TeacherName,Comment,AttendanceCategory,FirstDate,LastDate,Days,Details)");
           strSql.Append(" values (");
           strSql.Append("@Id,@StudentsRealName,@StudentsName,@TrainingBaseCode,@TrainingBaseName,@ProfessionalBaseCode,@ProfessionalBaseName,@DeptCode,@DeptName,@RegisterDate,@Writor,@TeacherCheck,@KzrCheck,@BaseCheck,@ManagerCheck,@TeacherId,@TeacherName,@Comment,@AttendanceCategory,@FirstDate,@LastDate,@Days,@Details)");
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
					new SqlParameter("@AttendanceCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@FirstDate", SqlDbType.NVarChar,50),
					new SqlParameter("@LastDate", SqlDbType.NVarChar,2000),
					new SqlParameter("@Days", SqlDbType.NVarChar,50),
					new SqlParameter("@Details", SqlDbType.NVarChar,2000)};
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
           parameters[18].Value = model.AttendanceCategory;
           parameters[19].Value = model.FirstDate;
           parameters[20].Value = model.LastDate;
           parameters[21].Value = model.Days;
           parameters[22].Value = model.Details;

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
       public List<AttendanceManagementModel> GetListById(string Id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,TeacherId,TeacherName,Comment,AttendanceCategory,FirstDate,LastDate,Days,Details from GP_AttendanceManagement ");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Id;

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           List<AttendanceManagementModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<AttendanceManagementModel>();
               AttendanceManagementModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new AttendanceManagementModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;


       } 
       #endregion
       #region Update(AttendanceManagementModel model)
       public bool Update(AttendanceManagementModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_AttendanceManagement set ");
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
           strSql.Append("AttendanceCategory=@AttendanceCategory,");
           strSql.Append("FirstDate=@FirstDate,");
           strSql.Append("LastDate=@LastDate,");
           strSql.Append("Days=@Days,");
           strSql.Append("Details=@Details");
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
					new SqlParameter("@AttendanceCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@FirstDate", SqlDbType.NVarChar,50),
					new SqlParameter("@LastDate", SqlDbType.NVarChar,2000),
					new SqlParameter("@Days", SqlDbType.NVarChar,50),
					new SqlParameter("@Details", SqlDbType.NVarChar,2000),
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
           parameters[13].Value = model.AttendanceCategory;
           parameters[14].Value = model.FirstDate;
           parameters[15].Value = model.LastDate;
           parameters[16].Value = model.Days;
           parameters[17].Value = model.Details;
           parameters[18].Value = model.Id;

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
       public AttendanceManagementModel DataRowToModel(DataRow row)
       {
           AttendanceManagementModel model = new AttendanceManagementModel();
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
               if (row["AttendanceCategory"] != null)
               {
                   model.AttendanceCategory = row["AttendanceCategory"].ToString();
               }
               if (row["FirstDate"] != null)
               {
                   model.FirstDate = row["FirstDate"].ToString();
               }
               if (row["LastDate"] != null)
               {
                   model.LastDate = row["LastDate"].ToString();
               }
               if (row["Days"] != null)
               {
                   model.Days = row["Days"].ToString();
               }
               if (row["Details"] != null)
               {
                   model.Details = row["Details"].ToString();
               }
           }
           return model;
       }
       #endregion
       #region 分页
       public List<Model.AttendanceManagementModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
           string AttendanceCategory, string FirstDate, string LastDate,string Days,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_AttendanceManagement where StudentsName='" + StudentsName + "' and TrainingBaseCode='" + TrainingBaseCode + "'";

           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and DeptName like '%" + DeptName + "%'";
           }
           if (!string.IsNullOrEmpty(AttendanceCategory))
           {
               sql += "and AttendanceCategory = '" + AttendanceCategory + "'";
           }
           if (!string.IsNullOrEmpty(FirstDate))
           {
               sql += "and FirstDate like '%" + FirstDate + "%'";
           }
           if (!string.IsNullOrEmpty(LastDate))
           {
               sql += "and LastDate like '%" + LastDate + "%'";
           }
           if (!string.IsNullOrEmpty(Days))
           {
               sql += "and Days = '" + Days + "'";
           }
           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<AttendanceManagementModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<AttendanceManagementModel>();
               AttendanceManagementModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new AttendanceManagementModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
          string AttendanceCategory, string FirstDate, string LastDate, string Days)
       {
           string sql = "select count(*) from GP_AttendanceManagement where TrainingBaseCode='" + TrainingBaseCode
               + "' and StudentsName='" + StudentsName + "'";
           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and DeptName like '%" + DeptName + "%'";
           }
           if (!string.IsNullOrEmpty(AttendanceCategory))
           {
               sql += "and AttendanceCategory = '" + AttendanceCategory + "'";
           }
           if (!string.IsNullOrEmpty(FirstDate))
           {
               sql += "and FirstDate like '%" + FirstDate + "%'";
           }
           if (!string.IsNullOrEmpty(LastDate))
           {
               sql += "and LastDate like '%" + LastDate + "%'";
           }
           if (!string.IsNullOrEmpty(Days))
           {
               sql += "and Days = '" + Days + "'";
           }

           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion


       #region Common分页
       public List<Model.AttendanceManagementModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
           string AttendanceCategory, string FirstDate, string LastDate, string Days,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_AttendanceManagement where TrainingBaseCode like '%" + TrainingBaseCode + "%'";

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
           if (!string.IsNullOrEmpty(AttendanceCategory))
           {
               sql += "and AttendanceCategory = '" + AttendanceCategory + "'";
           }
           if (!string.IsNullOrEmpty(FirstDate))
           {
               sql += "and FirstDate like '%" + FirstDate + "%'";
           }
           if (!string.IsNullOrEmpty(LastDate))
           {
               sql += "and LastDate like '%" + LastDate + "%'";
           }
           if (!string.IsNullOrEmpty(Days))
           {
               sql += "and Days = '" + Days + "'";
           }
           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<AttendanceManagementModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<AttendanceManagementModel>();
               AttendanceManagementModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new AttendanceManagementModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string AttendanceCategory, string FirstDate, string LastDate, string Days)
       {
           string sql = "select count(*) from GP_AttendanceManagement where TrainingBaseCode like '%" + TrainingBaseCode+"%'";
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
           if (!string.IsNullOrEmpty(AttendanceCategory))
           {
               sql += "and AttendanceCategory = '" + AttendanceCategory + "'";
           }
           if (!string.IsNullOrEmpty(FirstDate))
           {
               sql += "and FirstDate like '%" + FirstDate + "%'";
           }
           if (!string.IsNullOrEmpty(LastDate))
           {
               sql += "and LastDate like '%" + LastDate + "%'";
           }
           if (!string.IsNullOrEmpty(Days))
           {
               sql += "and Days = '" + Days + "'";
           }

           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region UpdateCheckByTeacher(AttendanceManagementModel model)
       public bool UpdateCheckByTeacher(AttendanceManagementModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_AttendanceManagement set ");
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
