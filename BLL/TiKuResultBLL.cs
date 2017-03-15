using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class TiKuResultBLL
    {
       TiKuResultDAL dal = new TiKuResultDAL();
       public bool Add(TiKuResultModel model)
       {
           return dal.Add(model);
       }

       public List<TiKuResultModel> GetList(string StudentsName, string TrainingBaseCode, string SubjectCode)
       {
           return dal.GetList(StudentsName,TrainingBaseCode,SubjectCode);
       }
    }
}
