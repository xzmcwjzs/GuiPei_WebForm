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
   public class DeptManagementDAL
    {
       SqlHelper db = new SqlHelper();

       #region Add
       public bool Add(int length, DeptManagementModel model, List<string> DeptNameList, List<string> DeptCodeList, List<string> DeptTimeList, List<string> RealTimeList, List<string> IsRequiredList)
       {

           int i;
           List<string> SqlList = new List<string>();
           for (i = 0; i < length; i++)
           {
               if (DeptNameList[i] != null && DeptCodeList[i] != null && DeptTimeList[i] != null && RealTimeList[i] != null && IsRequiredList[i] != null)
               {
                   string sql = "insert into GP_DeptManagement(Id,ManagersName,ManagersRealName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,DeptTime,RealTime,IsRequired,TrainingTime,TotalDeptTime,TotalRealTime,Tag1,Tag2,Tag3) values(" +
                                      "'" + Guid.NewGuid().ToString() + "','" + model.ManagersName + "','" + model.ManagersRealName + "','" + model.TrainingBaseCode + "','" + model.TrainingBaseName + "'" +
                                  ",'" + model.ProfessionalBaseCode + "','" + model.ProfessionalBaseName + "','" + DeptCodeList[i] + "','" + DeptNameList[i] + "','" + DeptTimeList[i] + "'" +
                                  ",'" + RealTimeList[i] + "','" + IsRequiredList[i] + "','" + model.TrainingTime + "','" + model.TotalDeptTime + "','" + model.TotalRealTime + "'" +
                                  ",'" + model.Tag1 + "','" + model.Tag2 + "','" + model.Tag3 + "')";
                   SqlList.Add(sql);
               }

           }

           int rows = db.ExecuteSqlTran(SqlList);

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

       #region GetModel(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       public DeptManagementModel GetModel(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from GP_DeptManagement ");
           strSql.Append(" where TrainingTime like @TrainingTime and TrainingBaseCode=@TrainingBaseCode and ProfessionalBaseCode=@ProfessionalBaseCode ");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = TrainingTime+"%";
           parameters[1].Value = TrainingBaseCode;
           parameters[2].Value = ProfessionalBaseCode;

           DeptManagementModel model = new DeptManagementModel();
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

       #region Delete(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       public bool Delete(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from GP_DeptManagement ");
           strSql.Append(" where TrainingTime like @TrainingTime and TrainingBaseCode=@TrainingBaseCode and ProfessionalBaseCode=@ProfessionalBaseCode ");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = TrainingTime+"%";
           parameters[1].Value = TrainingBaseCode;
           parameters[2].Value = ProfessionalBaseCode;

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
       public DeptManagementModel DataRowToModel(DataRow row)
       {
           DeptManagementModel model = new DeptManagementModel();
           if (row != null)
           {
               if (row["Id"] != null)
               {
                   model.Id = row["Id"].ToString();
               }
               if (row["ManagersName"] != null)
               {
                   model.ManagersName = row["ManagersName"].ToString();
               }
               if (row["ManagersRealName"] != null)
               {
                   model.ManagersRealName = row["ManagersRealName"].ToString();
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
               if (row["DeptTime"] != null)
               {
                   model.DeptTime = row["DeptTime"].ToString();
               }
               if (row["RealTime"] != null)
               {
                   model.RealTime = row["RealTime"].ToString();
               }
               if (row["IsRequired"] != null)
               {
                   model.IsRequired = row["IsRequired"].ToString();
               }
               if (row["TrainingTime"] != null)
               {
                   model.TrainingTime = row["TrainingTime"].ToString();
               }
               if (row["TotalDeptTime"] != null)
               {
                   model.TotalDeptTime = row["TotalDeptTime"].ToString();
               }
               if (row["TotalRealTime"] != null)
               {
                   model.TotalRealTime = row["TotalRealTime"].ToString();
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

       #region GetDeptList(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       public List<DeptManagementModel> GetDeptList(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       {

            StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from GP_DeptManagement ");
           strSql.Append(" where TrainingTime like @TrainingTime and TrainingBaseCode=@TrainingBaseCode and ProfessionalBaseCode=@ProfessionalBaseCode ");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = TrainingTime+"%";
           parameters[1].Value = TrainingBaseCode;
           parameters[2].Value = ProfessionalBaseCode;

           List<DeptManagementModel> list = null;
           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           if (dt.Rows.Count > 0)
           {
               list = new List<DeptManagementModel>();
               DeptManagementModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new DeptManagementModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       } 
       #endregion

       #region UpdateTeachers
       public bool UpdateTeachers(int length, List<string> IdList, List<string> TeachersNameList, List<string> TeachersRealNameList)
       {

           int i;
           List<string> SqlList = new List<string>();
           for (i = 0; i < length; i++)
           {
               string sql = "update GP_DeptManagement set Tag1='"+TeachersNameList[i]+"',Tag2='"+TeachersRealNameList[i]+"' where Id='"+IdList[i]+"'";
               SqlList.Add(sql);
           }

           int rows = db.ExecuteSqlTran(SqlList);

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

       #region DataTable GetTeachersDt(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       public DataTable GetTeachersDt(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from GP_DeptManagement ");
           strSql.Append(" where TrainingTime=@TrainingTime and TrainingBaseCode=@TrainingBaseCode and ProfessionalBaseCode=@ProfessionalBaseCode ");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = TrainingTime;
           parameters[1].Value = TrainingBaseCode;
           parameters[2].Value = ProfessionalBaseCode;

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
