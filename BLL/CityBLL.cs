using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
   public class CityBLL
    {
       CityDAL cityDAL = new CityDAL();
       public List<Model.CityModel> getListModel(string father)
        {
            return cityDAL.getListModel(father);

        }
    }
}
