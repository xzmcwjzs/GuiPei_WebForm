using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class BigMedicalRecordsBLL
    {
       BigMedicalRecordsDAL bigMedicalRecordsDAL = new BigMedicalRecordsDAL();
       public bool Add(BigMedicalRecordsModel model)
       {
           return bigMedicalRecordsDAL.Add(model);
       }
       public List<BigMedicalRecordsModel> GetListById(string Id)
       {
           return bigMedicalRecordsDAL.GetListById(Id);
       }

     #region 分页
       public List<Model.BigMedicalRecordsModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
           string TeacherName, string RegisterDate, string PatientNo, string InhospitalNo,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<BigMedicalRecordsModel> list = bigMedicalRecordsDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, TeacherName, RegisterDate, PatientNo, InhospitalNo, start, end);
           return list;
       }

       public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
           string TeacherName, string RegisterDate, string PatientNo, string InhospitalNo)
       {
           int recordCount = bigMedicalRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, TeacherName, RegisterDate, PatientNo, InhospitalNo);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
           string TeacherName, string RegisterDate, string PatientNo, string InhospitalNo)
       {
           return bigMedicalRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, TeacherName, RegisterDate, PatientNo, InhospitalNo);
       }
       #endregion
       public bool Update(BigMedicalRecordsModel model)
       {
           return bigMedicalRecordsDAL.Update(model);
       }

       public bool UpdateRecordsStatus(BigMedicalRecordsModel model)
       {
           return bigMedicalRecordsDAL.UpdateRecordsStatus(model);
       }

       #region Common分页
       public List<Model.BigMedicalRecordsModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName, string DeptName,string TeachersRealName,
string PatientNo, string InhospitalNo,string PatientName,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<BigMedicalRecordsModel> list = bigMedicalRecordsDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, PatientNo, InhospitalNo,PatientName, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName, string DeptName,string TeachersRealName,
          string PatientNo, string InhospitalNo, string PatientName)
       {
           int recordCount = bigMedicalRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, PatientNo, InhospitalNo, PatientName);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string  DeptName,string TeachersRealName,
            string PatientNo, string InhospitalNo, string PatientName)
       {
           return bigMedicalRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, PatientNo, InhospitalNo, PatientName);
       }
       #endregion

       public bool UpdateCheckByTeacher(BigMedicalRecordsModel model)
       {
           return bigMedicalRecordsDAL.UpdateCheckByTeacher(model);
       }

       public bool UpdateRedirect(BigMedicalRecordsModel model)
       {
           return bigMedicalRecordsDAL.UpdateRedirect(model);
       }
    }
}
