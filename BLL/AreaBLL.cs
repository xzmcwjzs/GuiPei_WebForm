using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public  class AreaBLL
    {
       AreaDAL areaDAL = new AreaDAL();
       public List<Model.AreaModel> getListModel(string father)
        {
            return areaDAL.getListModel(father);

        }
    }
}
