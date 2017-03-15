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
   public  class ICD9SurgeryDAL
    {
       SqlHelper db = new SqlHelper();
       #region GetList(string Id)
       public List<ICD9SurgeryModel> GetList()
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  Id,ICD9,SurgeryName,Property from GP_ICD9Surgery ");


           DataTable dt = db.RunDataTable(strSql.ToString());
           List<ICD9SurgeryModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<ICD9SurgeryModel>();
               ICD9SurgeryModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new ICD9SurgeryModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }

           }
           return list;
       } 
       #endregion

       public DataTable GetDtSurgeryName()
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select SurgeryName from GP_ICD9Surgery ");


           DataTable dt = db.RunDataTable(strSql.ToString());
           return dt;
       } 

         #region DataRowToModel(DataRow row)
        public ICD9SurgeryModel DataRowToModel(DataRow row)
        {
            ICD9SurgeryModel model = new ICD9SurgeryModel();
            if (row != null)
            {
                if (row["Id"] != null)
                {
                    model.Id = row["Id"].ToString();
                }
                if (row["ICD9"] != null)
                {
                    model.ICD9 = row["ICD9"].ToString();
                }
                if (row["SurgeryName"] != null)
                {
                    model.SurgeryName = row["SurgeryName"].ToString();
                }
                if (row["Property"] != null)
                {
                    model.Property = row["Property"].ToString();
                }
            }
            return model;
        } 
        #endregion
    }

}
