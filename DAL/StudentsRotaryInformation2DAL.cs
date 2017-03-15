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
   public class StudentsRotaryInformation2DAL
    {
       SqlHelper db = new SqlHelper();

       #region Add
       public bool Add(int length, StudentsRotaryInformation2Model studentsRotaryInformation2Model, List<string> DeptCodeList, List<string> DeptNameList, List<string> BeginTimeList, List<string> EndTimeList, List<string> DaysList, List<string> TeachersNameList, List<string> TeachersRealNameList)
       {

           int i;
           List<string> sqlList = new List<string>();
           StringBuilder strSql = new StringBuilder();
           for (i = 0; i < length; i++)
           {
               string sql = "insert into GP_StudentsRotaryInformation2(Id,Name,RealName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RotaryBeginTime,RotaryEndTime,RotaryDays,RotaryOrder,TeachersName,TeachersRealName,OutdeptStatus,OutdeptApplication,QuestionnaireStatus,Tag1,Tag2,Tag3) values(" +
                                      "'" + Guid.NewGuid().ToString() + "','" + studentsRotaryInformation2Model.Name + "','" + studentsRotaryInformation2Model.RealName + "','" + studentsRotaryInformation2Model.TrainingBaseCode + "','" + studentsRotaryInformation2Model.TrainingBaseName + "'" +
                                  ",'" + studentsRotaryInformation2Model.ProfessionalBaseCode + "','" + studentsRotaryInformation2Model.ProfessionalBaseName + "','" + DeptCodeList[i] + "','" + DeptNameList[i] + "','" + BeginTimeList[i] + "'" +
                                  ",'" + EndTimeList[i] + "','" + DaysList[i] + "','" + i + "','" + TeachersNameList[i] + "','" + TeachersRealNameList[i] + "','" + studentsRotaryInformation2Model.OutdeptStatus + "','" + studentsRotaryInformation2Model.OutdeptApplication + "','" + studentsRotaryInformation2Model.QuestionnaireStatus + "'" +
                                  ",'" + studentsRotaryInformation2Model.Tag1 + "','" + studentsRotaryInformation2Model.Tag2 + "','" + studentsRotaryInformation2Model.Tag3 + "')";
               sqlList.Add(sql);
           }

           int rows = db.ExecuteSqlTran(sqlList);
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

       #region GetDtByNT(string Name, string TrainingBaseCode)
       public DataTable GetDtByNT(string Name, string TrainingBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select Id,Name,RealName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RotaryBeginTime,RotaryEndTime,RotaryDays,RotaryOrder,TeachersName,TeachersRealName,OutdeptStatus,OutdeptApplication,QuestionnaireStatus,Tag1,Tag2,Tag3 from GP_StudentsRotaryInformation2 ");
           strSql.Append(" where Name=@Name and TrainingBaseCode=@TrainingBaseCode order by RotaryOrder asc");
           SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Name;
           parameters[1].Value = TrainingBaseCode;


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


       #region DataRowToModel(DataRow row)
       public StudentsRotaryInformation2Model DataRowToModel(DataRow row)
       {
           StudentsRotaryInformation2Model model = new StudentsRotaryInformation2Model();
           if (row != null)
           {
               if (row["Id"] != null)
               {
                   model.Id = row["Id"].ToString();
               }
               if (row["Name"] != null)
               {
                   model.Name = row["Name"].ToString();
               }
               if (row["RealName"] != null)
               {
                   model.RealName = row["RealName"].ToString();
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
               if (row["RotaryBeginTime"] != null)
               {
                   model.RotaryBeginTime = row["RotaryBeginTime"].ToString();
               }
               if (row["RotaryEndTime"] != null)
               {
                   model.RotaryEndTime = row["RotaryEndTime"].ToString();
               }
               if (row["RotaryDays"] != null)
               {
                   model.RotaryDays = row["RotaryDays"].ToString();
               }
               if (row["RotaryOrder"] != null)
               {
                   model.RotaryOrder = row["RotaryOrder"].ToString();
               }
               if (row["TeachersName"] != null)
               {
                   model.TeachersName = row["TeachersName"].ToString();
               }
               if (row["TeachersRealName"] != null)
               {
                   model.TeachersRealName = row["TeachersRealName"].ToString();
               }
               if (row["OutdeptStatus"] != null)
               {
                   model.OutdeptStatus = row["OutdeptStatus"].ToString();
               }
               if (row["OutdeptApplication"] != null)
               {
                   model.OutdeptApplication = row["OutdeptApplication"].ToString();
               }
               if (row["QuestionnaireStatus"] != null)
               {
                   model.QuestionnaireStatus = row["QuestionnaireStatus"].ToString();
               }
               if (row["Tag1"] != null)
               {
                   model.Tag1 = row["Tag1"].ToString();
               }
               if (row["Tag2"] != null)
               {
                   model.Tag2 = row["Tag2"].ToString();
               }
               if (row["Tag3"] != null)
               {
                   model.Tag3 = row["Tag3"].ToString();
               }
           }
           return model;
       } 
       #endregion


       #region UpdateApplication(StudentsRotaryInformation2Model model)
       public bool UpdateApplication(StudentsRotaryInformation2Model model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_StudentsRotaryInformation2 set ");
           strSql.Append("OutdeptApplication=@OutdeptApplication");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@OutdeptApplication", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.OutdeptApplication;
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

       #region GetModelById(string Id)
       public StudentsRotaryInformation2Model GetModelById(string Id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 Id,Name,RealName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RotaryBeginTime,RotaryEndTime,RotaryDays,RotaryOrder,TeachersName,TeachersRealName,OutdeptStatus,OutdeptApplication,QuestionnaireStatus,Tag1,Tag2,Tag3 from GP_StudentsRotaryInformation2 ");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Id;

           StudentsRotaryInformation2Model model = new StudentsRotaryInformation2Model();
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

       #region   UpdateQuestStatus(string status, string id)
       public bool UpdateQuestStatus(string status, string id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_StudentsRotaryInformation2 set ");
           strSql.Append("QuestionnaireStatus=@QuestionnaireStatus");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@QuestionnaireStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = status;
           parameters[1].Value = id;

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

       #region UpdateOutdeptStatusByT(StudentsRotaryModel model)
       public bool UpdateOutdeptStatusByT(string status, string id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_StudentsRotaryInformation2 set ");
           strSql.Append("OutdeptStatus=@OutdeptStatus");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@OutdeptStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = status;
           parameters[1].Value = id;

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

       #region AddOne(StudentsRotaryInformation2Model model)
       public bool AddOne(StudentsRotaryInformation2Model model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_StudentsRotaryInformation2(");
           strSql.Append("Id,Name,RealName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RotaryBeginTime,RotaryEndTime,RotaryDays,RotaryOrder,TeachersName,TeachersRealName,OutdeptStatus,OutdeptApplication,QuestionnaireStatus,Tag1,Tag2,Tag3)");
           strSql.Append(" values (");
           strSql.Append("@Id,@Name,@RealName,@TrainingBaseCode,@TrainingBaseName,@ProfessionalBaseCode,@ProfessionalBaseName,@DeptCode,@DeptName,@RotaryBeginTime,@RotaryEndTime,@RotaryDays,@RotaryOrder,@TeachersName,@TeachersRealName,@OutdeptStatus,@OutdeptApplication,@QuestionnaireStatus,@Tag1,@Tag2,@Tag3)");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptCode", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,500),
					new SqlParameter("@RotaryBeginTime", SqlDbType.NVarChar,50),
					new SqlParameter("@RotaryEndTime", SqlDbType.NVarChar,50),
					new SqlParameter("@RotaryDays", SqlDbType.NVarChar,50),
					new SqlParameter("@RotaryOrder", SqlDbType.Int,4),
					new SqlParameter("@TeachersName", SqlDbType.NVarChar,50),
					new SqlParameter("@TeachersRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@OutdeptStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@OutdeptApplication", SqlDbType.NVarChar,50),
					new SqlParameter("@QuestionnaireStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag1", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag2", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag3", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.Id;
           parameters[1].Value = model.Name;
           parameters[2].Value = model.RealName;
           parameters[3].Value = model.TrainingBaseCode;
           parameters[4].Value = model.TrainingBaseName;
           parameters[5].Value = model.ProfessionalBaseCode;
           parameters[6].Value = model.ProfessionalBaseName;
           parameters[7].Value = model.DeptCode;
           parameters[8].Value = model.DeptName;
           parameters[9].Value = model.RotaryBeginTime;
           parameters[10].Value = model.RotaryEndTime;
           parameters[11].Value = model.RotaryDays;
           parameters[12].Value = model.RotaryOrder;
           parameters[13].Value = model.TeachersName;
           parameters[14].Value = model.TeachersRealName;
           parameters[15].Value = model.OutdeptStatus;
           parameters[16].Value = model.OutdeptApplication;
           parameters[17].Value = model.QuestionnaireStatus;
           parameters[18].Value = model.Tag1;
           parameters[19].Value = model.Tag2;
           parameters[20].Value = model.Tag3;

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
