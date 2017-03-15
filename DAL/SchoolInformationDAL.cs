using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class SchoolInformationDAL
    {
       SqlHelper db = new SqlHelper();
       #region GetDtSchoolName()
       public DataTable GetDtSchoolName()
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select SchoolName from GP_SchoolInformation");


           DataTable dt = db.RunDataTable(strSql.ToString());
           return dt;
       }  
       #endregion
    }
}
