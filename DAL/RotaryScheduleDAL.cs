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
   public class RotaryScheduleDAL
    {
       SqlHelper db = new SqlHelper();

       #region Add
       public bool Add(int SelectLength, RotaryScheduleModel model, List<string> BeginTimeList, List<string> EndTimeList, List<string> DaysList, List<string> DeptCodeList, List<string> DeptNameList, List<string> SchemeOrder)
       {

           int i;
           List<string> SqlList = new List<string>();
           for (i = 0; i < SelectLength; i++)
           {

               string sql = "insert into GP_RotarySchedule(Id,ManagersName,ManagersRealName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,BeginTimeList,EndTimeList,DaysList,DeptCodeList,DeptNameList,SchemeOrder,RotaryBeginTime,RotaryEndTime,TotalRealTime,TrainingTime,Tag1,Tag2,Tag3) values(" +
                                  "'" + Guid.NewGuid().ToString() + "','" + model.ManagersName + "','" + model.ManagersRealName + "','" + model.TrainingBaseCode + "','" + model.TrainingBaseName + "'" +
                              ",'" + model.ProfessionalBaseCode + "','" + model.ProfessionalBaseName + "','" + BeginTimeList[i] + "','" + EndTimeList[i] + "','" + DaysList[i] + "'" +
                              ",'" + DeptCodeList[i] + "','" + DeptNameList[i] + "','" + SchemeOrder[i] + "','" + model.RotaryBeginTime + "','" + model.RotaryEndTime + "','" + model.TotalRealTime + "','" + model.TrainingTime + "'" +
                              ",'" + model.Tag1 + "','" + model.Tag2 + "','" + model.Tag3 + "')";
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

       #region Delete(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       public bool Delete(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from GP_RotarySchedule ");
           strSql.Append(" where TrainingTime like @TrainingTime and TrainingBaseCode=@TrainingBaseCode and ProfessionalBaseCode=@ProfessionalBaseCode ");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = TrainingTime+ "%";
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

       #region GetModel(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       public RotaryScheduleModel GetModel(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from GP_RotarySchedule ");
           strSql.Append(" where TrainingTime like @TrainingTime and TrainingBaseCode=@TrainingBaseCode and ProfessionalBaseCode=@ProfessionalBaseCode ");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = TrainingTime + "%";
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

       #region DataRowToModel(DataRow row)
       public RotaryScheduleModel DataRowToModel(DataRow row)
       {
           RotaryScheduleModel model = new RotaryScheduleModel();
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
               if (row["BeginTimeList"] != null)
               {
                   model.BeginTimeList = row["BeginTimeList"].ToString();
               }
               if (row["EndTimeList"] != null)
               {
                   model.EndTimeList = row["EndTimeList"].ToString();
               }
               if (row["DaysList"] != null)
               {
                   model.DaysList = row["DaysList"].ToString();
               }
               if (row["DeptCodeList"] != null)
               {
                   model.DeptCodeList = row["DeptCodeList"].ToString();
               }
               if (row["DeptNameList"] != null)
               {
                   model.DeptNameList = row["DeptNameList"].ToString();
               }
               if (row["SchemeOrder"] != null)
               {
                   model.SchemeOrder = row["SchemeOrder"].ToString();
               }
               if (row["RotaryBeginTime"] != null)
               {
                   model.RotaryBeginTime = row["RotaryBeginTime"].ToString();
               }
               if (row["RotaryEndTime"] != null)
               {
                   model.RotaryEndTime = row["RotaryEndTime"].ToString();
               }
               if (row["TotalRealTime"] != null)
               {
                   model.TotalRealTime = row["TotalRealTime"].ToString();
               }
               if (row["TrainingTime"] != null)
               {
                   model.TrainingTime = row["TrainingTime"].ToString();
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



       #region GetSchemeList(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       public List<RotaryScheduleModel> GetSchemeList(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from GP_RotarySchedule ");
           strSql.Append(" where TrainingTime like @TrainingTime and TrainingBaseCode=@TrainingBaseCode and ProfessionalBaseCode=@ProfessionalBaseCode order by SchemeOrder asc");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = TrainingTime + "%";
           parameters[1].Value = TrainingBaseCode;
           parameters[2].Value = ProfessionalBaseCode;

           List<RotaryScheduleModel> list = null;
           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           if (dt.Rows.Count > 0)
           {
               list = new List<RotaryScheduleModel>();
               RotaryScheduleModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new RotaryScheduleModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;

       } 
       #endregion

       #region  UpdateStudents(RotaryScheduleModel model)
       public bool UpdateStudents(RotaryScheduleModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_RotarySchedule set ");
           strSql.Append("Tag1=@Tag1,");
           strSql.Append("Tag2=@Tag2");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Tag1", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag2", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.Tag1;
           parameters[1].Value = model.Tag2;
           parameters[2].Value = model.Id;

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
       public List<Model.RotaryScheduleModel> GetPagedList(string TrainingBaseCode, string ProfessionalBaseCode, string TrainingTime,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by TrainingTime desc,SchemeOrder asc) as num,* from GP_RotarySchedule where TrainingBaseCode like '%" + TrainingBaseCode + "%'";

           sql += "and ProfessionalBaseCode like '%" + ProfessionalBaseCode + "%' and TrainingTime like '%"+TrainingTime+"%')as t where t.num>=@start and t.num<=@end";
          
           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<RotaryScheduleModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<RotaryScheduleModel>();
               RotaryScheduleModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new RotaryScheduleModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int GetRecordCount(string TrainingBaseCode, string ProfessionalBaseCode, string TrainingTime)
       {
           string sql = "select count(*) from GP_RotarySchedule where TrainingBaseCode like '%" + TrainingBaseCode + "%' and ProfessionalBaseCode like '%" + ProfessionalBaseCode + "%' and TrainingTime like '%" + TrainingTime + "%'";
           
           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region GetDtByTTP(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       public DataTable GetDtByTTP(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from GP_RotarySchedule ");
           strSql.Append(" where TrainingTime = @TrainingTime and TrainingBaseCode=@TrainingBaseCode and ProfessionalBaseCode=@ProfessionalBaseCode ");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = TrainingTime;
           parameters[1].Value = TrainingBaseCode;
           parameters[2].Value = ProfessionalBaseCode;

           DeptManagementModel model = new DeptManagementModel();
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
