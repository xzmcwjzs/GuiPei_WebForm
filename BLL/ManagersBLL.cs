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
   public class ManagersBLL
    {
        ManagersDAL managersDAL = new ManagersDAL();
        public DataTable GetDataTable(ManagersModel model)
        {

            return managersDAL.GetDataTable(model);
        }
        public int UpdatePassword(string managers_name, string managers_password)
        {

            return managersDAL.UpdatePassword(managers_name, managers_password);

        }
    }
}
