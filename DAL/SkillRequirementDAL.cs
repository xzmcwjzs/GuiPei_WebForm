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
   public  class SkillRequirementDAL
    {
       SqlHelper db = new SqlHelper();

       #region GetList(string DeptCode)
       public List<SkillRequirementModel> GetList(string DeptCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select Id,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,DeptTime,IsRequired,SkillCode,SkillName,RequiredNum,MasterDegree,Tag1,Tag2,Tag3 from GP_SkillRequirement ");
           strSql.Append(" where SkillCode like @SkillCode");
           SqlParameter[] parameters = {
					new SqlParameter("@SkillCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = DeptCode + "%"; ;
           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           List<SkillRequirementModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<SkillRequirementModel>();
               SkillRequirementModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new SkillRequirementModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }

           }
           return list;
       } 
       #endregion

       #region DataRowToModel(DataRow row)
       public SkillRequirementModel DataRowToModel(DataRow row)
       {
           SkillRequirementModel model = new SkillRequirementModel();
           if (row != null)
           {
               if (row["Id"] != null)
               {
                   model.Id = row["Id"].ToString();
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
               if (row["IsRequired"] != null)
               {
                   model.IsRequired = row["IsRequired"].ToString();
               }
               if (row["SkillCode"] != null)
               {
                   model.SkillCode = row["SkillCode"].ToString();
               }
               if (row["SkillName"] != null)
               {
                   model.SkillName = row["SkillName"].ToString();
               }
               if (row["RequiredNum"] != null)
               {
                   model.RequiredNum = row["RequiredNum"].ToString();
               }
               if (row["MasterDegree"] != null)
               {
                   model.MasterDegree = row["MasterDegree"].ToString();
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
