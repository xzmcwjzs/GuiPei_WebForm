using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using Model;

namespace BLL
{
   public class ProfessionalBaseDeptBLL
    {
       ProfessionalBaseDeptDAL professionalBaseDeptDAL = new ProfessionalBaseDeptDAL();
       public DataTable GetDeptDataTableByCode(string professional_base_code)
       {

           return professionalBaseDeptDAL.GetDeptDataTableByCode(professional_base_code);
       }

       public List<ProfessionalBaseDeptModel> GetDeptList(string professional_base_code)
       {
           return professionalBaseDeptDAL.GetDeptList(professional_base_code);
       }

       public DataTable GetDt()
       {
           return professionalBaseDeptDAL.GetDt();
       }
    }
}
