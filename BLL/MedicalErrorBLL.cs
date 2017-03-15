using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
  public  class MedicalErrorBLL
    {
      MedicalErrorDAL medicalErrorDAL=new MedicalErrorDAL();

      public bool Delete(string Id)
      {
          return medicalErrorDAL.Delete(Id);
      }

      public bool Add(MedicalErrorModel model)
      {
          return medicalErrorDAL.Add(model);
      }

      public List<MedicalErrorModel> GetListById(string Id)
      {
          return medicalErrorDAL.GetListById(Id);
      }

      public bool Update(MedicalErrorModel model)
      {
          return medicalErrorDAL.Update(model);
      }

      #region 分页
        public List<Model.MedicalErrorModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
            string ErrorCategory, string ErrorDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<MedicalErrorModel> list = medicalErrorDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, ErrorCategory,ErrorDate, start, end);
            return list;
        }

        public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
            string ErrorCategory, string ErrorDate)
        {
            int recordCount = medicalErrorDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ErrorCategory, ErrorDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string ErrorCategory, string ErrorDate)
        {
            return medicalErrorDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ErrorCategory, ErrorDate);
        }
        #endregion

        #region Common分页
        public List<Model.MedicalErrorModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ErrorCategory, string ErrorDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<MedicalErrorModel> list = medicalErrorDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ErrorCategory, ErrorDate, start, end);
            return list;
        }

        public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ErrorCategory, string ErrorDate)
        {
            int recordCount = medicalErrorDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ErrorCategory, ErrorDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ErrorCategory, string ErrorDate)
        {
            return medicalErrorDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ErrorCategory, ErrorDate);
        }
        #endregion

        public bool UpdateCheckByTeacher(MedicalErrorModel model)
        {
            return medicalErrorDAL.UpdateCheckByTeacher(model);
        }
    }
}
