using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
   public class ProvinceBLL
    {
       ProvinceDAL provinceDAL = new ProvinceDAL();
       public List<Model.ProvinceModel> getListModel()
       {
           return provinceDAL.getListModel();

       }
    }
}
