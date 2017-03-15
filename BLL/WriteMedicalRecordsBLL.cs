using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class WriteMedicalRecordsBLL
    {
       WriteMedicalRecordsDAL writeMedicalRecordsDAL = new WriteMedicalRecordsDAL();

       public bool Add(WriteMedicalRecordsModel model)
       {
           return writeMedicalRecordsDAL.Add(model);
       }
       public WriteMedicalRecordsModel GetModelById(string id)
       {
           return writeMedicalRecordsDAL.GetModelById(id);
       }
       public bool Update(WriteMedicalRecordsModel model, string id)
       {
           return writeMedicalRecordsDAL.Update(model, id);
       }
       #region 分页
       public List<Model.WriteMedicalRecordsModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
            string PatientName, string CaseId, string IsBigCase,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<WriteMedicalRecordsModel> list = writeMedicalRecordsDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, PatientName, CaseId, IsBigCase, start, end);
           return list;
       }

       public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
            string PatientName, string CaseId, string IsBigCase)
       {
           int recordCount = writeMedicalRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, PatientName, CaseId, IsBigCase);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string PatientName, string CaseId, string IsBigCase)
       {
           return writeMedicalRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, PatientName, CaseId, IsBigCase);
       }
       #endregion

       #region Common分页
       public List<Model.WriteMedicalRecordsModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string PatientName, string CaseId, string IsBigCase,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<WriteMedicalRecordsModel> list = writeMedicalRecordsDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, IsBigCase, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string PatientName, string CaseId, string IsBigCase)
       {
           int recordCount = writeMedicalRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, IsBigCase);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string PatientName, string CaseId, string IsBigCase)
       {
           return writeMedicalRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, IsBigCase);
       }
       #endregion

       public bool UpdateCheckByTeacher(WriteMedicalRecordsModel model)
       {
           return writeMedicalRecordsDAL.UpdateCheckByTeacher(model);
       }
    }
}
