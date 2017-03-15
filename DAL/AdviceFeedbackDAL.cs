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
   public class AdviceFeedbackDAL
    {
       SqlHelper db=new SqlHelper();
       #region Add(AdviceFeedbackModel model)
       public bool Add(AdviceFeedbackModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_AdviceFeedback(");
           strSql.Append("Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,TeacherId,TeacherName,Comment,FeedbackInformation,ManagerReply,ManagerName,ManagerDate,ManagerHandle)");
           strSql.Append(" values (");
           strSql.Append("@Id,@StudentsRealName,@StudentsName,@TrainingBaseCode,@TrainingBaseName,@ProfessionalBaseCode,@ProfessionalBaseName,@DeptCode,@DeptName,@RegisterDate,@Writor,@TeacherCheck,@KzrCheck,@BaseCheck,@ManagerCheck,@TeacherId,@TeacherName,@Comment,@FeedbackInformation,@ManagerReply,@ManagerName,@ManagerDate,@ManagerHandle)");
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
					new SqlParameter("@FeedbackInformation", SqlDbType.NVarChar,2000),
					new SqlParameter("@ManagerReply", SqlDbType.NVarChar,2000),
					new SqlParameter("@ManagerName", SqlDbType.NVarChar,50),
					new SqlParameter("@ManagerDate", SqlDbType.NVarChar,50),
					new SqlParameter("@ManagerHandle", SqlDbType.NVarChar,50)};
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
           parameters[18].Value = model.FeedbackInformation;
           parameters[19].Value = model.ManagerReply;
           parameters[20].Value = model.ManagerName;
           parameters[21].Value = model.ManagerDate;
           parameters[22].Value = model.ManagerHandle;

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
           strSql.Append("delete from GP_AdviceFeedback ");
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
       public List<AdviceFeedbackModel> GetListById(string Id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,TeacherId,TeacherName,Comment,FeedbackInformation,ManagerReply,ManagerName,ManagerDate,ManagerHandle from GP_AdviceFeedback ");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Id;

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           List<AdviceFeedbackModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<AdviceFeedbackModel>();
               AdviceFeedbackModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new AdviceFeedbackModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }

           }
           return list;

       } 
       #endregion

       #region DataRowToModel(DataRow row)
       public AdviceFeedbackModel DataRowToModel(DataRow row)
       {
           AdviceFeedbackModel model = new AdviceFeedbackModel();
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
               if (row["FeedbackInformation"] != null)
               {
                   model.FeedbackInformation = row["FeedbackInformation"].ToString();
               }
               if (row["ManagerReply"] != null)
               {
                   model.ManagerReply = row["ManagerReply"].ToString();
               }
               if (row["ManagerName"] != null)
               {
                   model.ManagerName = row["ManagerName"].ToString();
               }
               if (row["ManagerDate"] != null)
               {
                   model.ManagerDate = row["ManagerDate"].ToString();
               }
               if (row["ManagerHandle"] != null)
               {
                   model.ManagerHandle = row["ManagerHandle"].ToString();
               }
           }
           return model;
       } 
       #endregion
       #region Update(AdviceFeedbackModel model)
       public bool Update(AdviceFeedbackModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_AdviceFeedback set ");
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
           strSql.Append("FeedbackInformation=@FeedbackInformation,");
           strSql.Append("ManagerReply=@ManagerReply,");
           strSql.Append("ManagerName=@ManagerName,");
           strSql.Append("ManagerDate=@ManagerDate");
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
					new SqlParameter("@FeedbackInformation", SqlDbType.NVarChar,2000),
					new SqlParameter("@ManagerReply", SqlDbType.NVarChar,2000),
					new SqlParameter("@ManagerName", SqlDbType.NVarChar,50),
					new SqlParameter("@ManagerDate", SqlDbType.NVarChar,50),
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
           parameters[13].Value = model.FeedbackInformation;
           parameters[14].Value = model.ManagerReply;
           parameters[15].Value = model.ManagerName;
           parameters[16].Value = model.ManagerDate;
           parameters[17].Value = model.Id;

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
        public List<Model.AdviceFeedbackModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
            string ManagerHandle, string RegisterDate,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_AdviceFeedback where StudentsName='" + StudentsName + "' and TrainingBaseCode='" + TrainingBaseCode + "'";

            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(ManagerHandle))
            {
                sql += "and ManagerHandle ='" + ManagerHandle + "'";
            }
            if (!string.IsNullOrEmpty(RegisterDate))
            {
                sql += "and RegisterDate like '%" + RegisterDate + "%'";
            }
            
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<AdviceFeedbackModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<AdviceFeedbackModel>();
                AdviceFeedbackModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new AdviceFeedbackModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string ManagerHandle, string RegisterDate)
        {
            string sql = "select count(*) from GP_AdviceFeedback where TrainingBaseCode='" + TrainingBaseCode
                + "' and StudentsName='" + StudentsName + "'";
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(ManagerHandle))
            {
                sql += "and ManagerHandle ='" + ManagerHandle + "'";
            }
            if (!string.IsNullOrEmpty(RegisterDate))
            {
                sql += "and RegisterDate like '%" + RegisterDate + "%'";
            }

            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion


        #region managers分页
        public List<Model.AdviceFeedbackModel> managersGetPagedList(string TrainingBaseCode,string StudentsRealName,string ProfessionalBaseName, string DeptName,
            string ManagerHandle, string RegisterDate,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_AdviceFeedback where TrainingBaseCode like '%" + TrainingBaseCode + "%'";

            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and StudentsRealName = '" + StudentsRealName + "'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseName))
            {
                sql += "and ProfessionalBaseName ='" + ProfessionalBaseName + "'";
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(ManagerHandle))
            {
                sql += "and ManagerHandle ='" + ManagerHandle + "'";
            }
            if (!string.IsNullOrEmpty(RegisterDate))
            {
                sql += "and RegisterDate like '%" + RegisterDate + "%'";
            }

            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<AdviceFeedbackModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<AdviceFeedbackModel>();
                AdviceFeedbackModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new AdviceFeedbackModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int managersGetRecordCount(string TrainingBaseCode, string StudentsRealName, string ProfessionalBaseName, string DeptName,
            string ManagerHandle, string RegisterDate)
        {
            string sql = "select count(*) from GP_AdviceFeedback where TrainingBaseCode like '%" + TrainingBaseCode+ "%'";
            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and StudentsRealName = '" + StudentsRealName + "'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseName))
            {
                sql += "and ProfessionalBaseName ='" + ProfessionalBaseName + "'";
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(ManagerHandle))
            {
                sql += "and ManagerHandle ='" + ManagerHandle + "'";
            }
            if (!string.IsNullOrEmpty(RegisterDate))
            {
                sql += "and RegisterDate like '%" + RegisterDate + "%'";
            }

            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion

        #region ManagerReply(AdviceFeedbackModel model)
        public bool ManagerReply(AdviceFeedbackModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GP_AdviceFeedback set ");
            strSql.Append("ManagerReply=@ManagerReply,");
            strSql.Append("ManagerName=@ManagerName,");
            strSql.Append("ManagerDate=@ManagerDate,");
            strSql.Append("ManagerHandle=@ManagerHandle");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@ManagerReply", SqlDbType.NVarChar,2000),
					new SqlParameter("@ManagerName", SqlDbType.NVarChar,50),
					new SqlParameter("@ManagerDate", SqlDbType.NVarChar,50),
					new SqlParameter("@ManagerHandle", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ManagerReply;
            parameters[1].Value = model.ManagerName;
            parameters[2].Value = model.ManagerDate;
            parameters[3].Value = model.ManagerHandle;
            parameters[4].Value = model.Id;

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
