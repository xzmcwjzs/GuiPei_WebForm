using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public class NeiKeOptionDAL
    {
       SqlHelper db = new SqlHelper();
       public List<NeiKeOptionModel> GetListByCode(string code)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 50 * from GP_NeiKeOption");
           strSql.Append(" where SubjectCode=@SubjectCode ORDER BY NEWID()");
           SqlParameter[] parameters = {
					new SqlParameter("@SubjectCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = code;

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           List<NeiKeOptionModel> list = null;
           if (dt.Rows.Count > 0)
           {
               NeiKeOptionModel model=null;
               list=new List<NeiKeOptionModel>();
               foreach (DataRow row in dt.Rows)
               {
                   model = new NeiKeOptionModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
           
       }



       #region DataRowToModel(DataRow row)
       public NeiKeOptionModel DataRowToModel(DataRow row)
       {
           NeiKeOptionModel model = new NeiKeOptionModel();
           if (row != null)
           {
               if (row["Id"] != null)
               {
                   model.Id = row["Id"].ToString();
               }
               if (row["SubjectName"] != null)
               {
                   model.SubjectName = row["SubjectName"].ToString();
               }
               if (row["SubjectCode"] != null)
               {
                   model.SubjectCode = row["SubjectCode"].ToString();
               }
               if (row["Question"] != null)
               {
                   model.Question = row["Question"].ToString();
               }
               if (row["QuestionType"] != null)
               {
                   model.QuestionType = row["QuestionType"].ToString();
               }
               if (row["OptionA"] != null)
               {
                   model.OptionA = row["OptionA"].ToString();
               }
               if (row["OptionB"] != null)
               {
                   model.OptionB = row["OptionB"].ToString();
               }
               if (row["OptionC"] != null)
               {
                   model.OptionC = row["OptionC"].ToString();
               }
               if (row["OptionD"] != null)
               {
                   model.OptionD = row["OptionD"].ToString();
               }
               if (row["OptionE"] != null)
               {
                   model.OptionE = row["OptionE"].ToString();
               }
               if (row["CorrectAnswer"] != null)
               {
                   model.CorrectAnswer = row["CorrectAnswer"].ToString();
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
