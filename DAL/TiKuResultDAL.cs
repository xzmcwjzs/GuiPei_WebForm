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
   public class TiKuResultDAL
    {
       SqlHelper db = new SqlHelper();
       #region Add(TiKuResultModel model)
       public bool Add(TiKuResultModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_TiKuResult(");
           strSql.Append("Id,StudentsName,StudentsRealName,TrainingBaseCode,TrainingBaseName,SubjectName,SubjectCode,TotalScore,TotalNum,UndoNum,CorrectNum,ErrorNum,RegisterDate,Tag1,Tag2,Tag3)");
           strSql.Append(" values (");
           strSql.Append("@Id,@StudentsName,@StudentsRealName,@TrainingBaseCode,@TrainingBaseName,@SubjectName,@SubjectCode,@TotalScore,@TotalNum,@UndoNum,@CorrectNum,@ErrorNum,@RegisterDate,@Tag1,@Tag2,@Tag3)");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentsName", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentsRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@SubjectName", SqlDbType.NVarChar,50),
					new SqlParameter("@SubjectCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TotalScore", SqlDbType.NVarChar,50),
					new SqlParameter("@TotalNum", SqlDbType.NVarChar,50),
					new SqlParameter("@UndoNum", SqlDbType.NVarChar,50),
					new SqlParameter("@CorrectNum", SqlDbType.NVarChar,50),
					new SqlParameter("@ErrorNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisterDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag1", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag2", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag3", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.Id;
           parameters[1].Value = model.StudentsName;
           parameters[2].Value = model.StudentsRealName;
           parameters[3].Value = model.TrainingBaseCode;
           parameters[4].Value = model.TrainingBaseName;
           parameters[5].Value = model.SubjectName;
           parameters[6].Value = model.SubjectCode;
           parameters[7].Value = model.TotalScore;
           parameters[8].Value = model.TotalNum;
           parameters[9].Value = model.UndoNum;
           parameters[10].Value = model.CorrectNum;
           parameters[11].Value = model.ErrorNum;
           parameters[12].Value = model.RegisterDate;
           parameters[13].Value = model.Tag1;
           parameters[14].Value = model.Tag2;
           parameters[15].Value = model.Tag3;

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

       #region GetList(string StudentsName, string TrainingBaseCode, string SubjectCode)
       public List<TiKuResultModel> GetList(string StudentsName, string TrainingBaseCode, string SubjectCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 10 * from GP_TiKuResult ");
           strSql.Append(" where StudentsName=@StudentsName and TrainingBaseCode like @TrainingBaseCode and SubjectCode=@SubjectCode order by RegisterDate desc");
           SqlParameter[] parameters = {
					new SqlParameter("@StudentsName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@SubjectCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = StudentsName;
           parameters[1].Value ='%'+ TrainingBaseCode+'%';
           parameters[2].Value = SubjectCode;

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);

           List<TiKuResultModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<TiKuResultModel>();
               TiKuResultModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new TiKuResultModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       } 
       #endregion



       #region DataRowToModel(DataRow row)
       public TiKuResultModel DataRowToModel(DataRow row)
       {
           TiKuResultModel model = new TiKuResultModel();
           if (row != null)
           {
               if (row["Id"] != null)
               {
                   model.Id = row["Id"].ToString();
               }
               if (row["StudentsName"] != null)
               {
                   model.StudentsName = row["StudentsName"].ToString();
               }
               if (row["StudentsRealName"] != null)
               {
                   model.StudentsRealName = row["StudentsRealName"].ToString();
               }
               if (row["TrainingBaseCode"] != null)
               {
                   model.TrainingBaseCode = row["TrainingBaseCode"].ToString();
               }
               if (row["TrainingBaseName"] != null)
               {
                   model.TrainingBaseName = row["TrainingBaseName"].ToString();
               }
               if (row["SubjectName"] != null)
               {
                   model.SubjectName = row["SubjectName"].ToString();
               }
               if (row["SubjectCode"] != null)
               {
                   model.SubjectCode = row["SubjectCode"].ToString();
               }
               if (row["TotalScore"] != null)
               {
                   model.TotalScore = row["TotalScore"].ToString();
               }
               if (row["TotalNum"] != null)
               {
                   model.TotalNum = row["TotalNum"].ToString();
               }
               if (row["UndoNum"] != null)
               {
                   model.UndoNum = row["UndoNum"].ToString();
               }
               if (row["CorrectNum"] != null)
               {
                   model.CorrectNum = row["CorrectNum"].ToString();
               }
               if (row["ErrorNum"] != null)
               {
                   model.ErrorNum = row["ErrorNum"].ToString();
               }
               if (row["RegisterDate"] != null)
               {
                   model.RegisterDate = row["RegisterDate"].ToString();
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
    }
}
