using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
   public class SchoolInformationBLL
    {
       SchoolInformationDAL schoolInformationDAL = new SchoolInformationDAL();
       public DataTable GetDtSchoolName()
       {
           return schoolInformationDAL.GetDtSchoolName();
       }
    }
}
