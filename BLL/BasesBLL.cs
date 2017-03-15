using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

namespace BLL
{
   public class BasesBLL
    {
        BasesDAL basesDAL = new BasesDAL();
        public DataTable GetDataTable(BasesModel model)
        {

            return basesDAL.GetDataTable(model);
        }
        public int UpdatePassword(string bases_name, string bases_password)
        {

            return basesDAL.UpdatePassword(bases_name, bases_password);

        }
    }
}
