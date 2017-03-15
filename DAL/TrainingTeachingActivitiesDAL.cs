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
   public class TrainingTeachingActivitiesDAL
    {
       SqlHelper db = new SqlHelper();
       #region Add(TrainingTeachingActivitiesModel model)
       public bool Add(TrainingTeachingActivitiesModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_TrainingTeachingActivities(");
           strSql.Append("Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,ActivityForm,ActivityContent,MainSpeaker,ClassHour,ActivityDate,Comment,ActivityFormId,TeacherId,TeacherName)");
           strSql.Append(" values (");
           strSql.Append("@Id,@StudentsRealName,@StudentsName,@TrainingBaseCode,@TrainingBaseName,@ProfessionalBaseCode,@ProfessionalBaseName,@DeptCode,@DeptName,@RegisterDate,@Writor,@TeacherCheck,@KzrCheck,@BaseCheck,@ManagerCheck,@ActivityForm,@ActivityContent,@MainSpeaker,@ClassHour,@ActivityDate,@Comment,@ActivityFormId,@TeacherId,@TeacherName)");
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
					new SqlParameter("@ActivityForm", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityContent", SqlDbType.NVarChar,2000),
					new SqlParameter("@MainSpeaker", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassHour", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Comment", SqlDbType.NVarChar,1000),
                    new SqlParameter("@ActivityFormId",SqlDbType.NVarChar,50),
                                       new SqlParameter("@TeacherId",SqlDbType.NVarChar,50),
                                       new SqlParameter("@TeacherName",SqlDbType.NVarChar,50)};
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
           parameters[15].Value = model.ActivityForm;
           parameters[16].Value = model.ActivityContent;
           parameters[17].Value = model.MainSpeaker;
           parameters[18].Value = model.ClassHour;
           parameters[19].Value = model.ActivityDate;
           parameters[20].Value = model.Comment;
           parameters[21].Value = model.ActivityFormId;
           parameters[22].Value = model.TeacherId;
           parameters[23].Value = model.TeacherName;

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
       #region GetModelById(string Id)
       public TrainingTeachingActivitiesModel GetModelById(string Id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,ActivityForm,ActivityContent,MainSpeaker,ClassHour,ActivityDate,Comment,ActivityFormId,TeacherId,TeacherName from GP_TrainingTeachingActivities ");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = Id;

           TrainingTeachingActivitiesModel model = new TrainingTeachingActivitiesModel();
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
       public TrainingTeachingActivitiesModel DataRowToModel(DataRow row)
       {
           TrainingTeachingActivitiesModel model = new TrainingTeachingActivitiesModel();
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
               if (row["ActivityForm"] != null)
               {
                   model.ActivityForm = row["ActivityForm"].ToString();
               }
               if (row["ActivityContent"] != null)
               {
                   model.ActivityContent = row["ActivityContent"].ToString();
               }
               if (row["MainSpeaker"] != null)
               {
                   model.MainSpeaker = row["MainSpeaker"].ToString();
               }
               if (row["ClassHour"] != null)
               {
                   model.ClassHour = row["ClassHour"].ToString();
               }
               if (row["ActivityDate"] != null)
               {
                   model.ActivityDate = row["ActivityDate"].ToString();
               }
               if (row["Comment"] != null)
               {
                   model.Comment = row["Comment"].ToString();
               }
               if (row["ActivityFormId"] != null)
               {
                   model.ActivityFormId = row["ActivityFormId"].ToString();
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
       #region Update(TrainingTeachingActivitiesModel model)
       public bool Update(TrainingTeachingActivitiesModel model,string id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_TrainingTeachingActivities set ");
           strSql.Append("DeptCode=@DeptCode,");
           strSql.Append("DeptName=@DeptName,");
           strSql.Append("RegisterDate=@RegisterDate,");
           strSql.Append("Writor=@Writor,");
           
           strSql.Append("ActivityFormId=@ActivityFormId,");
           strSql.Append("ActivityForm=@ActivityForm,");
           strSql.Append("ActivityContent=@ActivityContent,");
           strSql.Append("MainSpeaker=@MainSpeaker,");
           strSql.Append("ClassHour=@ClassHour,");
           strSql.Append("ActivityDate=@ActivityDate,");
           strSql.Append("Comment=@Comment,");
           strSql.Append("TeacherId=@TeacherId,");
           strSql.Append("TeacherName=@TeacherName");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@DeptCode", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,500),
					new SqlParameter("@RegisterDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Writor", SqlDbType.NVarChar,50),
					
					new SqlParameter("@ActivityFormId", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityForm", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityContent", SqlDbType.NVarChar,2000),
					new SqlParameter("@MainSpeaker", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassHour", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Comment", SqlDbType.NVarChar,1000),
                    new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
                    new SqlParameter("@TeacherName", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.DeptCode;
           parameters[1].Value = model.DeptName;
           parameters[2].Value = model.RegisterDate;
           parameters[3].Value = model.Writor;
          
           parameters[4].Value = model.ActivityFormId;
           parameters[5].Value = model.ActivityForm;
           parameters[6].Value = model.ActivityContent;
           parameters[7].Value = model.MainSpeaker;
           parameters[8].Value = model.ClassHour;
           parameters[9].Value = model.ActivityDate;
           parameters[10].Value = model.Comment;
           parameters[11].Value = model.TeacherId;
           parameters[12].Value = model.TeacherName;
           parameters[13].Value = id;

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
       #region 分页
       public List<Model.TrainingTeachingActivitiesModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
           string ActivityFormId, string MainSpeaker, string ClassHour, string ActivityDate,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_TrainingTeachingActivities where StudentsName='" + StudentsName + "' and TrainingBaseCode='" + TrainingBaseCode + "'";

           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and DeptName like '%" + DeptName + "%'";
           }
           if (ActivityFormId != "-1" && !string.IsNullOrEmpty(ActivityFormId))
           {
               sql += "and ActivityFormId ='" + ActivityFormId + "'";
           }
           if (!string.IsNullOrEmpty(MainSpeaker))
           {
               sql += "and MainSpeaker like '%" + MainSpeaker + "%'";
           }
           if (!string.IsNullOrEmpty(ClassHour))
           {
               sql += "and ClassHour like '%" + ClassHour + "%'";
           }
           if (!string.IsNullOrEmpty(ActivityDate))
           {
               sql += "and ActivityDate like '%" + ActivityDate + "%'";
           }
           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<TrainingTeachingActivitiesModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<TrainingTeachingActivitiesModel>();
               TrainingTeachingActivitiesModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new TrainingTeachingActivitiesModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
           string ActivityFormId, string MainSpeaker, string ClassHour, string ActivityDate)
       {
           string sql = "select count(*) from GP_TrainingTeachingActivities where TrainingBaseCode='" + TrainingBaseCode
               + "' and StudentsName='" + StudentsName + "'";
           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and DeptName like '%" + DeptName + "%'";
           }
           if (ActivityFormId != "-1" && !string.IsNullOrEmpty(ActivityFormId))
           {
               sql += "and ActivityFormId ='" + ActivityFormId + "'";
           }
           if (!string.IsNullOrEmpty(MainSpeaker))
           {
               sql += "and MainSpeaker like '%" + MainSpeaker + "%'";
           }
           if (!string.IsNullOrEmpty(ClassHour))
           {
               sql += "and ClassHour like '%" + ClassHour + "%'";
           }
           if (!string.IsNullOrEmpty(ActivityDate))
           {
               sql += "and ActivityDate like '%" + ActivityDate + "%'";
           }

           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region Common分页
       public List<Model.TrainingTeachingActivitiesModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string ActivityFormId, string MainSpeaker, string ClassHour, string ActivityDate,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_TrainingTeachingActivities where TrainingBaseCode like '%" + TrainingBaseCode + "%'";

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
           if (ActivityFormId != "-1" && !string.IsNullOrEmpty(ActivityFormId))
           {
               sql += "and ActivityFormId ='" + ActivityFormId + "'";
           }
           if (!string.IsNullOrEmpty(MainSpeaker))
           {
               sql += "and MainSpeaker like '%" + MainSpeaker + "%'";
           }
           if (!string.IsNullOrEmpty(ClassHour))
           {
               sql += "and ClassHour like '%" + ClassHour + "%'";
           }
           if (!string.IsNullOrEmpty(ActivityDate))
           {
               sql += "and ActivityDate like '%" + ActivityDate + "%'";
           }
           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<TrainingTeachingActivitiesModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<TrainingTeachingActivitiesModel>();
               TrainingTeachingActivitiesModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new TrainingTeachingActivitiesModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string ActivityFormId, string MainSpeaker, string ClassHour, string ActivityDate)
       {
           string sql = "select count(*) from GP_TrainingTeachingActivities where TrainingBaseCode like '%" + TrainingBaseCode + "%'";
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
           if (ActivityFormId != "-1" && !string.IsNullOrEmpty(ActivityFormId))
           {
               sql += "and ActivityFormId ='" + ActivityFormId + "'";
           }
           if (!string.IsNullOrEmpty(MainSpeaker))
           {
               sql += "and MainSpeaker like '%" + MainSpeaker + "%'";
           }
           if (!string.IsNullOrEmpty(ClassHour))
           {
               sql += "and ClassHour like '%" + ClassHour + "%'";
           }
           if (!string.IsNullOrEmpty(ActivityDate))
           {
               sql += "and ActivityDate like '%" + ActivityDate + "%'";
           }

           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion


       #region UpdateCheckByTeacher(TrainingTeachingActivitiesModel model)
       public bool UpdateCheckByTeacher(TrainingTeachingActivitiesModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_TrainingTeachingActivities set ");
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
