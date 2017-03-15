using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
   public  class SurgeryRecordsDAL
    {
       SqlHelper db = new SqlHelper();
       #region Add(SurgeryRecordsModel model)
       public bool Add(SurgeryRecordsModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_SurgeryRecords(");
           strSql.Append("Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,PatientName,CaseId,SurgeryName,IntraoperativePosition,RoomId,MainDiagnosis,SecondaryDiagnosis,Emergency,SurgeryDate,SurgeryScale,DoctorInCharge,Assistant,Nurse,AnesthesiaMethod,Anesthetist,SurgeryIsStop,StopReason,Comment,TeacherId,TeacherName)");
           strSql.Append(" values (");
           strSql.Append("@Id,@StudentsRealName,@StudentsName,@TrainingBaseCode,@TrainingBaseName,@ProfessionalBaseCode,@ProfessionalBaseName,@DeptCode,@DeptName,@RegisterDate,@Writor,@TeacherCheck,@KzrCheck,@BaseCheck,@ManagerCheck,@PatientName,@CaseId,@SurgeryName,@IntraoperativePosition,@RoomId,@MainDiagnosis,@SecondaryDiagnosis,@Emergency,@SurgeryDate,@SurgeryScale,@DoctorInCharge,@Assistant,@Nurse,@AnesthesiaMethod,@Anesthetist,@SurgeryIsStop,@StopReason,@Comment,@TeacherId,@TeacherName)");
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
					new SqlParameter("@PatientName", SqlDbType.NVarChar,50),
					new SqlParameter("@CaseId", SqlDbType.NVarChar,50),
					new SqlParameter("@SurgeryName", SqlDbType.NVarChar,500),
					new SqlParameter("@IntraoperativePosition", SqlDbType.NVarChar,50),
					new SqlParameter("@RoomId", SqlDbType.NVarChar,50),
					new SqlParameter("@MainDiagnosis", SqlDbType.NVarChar,1000),
					new SqlParameter("@SecondaryDiagnosis", SqlDbType.NVarChar,1000),
					new SqlParameter("@Emergency", SqlDbType.NVarChar,50),
					new SqlParameter("@SurgeryDate", SqlDbType.NVarChar,50),
					new SqlParameter("@SurgeryScale", SqlDbType.NVarChar,50),
					new SqlParameter("@DoctorInCharge", SqlDbType.NVarChar,50),
					new SqlParameter("@Assistant", SqlDbType.NVarChar,500),
					new SqlParameter("@Nurse", SqlDbType.NVarChar,500),
					new SqlParameter("@AnesthesiaMethod", SqlDbType.NVarChar,500),
					new SqlParameter("@Anesthetist", SqlDbType.NVarChar,50),
					new SqlParameter("@SurgeryIsStop", SqlDbType.NVarChar,50),
					new SqlParameter("@StopReason", SqlDbType.NVarChar,1000),
					new SqlParameter("@Comment", SqlDbType.NVarChar,1000),
                    new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
                                       new SqlParameter("@TeacherName", SqlDbType.NVarChar,50)};
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
           parameters[15].Value = model.PatientName;
           parameters[16].Value = model.CaseId;
           parameters[17].Value = model.SurgeryName;
           parameters[18].Value = model.IntraoperativePosition;
           parameters[19].Value = model.RoomId;
           parameters[20].Value = model.MainDiagnosis;
           parameters[21].Value = model.SecondaryDiagnosis;
           parameters[22].Value = model.Emergency;
           parameters[23].Value = model.SurgeryDate;
           parameters[24].Value = model.SurgeryScale;
           parameters[25].Value = model.DoctorInCharge;
           parameters[26].Value = model.Assistant;
           parameters[27].Value = model.Nurse;
           parameters[28].Value = model.AnesthesiaMethod;
           parameters[29].Value = model.Anesthetist;
           parameters[30].Value = model.SurgeryIsStop;
           parameters[31].Value = model.StopReason;
           parameters[32].Value = model.Comment;
           parameters[33].Value = model.TeacherId;
           parameters[34].Value = model.TeacherName;

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
       public SurgeryRecordsModel GetModelById(string Id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,PatientName,CaseId,SurgeryName,IntraoperativePosition,RoomId,MainDiagnosis,SecondaryDiagnosis,Emergency,SurgeryDate,SurgeryScale,DoctorInCharge,Assistant,Nurse,AnesthesiaMethod,Anesthetist,SurgeryIsStop,StopReason,Comment,TeacherId,TeacherName from GP_SurgeryRecords ");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Id;

           SurgeryRecordsModel model = new SurgeryRecordsModel();
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
       public SurgeryRecordsModel DataRowToModel(DataRow row)
       {
           SurgeryRecordsModel model = new SurgeryRecordsModel();
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
               if (row["PatientName"] != null)
               {
                   model.PatientName = row["PatientName"].ToString();
               }
               if (row["CaseId"] != null)
               {
                   model.CaseId = row["CaseId"].ToString();
               }
               if (row["SurgeryName"] != null)
               {
                   model.SurgeryName = row["SurgeryName"].ToString();
               }
               if (row["IntraoperativePosition"] != null)
               {
                   model.IntraoperativePosition = row["IntraoperativePosition"].ToString();
               }
               if (row["RoomId"] != null)
               {
                   model.RoomId = row["RoomId"].ToString();
               }
               if (row["MainDiagnosis"] != null)
               {
                   model.MainDiagnosis = row["MainDiagnosis"].ToString();
               }
               if (row["SecondaryDiagnosis"] != null)
               {
                   model.SecondaryDiagnosis = row["SecondaryDiagnosis"].ToString();
               }
               if (row["Emergency"] != null)
               {
                   model.Emergency = row["Emergency"].ToString();
               }
               if (row["SurgeryDate"] != null)
               {
                   model.SurgeryDate = row["SurgeryDate"].ToString();
               }
               if (row["SurgeryScale"] != null)
               {
                   model.SurgeryScale = row["SurgeryScale"].ToString();
               }
               if (row["DoctorInCharge"] != null)
               {
                   model.DoctorInCharge = row["DoctorInCharge"].ToString();
               }
               if (row["Assistant"] != null)
               {
                   model.Assistant = row["Assistant"].ToString();
               }
               if (row["Nurse"] != null)
               {
                   model.Nurse = row["Nurse"].ToString();
               }
               if (row["AnesthesiaMethod"] != null)
               {
                   model.AnesthesiaMethod = row["AnesthesiaMethod"].ToString();
               }
               if (row["Anesthetist"] != null)
               {
                   model.Anesthetist = row["Anesthetist"].ToString();
               }
               if (row["SurgeryIsStop"] != null)
               {
                   model.SurgeryIsStop = row["SurgeryIsStop"].ToString();
               }
               if (row["StopReason"] != null)
               {
                   model.StopReason = row["StopReason"].ToString();
               }
               if (row["Comment"] != null)
               {
                   model.Comment = row["Comment"].ToString();
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

       #region Update(SurgeryRecordsModel model,string id)
       public bool Update(SurgeryRecordsModel model, string id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_SurgeryRecords set ");
           strSql.Append("DeptCode=@DeptCode,");
           strSql.Append("DeptName=@DeptName,");
           strSql.Append("RegisterDate=@RegisterDate,");
           strSql.Append("Writor=@Writor,");
           
           strSql.Append("PatientName=@PatientName,");
           strSql.Append("CaseId=@CaseId,");
           strSql.Append("SurgeryName=@SurgeryName,");
           strSql.Append("IntraoperativePosition=@IntraoperativePosition,");
           strSql.Append("RoomId=@RoomId,");
           strSql.Append("MainDiagnosis=@MainDiagnosis,");
           strSql.Append("SecondaryDiagnosis=@SecondaryDiagnosis,");
           strSql.Append("Emergency=@Emergency,");
           strSql.Append("SurgeryDate=@SurgeryDate,");
           strSql.Append("SurgeryScale=@SurgeryScale,");
           strSql.Append("DoctorInCharge=@DoctorInCharge,");
           strSql.Append("Assistant=@Assistant,");
           strSql.Append("Nurse=@Nurse,");
           strSql.Append("AnesthesiaMethod=@AnesthesiaMethod,");
           strSql.Append("Anesthetist=@Anesthetist,");
           strSql.Append("SurgeryIsStop=@SurgeryIsStop,");
           strSql.Append("StopReason=@StopReason,");
           strSql.Append("Comment=@Comment,");
           strSql.Append("TeacherId=@TeacherId,");
           strSql.Append("TeacherName=@TeacherName");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@DeptCode", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,500),
					new SqlParameter("@RegisterDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Writor", SqlDbType.NVarChar,50),
					
					new SqlParameter("@PatientName", SqlDbType.NVarChar,50),
					new SqlParameter("@CaseId", SqlDbType.NVarChar,50),
					new SqlParameter("@SurgeryName", SqlDbType.NVarChar,500),
					new SqlParameter("@IntraoperativePosition", SqlDbType.NVarChar,50),
					new SqlParameter("@RoomId", SqlDbType.NVarChar,50),
					new SqlParameter("@MainDiagnosis", SqlDbType.NVarChar,1000),
					new SqlParameter("@SecondaryDiagnosis", SqlDbType.NVarChar,1000),
					new SqlParameter("@Emergency", SqlDbType.NVarChar,50),
					new SqlParameter("@SurgeryDate", SqlDbType.NVarChar,50),
					new SqlParameter("@SurgeryScale", SqlDbType.NVarChar,50),
					new SqlParameter("@DoctorInCharge", SqlDbType.NVarChar,50),
					new SqlParameter("@Assistant", SqlDbType.NVarChar,500),
					new SqlParameter("@Nurse", SqlDbType.NVarChar,500),
					new SqlParameter("@AnesthesiaMethod", SqlDbType.NVarChar,500),
					new SqlParameter("@Anesthetist", SqlDbType.NVarChar,50),
					new SqlParameter("@SurgeryIsStop", SqlDbType.NVarChar,50),
					new SqlParameter("@StopReason", SqlDbType.NVarChar,1000),
					new SqlParameter("@Comment", SqlDbType.NVarChar,1000),
					new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
                                       new SqlParameter("@TeacherName", SqlDbType.NVarChar,50),
                                       new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.DeptCode;
           parameters[1].Value = model.DeptName;
           parameters[2].Value = model.RegisterDate;
           parameters[3].Value = model.Writor;
           
           parameters[4].Value = model.PatientName;
           parameters[5].Value = model.CaseId;
           parameters[6].Value = model.SurgeryName;
           parameters[7].Value = model.IntraoperativePosition;
           parameters[8].Value = model.RoomId;
           parameters[9].Value = model.MainDiagnosis;
           parameters[10].Value = model.SecondaryDiagnosis;
           parameters[11].Value = model.Emergency;
           parameters[12].Value = model.SurgeryDate;
           parameters[13].Value = model.SurgeryScale;
           parameters[14].Value = model.DoctorInCharge;
           parameters[15].Value = model.Assistant;
           parameters[16].Value = model.Nurse;
           parameters[17].Value = model.AnesthesiaMethod;
           parameters[18].Value = model.Anesthetist;
           parameters[19].Value = model.SurgeryIsStop;
           parameters[20].Value = model.StopReason;
           parameters[21].Value = model.Comment;
           parameters[22].Value = model.TeacherId;
           parameters[23].Value = model.TeacherName;
           parameters[24].Value = id;

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
       public List<Model.SurgeryRecordsModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
           string PatientName, string CaseId, string SurgeryName, string IntraoperativePosition,string Emergency,string SurgeryDate,string SurgeryIsStop,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_SurgeryRecords where StudentsName='" + StudentsName + "' and TrainingBaseCode='" + TrainingBaseCode + "'";

           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and DeptName like '%" + DeptName + "%'";
           }
           if (!string.IsNullOrEmpty(PatientName))
           {
               sql += "and PatientName like '%" + PatientName + "%'";
           }
           if (!string.IsNullOrEmpty(CaseId))
           {
               sql += "and CaseId like '%" + CaseId + "%'";
           }
           if (!string.IsNullOrEmpty(SurgeryName))
           {
               sql += "and SurgeryName like '%" + SurgeryName + "%'";
           }
           if (!string.IsNullOrEmpty(IntraoperativePosition))
           {
               sql += "and IntraoperativePosition like '%" + IntraoperativePosition + "%'";
           }
           if (!string.IsNullOrEmpty(Emergency))
           {
               sql += "and Emergency = '" + Emergency + "'";
           }
           if (!string.IsNullOrEmpty(SurgeryDate))
           {
               sql += "and SurgeryDate like '%" + SurgeryDate + "%'";
           }
           if (!string.IsNullOrEmpty(SurgeryIsStop))
           {
               sql += "and SurgeryIsStop = '" + SurgeryIsStop + "'";
           }

           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<SurgeryRecordsModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<SurgeryRecordsModel>();
               SurgeryRecordsModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new SurgeryRecordsModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
           string PatientName, string CaseId, string SurgeryName, string IntraoperativePosition, string Emergency, string SurgeryDate, string SurgeryIsStop)
       {
           string sql = "select count(*) from GP_SurgeryRecords where TrainingBaseCode='" + TrainingBaseCode
               + "' and StudentsName='" + StudentsName + "'";
           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and DeptName like '%" + DeptName + "%'";
           }
           if (!string.IsNullOrEmpty(PatientName))
           {
               sql += "and PatientName like '%" + PatientName + "%'";
           }
           if (!string.IsNullOrEmpty(CaseId))
           {
               sql += "and CaseId like '%" + CaseId + "%'";
           }
           if (!string.IsNullOrEmpty(SurgeryName))
           {
               sql += "and SurgeryName like '%" + SurgeryName + "%'";
           }
           if (!string.IsNullOrEmpty(IntraoperativePosition))
           {
               sql += "and IntraoperativePosition like '%" + IntraoperativePosition + "%'";
           }
           if (!string.IsNullOrEmpty(Emergency))
           {
               sql += "and Emergency = '" + Emergency + "'";
           }
           if (!string.IsNullOrEmpty(SurgeryDate))
           {
               sql += "and SurgeryDate like '%" + SurgeryDate + "%'";
           }
           if (!string.IsNullOrEmpty(SurgeryIsStop))
           {
               sql += "and SurgeryIsStop = '" + SurgeryIsStop + "'";
           }

           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region Common分页
       public List<Model.SurgeryRecordsModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string PatientName, string CaseId, string SurgeryName, string IntraoperativePosition, string Emergency, string SurgeryDate, string SurgeryIsStop,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_SurgeryRecords where TrainingBaseCode like '%" + TrainingBaseCode + "%'";

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
           if (!string.IsNullOrEmpty(PatientName))
           {
               sql += "and PatientName like '%" + PatientName + "%'";
           }
           if (!string.IsNullOrEmpty(CaseId))
           {
               sql += "and CaseId like '%" + CaseId + "%'";
           }
           if (!string.IsNullOrEmpty(SurgeryName))
           {
               sql += "and SurgeryName like '%" + SurgeryName + "%'";
           }
           if (!string.IsNullOrEmpty(IntraoperativePosition))
           {
               sql += "and IntraoperativePosition like '%" + IntraoperativePosition + "%'";
           }
           if (!string.IsNullOrEmpty(Emergency))
           {
               sql += "and Emergency = '" + Emergency + "'";
           }
           if (!string.IsNullOrEmpty(SurgeryDate))
           {
               sql += "and SurgeryDate like '%" + SurgeryDate + "%'";
           }
           if (!string.IsNullOrEmpty(SurgeryIsStop))
           {
               sql += "and SurgeryIsStop = '" + SurgeryIsStop + "'";
           }

           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<SurgeryRecordsModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<SurgeryRecordsModel>();
               SurgeryRecordsModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new SurgeryRecordsModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string PatientName, string CaseId, string SurgeryName, string IntraoperativePosition, string Emergency, string SurgeryDate, string SurgeryIsStop)
       {
           string sql = "select count(*) from GP_SurgeryRecords where TrainingBaseCode like '%" + TrainingBaseCode + "%'";
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
           if (!string.IsNullOrEmpty(PatientName))
           {
               sql += "and PatientName like '%" + PatientName + "%'";
           }
           if (!string.IsNullOrEmpty(CaseId))
           {
               sql += "and CaseId like '%" + CaseId + "%'";
           }
           if (!string.IsNullOrEmpty(SurgeryName))
           {
               sql += "and SurgeryName like '%" + SurgeryName + "%'";
           }
           if (!string.IsNullOrEmpty(IntraoperativePosition))
           {
               sql += "and IntraoperativePosition like '%" + IntraoperativePosition + "%'";
           }
           if (!string.IsNullOrEmpty(Emergency))
           {
               sql += "and Emergency = '" + Emergency + "'";
           }
           if (!string.IsNullOrEmpty(SurgeryDate))
           {
               sql += "and SurgeryDate like '%" + SurgeryDate + "%'";
           }
           if (!string.IsNullOrEmpty(SurgeryIsStop))
           {
               sql += "and SurgeryIsStop = '" + SurgeryIsStop + "'";
           }

           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region UpdateCheckByTeacher(SurgeryRecordsModel model)
       public bool UpdateCheckByTeacher(SurgeryRecordsModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_SurgeryRecords set ");
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
