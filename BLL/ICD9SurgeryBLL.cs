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
   public class ICD9SurgeryBLL
    {
        ICD9SurgeryDAL iCD9SurgeryDAL = new ICD9SurgeryDAL();
        public List<ICD9SurgeryModel> GetList()
        {
            return iCD9SurgeryDAL.GetList();
        }

        public DataTable GetDtSurgeryName()
        {
            return iCD9SurgeryDAL.GetDtSurgeryName();
        }
    }
}
