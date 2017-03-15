using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    
   public class DiseaseRegisterBLL
    {
        DiseaseRegisterDAL diseaseRegisterDAL=new DiseaseRegisterDAL();

       public List<DiseaseRegisterModel> GetList(string dept_code)
       {

           return diseaseRegisterDAL.GetList(dept_code);
       }


    }
}
