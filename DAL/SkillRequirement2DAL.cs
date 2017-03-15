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
   public class SkillRequirement2DAL
    {
       SqlHelper db = new SqlHelper();

       #region Add(SkillRequirement2Model model)
       public bool Add(SkillRequirement2Model model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_SkillRequirement2(");
           strSql.Append("Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,TeacherId,TeacherName,Comment,SkillName,RequiredNum,RealNum,MasterDegree,PatientName,CaseNum,IsOk,OperateDate)");
           strSql.Append(" values (");
           strSql.Append("@Id,@StudentsRealName,@StudentsName,@TrainingBaseCode,@TrainingBaseName,@ProfessionalBaseCode,@ProfessionalBaseName,@DeptCode,@DeptName,@RegisterDate,@Writor,@TeacherCheck,@KzrCheck,@BaseCheck,@ManagerCheck,@TeacherId,@TeacherName,@Comment,@SkillName,@RequiredNum,@RealNum,@MasterDegree,@PatientName,@CaseNum,@IsOk,@OperateDate)");
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
					new SqlParameter("@SkillName", SqlDbType.NVarChar,500),
					new SqlParameter("@RequiredNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RealNum", SqlDbType.NVarChar,50),
					new SqlParameter("@MasterDegree", SqlDbType.NVarChar,50),
					new SqlParameter("@PatientName", SqlDbType.NVarChar,50),
					new SqlParameter("@CaseNum", SqlDbType.NVarChar,50),
					new SqlParameter("@IsOk", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateDate", SqlDbType.NVarChar,50)};
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
           parameters[18].Value = model.SkillName;
           parameters[19].Value = model.RequiredNum;
           parameters[20].Value = model.RealNum;
           parameters[21].Value = model.MasterDegree;
           parameters[22].Value = model.PatientName;
           parameters[23].Value = model.CaseNum;
           parameters[24].Value = model.IsOk;
           parameters[25].Value = model.OperateDate;

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
       public List<SkillRequirement2Model> GetListById(string Id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,TeacherId,TeacherName,Comment,SkillName,RequiredNum,RealNum,MasterDegree,PatientName,CaseNum,IsOk,OperateDate from GP_SkillRequirement2 ");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Id;

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           List<SkillRequirement2Model> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<SkillRequirement2Model>();
               SkillRequirement2Model model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new SkillRequirement2Model();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       } 
       #endregion

       #region Update(SkillRequirement2Model model)
       public bool Update(SkillRequirement2Model model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_SkillRequirement2 set ");
           strSql.Append("Comment=@Comment,");
           strSql.Append("SkillName=@SkillName,");
           strSql.Append("PatientName=@PatientName,");
           strSql.Append("CaseNum=@CaseNum,");
           strSql.Append("IsOk=@IsOk,");
           strSql.Append("OperateDate=@OperateDate");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Comment", SqlDbType.NVarChar,1000),
					new SqlParameter("@SkillName", SqlDbType.NVarChar,500),
					new SqlParameter("@PatientName", SqlDbType.NVarChar,50),
					new SqlParameter("@CaseNum", SqlDbType.NVarChar,50),
					new SqlParameter("@IsOk", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.Comment;
           parameters[1].Value = model.SkillName;
           parameters[2].Value = model.PatientName;
           parameters[3].Value = model.CaseNum;
           parameters[4].Value = model.IsOk;
           parameters[5].Value = model.OperateDate;
           parameters[6].Value = model.Id;

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
       public SkillRequirement2Model DataRowToModel(DataRow row)
       {
           SkillRequirement2Model model = new SkillRequirement2Model();
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
               if (row["SkillName"] != null)
               {
                   model.SkillName = row["SkillName"].ToString();
               }
               if (row["RequiredNum"] != null)
               {
                   model.RequiredNum = row["RequiredNum"].ToString();
               }
               if (row["RealNum"] != null)
               {
                   model.RealNum = row["RealNum"].ToString();
               }
               if (row["MasterDegree"] != null)
               {
                   model.MasterDegree = row["MasterDegree"].ToString();
               }
               if (row["PatientName"] != null)
               {
                   model.PatientName = row["PatientName"].ToString();
               }
               if (row["CaseNum"] != null)
               {
                   model.CaseNum = row["CaseNum"].ToString();
               }
               if (row["IsOk"] != null)
               {
                   model.IsOk = row["IsOk"].ToString();
               }
               if (row["OperateDate"] != null)
               {
                   model.OperateDate = row["OperateDate"].ToString();
               }
           }
           return model;
       } 
       #endregion

       #region 分页
       public List<Model.SkillRequirement2Model> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName, string SkillName, string RequiredNum, string MasterDegree,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_SkillRequirement2 where StudentsName='" + StudentsName + "' and TrainingBaseCode='" + TrainingBaseCode + "'";

           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and DeptName like '%" + DeptName + "%'";
           }
           if (!string.IsNullOrEmpty(SkillName))
           {
               sql += "and SkillName like '%" + SkillName + "%'";
           }
           if (!string.IsNullOrEmpty(RequiredNum))
           {
               sql += "and RequiredNum ='" + RequiredNum + "'";
           }
           if (!string.IsNullOrEmpty(MasterDegree))
           {
               sql += "and MasterDegree like '%" + MasterDegree + "%'";
           }
           sql += ")as t where t.num>=@start and t.num<=@end";

           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<SkillRequirement2Model> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<SkillRequirement2Model>();
               SkillRequirement2Model model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new SkillRequirement2Model();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName, string SkillName, string RequiredNum, string MasterDegree)
       {
           string sql = "select count(*) from GP_SkillRequirement2 where TrainingBaseCode='" + TrainingBaseCode
               + "' and StudentsName='" + StudentsName + "'";
           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and DeptName like '%" + DeptName + "%'";
           }
           if (!string.IsNullOrEmpty(SkillName))
           {
               sql += "and SkillName like '%" + SkillName + "%'";
           }
           if (!string.IsNullOrEmpty(RequiredNum))
           {
               sql += "and RequiredNum ='" + RequiredNum + "'";
           }
           if (!string.IsNullOrEmpty(MasterDegree))
           {
               sql += "and MasterDegree like '%" + MasterDegree + "%'";
           }
           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region Common分页
       public List<Model.SkillRequirement2Model> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string SkillName, string RequiredNum, string MasterDegree,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_SkillRequirement2 where TrainingBaseCode like '%" + TrainingBaseCode + "%'";

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
           if (!string.IsNullOrEmpty(SkillName))
           {
               sql += "and SkillName like '%" + SkillName + "%'";
           }
           if (!string.IsNullOrEmpty(RequiredNum))
           {
               sql += "and RequiredNum ='" + RequiredNum + "'";
           }
           if (!string.IsNullOrEmpty(MasterDegree))
           {
               sql += "and MasterDegree like '%" + MasterDegree + "%'";
           }
           sql += ")as t where t.num>=@start and t.num<=@end";

           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<SkillRequirement2Model> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<SkillRequirement2Model>();
               SkillRequirement2Model model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new SkillRequirement2Model();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string SkillName, string RequiredNum, string MasterDegree)
       {
           string sql = "select count(*) from GP_SkillRequirement2 where TrainingBaseCode like '%" + TrainingBaseCode + "%'";
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
           if (!string.IsNullOrEmpty(SkillName))
           {
               sql += "and SkillName like '%" + SkillName + "%'";
           }
           if (!string.IsNullOrEmpty(RequiredNum))
           {
               sql += "and RequiredNum ='" + RequiredNum + "'";
           }
           if (!string.IsNullOrEmpty(MasterDegree))
           {
               sql += "and MasterDegree like '%" + MasterDegree + "%'";
           }
           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region UpdateCheckByTeacher(SkillRequirement2Model model)
       public bool UpdateCheckByTeacher(SkillRequirement2Model model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_SkillRequirement2 set ");
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
