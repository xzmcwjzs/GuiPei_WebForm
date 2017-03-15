using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
   public class AdviceFeedbackBLL
    {
       AdviceFeedbackDAL adviceFeedbackDAL=new AdviceFeedbackDAL();

       public bool Add(AdviceFeedbackModel model)
       {
           return adviceFeedbackDAL.Add(model);
       }

       public bool Delete(string Id)
       {
           return adviceFeedbackDAL.Delete(Id);
       }

       public List<AdviceFeedbackModel> GetListById(string Id)
       {
           return adviceFeedbackDAL.GetListById(Id);
       }
       public bool Update(AdviceFeedbackModel model)
       {
           return adviceFeedbackDAL.Update(model);
       }

       #region 分页
        public List<Model.AdviceFeedbackModel> GetPagedList(string StudentsName, string TrainingBaseCode,string DeptName,
            string ManagerHandle, string RegisterDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<AdviceFeedbackModel> list = adviceFeedbackDAL.GetPagedList(StudentsName, TrainingBaseCode,DeptName,ManagerHandle,RegisterDate, start, end);
            return list;
        }

        public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
            string ManagerHandle, string RegisterDate)
        {
            int recordCount = adviceFeedbackDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ManagerHandle, RegisterDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string ManagerHandle, string RegisterDate)
        {
            return adviceFeedbackDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ManagerHandle, RegisterDate);
        }
        #endregion

        #region managers分页
        public List<Model.AdviceFeedbackModel> managersGetPagedList(string TrainingBaseCode, string StudentsRealName, string ProfessionalBaseName, string DeptName,
            string ManagerHandle, string RegisterDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<AdviceFeedbackModel> list = adviceFeedbackDAL.managersGetPagedList(TrainingBaseCode,StudentsRealName,ProfessionalBaseName, DeptName, ManagerHandle, RegisterDate, start, end);
            return list;
        }

        public int managersGetPageCount(int pageSize, string TrainingBaseCode, string StudentsRealName, string ProfessionalBaseName, string DeptName,
            string ManagerHandle, string RegisterDate)
        {
            int recordCount = adviceFeedbackDAL.managersGetRecordCount(TrainingBaseCode, StudentsRealName, ProfessionalBaseName, DeptName, ManagerHandle, RegisterDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int managersGetRecordCount(string TrainingBaseCode, string StudentsRealName, string ProfessionalBaseName, string DeptName,
            string ManagerHandle, string RegisterDate)
        {
            return adviceFeedbackDAL.managersGetRecordCount(TrainingBaseCode, StudentsRealName, ProfessionalBaseName, DeptName, ManagerHandle, RegisterDate);
        }
        #endregion

        public bool ManagerReply(AdviceFeedbackModel model)
        {
            return adviceFeedbackDAL.ManagerReply(model);
        }
    }
}
