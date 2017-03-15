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
   public class ReleaseNewsDAL
    {
       SqlHelper db = new SqlHelper();
       #region Add(ReleaseNewsModel model)
       public bool Add(ReleaseNewsModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_ReleaseNews(");
           strSql.Append("Id,TrainingBaseCode,TrainingBaseName,ManagersName,ManagersRealName,Writor,RegisterDate,NewsTitle,NewsContent,FilePath,FileName,Students,Teachers,Bases,Tag1,Tag2,Tag3)");
           strSql.Append(" values (");
           strSql.Append("@Id,@TrainingBaseCode,@TrainingBaseName,@ManagersName,@ManagersRealName,@Writor,@RegisterDate,@NewsTitle,@NewsContent,@FilePath,@FileName,@Students,@Teachers,@Bases,@Tag1,@Tag2,@Tag3)");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@ManagersName", SqlDbType.NVarChar,50),
					new SqlParameter("@ManagersRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Writor", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisterDate", SqlDbType.NVarChar,50),
					new SqlParameter("@NewsTitle", SqlDbType.NVarChar,500),
					new SqlParameter("@NewsContent", SqlDbType.NVarChar,2000),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,500),
					new SqlParameter("@FileName", SqlDbType.NVarChar,500),
					new SqlParameter("@Students", SqlDbType.NVarChar,50),
					new SqlParameter("@Teachers", SqlDbType.NVarChar,50),
					new SqlParameter("@Bases", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag1", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag2", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag3", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.Id;
           parameters[1].Value = model.TrainingBaseCode;
           parameters[2].Value = model.TrainingBaseName;
           parameters[3].Value = model.ManagersName;
           parameters[4].Value = model.ManagersRealName;
           parameters[5].Value = model.Writor;
           parameters[6].Value = model.RegisterDate;
           parameters[7].Value = model.NewsTitle;
           parameters[8].Value = model.NewsContent;
           parameters[9].Value = model.FilePath;
           parameters[10].Value = model.FileName;
           parameters[11].Value = model.Students;
           parameters[12].Value = model.Teachers;
           parameters[13].Value = model.Bases;
           parameters[14].Value = model.Tag1;
           parameters[15].Value = model.Tag2;
           parameters[16].Value = model.Tag3;

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

       #region MyRegion
       public List<ReleaseNewsModel> GetListById(string Id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 Id,TrainingBaseCode,TrainingBaseName,ManagersName,ManagersRealName,Writor,RegisterDate,NewsTitle,NewsContent,FilePath,FileName,Students,Teachers,Bases,Tag1,Tag2,Tag3 from GP_ReleaseNews ");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Id;

           List<ReleaseNewsModel> list = null;
           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           if (dt.Rows.Count > 0)
           {
               list = new List<ReleaseNewsModel>();
               ReleaseNewsModel model=null;
               foreach(DataRow row in dt.Rows){
                   model=new ReleaseNewsModel();
                   model=DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       } 
       #endregion
       #region DataRowToModel(DataRow row)
       public ReleaseNewsModel DataRowToModel(DataRow row)
       {
           ReleaseNewsModel model = new ReleaseNewsModel();
           if (row != null)
           {
               if (row["Id"] != null)
               {
                   model.Id = row["Id"].ToString();
               }
               if (row["TrainingBaseCode"] != null)
               {
                   model.TrainingBaseCode = row["TrainingBaseCode"].ToString();
               }
               if (row["TrainingBaseName"] != null)
               {
                   model.TrainingBaseName = row["TrainingBaseName"].ToString();
               }
               if (row["ManagersName"] != null)
               {
                   model.ManagersName = row["ManagersName"].ToString();
               }
               if (row["ManagersRealName"] != null)
               {
                   model.ManagersRealName = row["ManagersRealName"].ToString();
               }
               if (row["Writor"] != null)
               {
                   model.Writor = row["Writor"].ToString();
               }
               if (row["RegisterDate"] != null)
               {
                   model.RegisterDate = row["RegisterDate"].ToString();
               }
               if (row["NewsTitle"] != null)
               {
                   model.NewsTitle = row["NewsTitle"].ToString();
               }
               if (row["NewsContent"] != null)
               {
                   //model.NewsContent =Common.CommonFunc2.UbbToHtml(row["NewsContent"].ToString());
                  model.NewsContent = row["NewsContent"].ToString();
               }
               if (row["FilePath"] != null)
               {
                   model.FilePath = row["FilePath"].ToString();
               }
               if (row["FileName"] != null)
               {
                   model.FileName = row["FileName"].ToString();
               }
               if (row["Students"] != null)
               {
                   model.Students = row["Students"].ToString();
               }
               if (row["Teachers"] != null)
               {
                   model.Teachers = row["Teachers"].ToString();
               }
               if (row["Bases"] != null)
               {
                   model.Bases = row["Bases"].ToString();
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

       #region 分页
       public List<Model.ReleaseNewsModel> GetPagedList(string ManagersName, string TrainingBaseCode, 
           string NewsTitle, string RegisteDate,string Type,
       int start, int end)
       {

           string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_ReleaseNews where TrainingBaseCode like '%" + TrainingBaseCode + "%'";

           if (!string.IsNullOrEmpty(ManagersName))
           {
               sql += "and ManagersName = '" + ManagersName + "'";
           }

           if (!string.IsNullOrEmpty(NewsTitle))
           {
               sql += "and NewsTitle like '%" + NewsTitle + "%'";
           }
           if (!string.IsNullOrEmpty(RegisteDate))
           {
               sql += "and RegisterDate like '%" + RegisteDate + "%'";
           }
           if (Type == "Students")
           {
                sql += "and Students = 1";
           }
           if (Type == "Bases")
           {
               sql += "and Bases = 1";
           }
           if (Type == "Teachers")
           {
               sql += "and Teachers = 1";
           }
               
          
           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<ReleaseNewsModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<ReleaseNewsModel>();
               ReleaseNewsModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new ReleaseNewsModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int GetRecordCount(string ManagersName, string TrainingBaseCode,
           string NewsTitle, string RegisteDate, string Type)
       {
           string sql = "select count(*) from GP_ReleaseNews where TrainingBaseCode like '%" + TrainingBaseCode + "%'";
           if (!string.IsNullOrEmpty(ManagersName))
           {
               sql += "and ManagersName = '" + ManagersName + "'";
           }
           if (!string.IsNullOrEmpty(NewsTitle))
           {
               sql += "and NewsTitle like '%" + NewsTitle + "%'";
           }
           if (!string.IsNullOrEmpty(RegisteDate))
           {
               sql += "and RegisterDate like '%" + RegisteDate + "%'";
           }
           if (Type == "Students")
           {
               sql += "and Students = 1";
           }
           if (Type == "Bases")
           {
               sql += "and Bases = 1";
           }
           if (Type == "Teachers")
           {
               sql += "and Teachers = 1";
           }
           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region Update(ReleaseNewsModel model)
       public bool Update(ReleaseNewsModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_ReleaseNews set ");
           strSql.Append("Writor=@Writor,");
           strSql.Append("RegisterDate=@RegisterDate,");
           strSql.Append("NewsTitle=@NewsTitle,");
           strSql.Append("NewsContent=@NewsContent,");
           strSql.Append("Students=@Students,");
           strSql.Append("Teachers=@Teachers,");
           strSql.Append("Bases=@Bases");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Writor", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisterDate", SqlDbType.NVarChar,50),
					new SqlParameter("@NewsTitle", SqlDbType.NVarChar,500),
					new SqlParameter("@NewsContent", SqlDbType.NVarChar,2000),
					new SqlParameter("@Students", SqlDbType.NVarChar,50),
					new SqlParameter("@Teachers", SqlDbType.NVarChar,50),
					new SqlParameter("@Bases", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.Writor;
           parameters[1].Value = model.RegisterDate;
           parameters[2].Value = model.NewsTitle;
           parameters[3].Value = model.NewsContent;
           parameters[4].Value = model.Students;
           parameters[5].Value = model.Teachers;
           parameters[6].Value = model.Bases;
           parameters[7].Value = model.Id;

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
