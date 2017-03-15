using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
   public  class RescuePatientRecordsBLL
    {
       RescuePatientRecordsDAL rescurePatientRecordsDAL=new RescuePatientRecordsDAL();
       public bool Add(RescuePatientRecordsModel model)
       {
           return rescurePatientRecordsDAL.Add(model);
       }

       public RescuePatientRecordsModel GetModelById(string id)
       {
           return rescurePatientRecordsDAL.GetModelById(id);
       }

       public bool Update(RescuePatientRecordsModel model, string id)
       {
           return rescurePatientRecordsDAL.Update(model, id);
       }

       #region 分页
       public List<Model.RescuePatientRecordsModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
            string PatientName, string CaseId, string DiseaseName, string Condition,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<RescuePatientRecordsModel> list = rescurePatientRecordsDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, PatientName, CaseId, DiseaseName, Condition,start, end);
           return list;
       }

       public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
            string PatientName, string CaseId, string DiseaseName, string Condition)
       {
           int recordCount = rescurePatientRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, PatientName, CaseId, DiseaseName, Condition);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string PatientName, string CaseId, string DiseaseName, string Condition)
       {
           return rescurePatientRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, PatientName, CaseId, DiseaseName, Condition);
       }
       #endregion

       #region Common分页
       public List<Model.RescuePatientRecordsModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string PatientName, string CaseId, string DiseaseName, string Condition,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<RescuePatientRecordsModel> list = rescurePatientRecordsDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, DiseaseName, Condition, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string PatientName, string CaseId, string DiseaseName, string Condition)
       {
           int recordCount = rescurePatientRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, DiseaseName, Condition);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string PatientName, string CaseId, string DiseaseName, string Condition)
       {
           return rescurePatientRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, DiseaseName, Condition);
       }
       #endregion

       public bool UpdateCheckByTeacher(RescuePatientRecordsModel model)
       {
           return rescurePatientRecordsDAL.UpdateCheckByTeacher(model);
       }
    }
}
