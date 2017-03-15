using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class JoinResearchRecordsBLL
    {

       JoinResearchRecordsDAL joinResearchRecordsDAL = new JoinResearchRecordsDAL();
       public bool Add(JoinResearchRecordsModel model)
       {
           return joinResearchRecordsDAL.Add(model);
       }
       public List<JoinResearchRecordsModel> GetListById(string Id)
       {
           return joinResearchRecordsDAL.GetListById(Id);
       }
       public bool Update(JoinResearchRecordsModel model)
       {
           return joinResearchRecordsDAL.Update(model);
       }
        #region 分页
        public List<Model.JoinResearchRecordsModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
            string ResearchTitle, string ResearchManager, string JoinRole, string ResearchDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<JoinResearchRecordsModel> list = joinResearchRecordsDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, ResearchTitle, ResearchManager, JoinRole,ResearchDate, start, end);
            return list;
        }

        public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
            string ResearchTitle, string ResearchManager, string JoinRole, string ResearchDate)
        {
            int recordCount = joinResearchRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ResearchTitle, ResearchManager, JoinRole, ResearchDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string ResearchTitle, string ResearchManager, string JoinRole, string ResearchDate)
        {
            return joinResearchRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ResearchTitle, ResearchManager, JoinRole, ResearchDate);
        }
        #endregion

        #region Common分页
        public List<Model.JoinResearchRecordsModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ResearchTitle, string ResearchManager, string JoinRole, string ResearchDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<JoinResearchRecordsModel> list = joinResearchRecordsDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, ResearchTitle, ResearchManager, JoinRole, ResearchDate, start, end);
            return list;
        }

        public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ResearchTitle, string ResearchManager, string JoinRole, string ResearchDate)
        {
            int recordCount = joinResearchRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, ResearchTitle, ResearchManager, JoinRole, ResearchDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ResearchTitle, string ResearchManager, string JoinRole, string ResearchDate)
        {
            return joinResearchRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, ResearchTitle, ResearchManager, JoinRole, ResearchDate);
        }
        #endregion

        public bool UpdateCheckByTeacher(JoinResearchRecordsModel model)
        {
            return joinResearchRecordsDAL.UpdateCheckByTeacher(model);
        }
    }
}
