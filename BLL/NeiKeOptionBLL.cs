using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{

   public class NeiKeOptionBLL
    {
       NeiKeOptionDAL dal = new NeiKeOptionDAL();
       public List<NeiKeOptionModel> GetListByCode(string code)
       {
           return dal.GetListByCode(code);
       }
    }
}
