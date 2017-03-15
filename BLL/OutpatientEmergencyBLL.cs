using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class OutpatientEmergencyBLL
    {
       OutpatientEmergencyDAL outpatientEmergencyDAL = new OutpatientEmergencyDAL();

       public bool Add(OutpatientEmergencyModel model)
       {
           return outpatientEmergencyDAL.Add(model);
       }

       public OutpatientEmergencyModel GetModelById(string Id)
       {
           return outpatientEmergencyDAL.GetModelById(Id);
       }

       public bool Update(OutpatientEmergencyModel model, string id)
       {
           return outpatientEmergencyDAL.Update(model, id);
       }

       #region 分页
       public List<Model.OutpatientEmergencyModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
           string RecordTypeId, string DiseaseName, string DiseaseNum,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<OutpatientEmergencyModel> list = outpatientEmergencyDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, RecordTypeId, DiseaseName, DiseaseNum, start, end);
           return list;
       }

       public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
           string RecordTypeId, string DiseaseName, string DiseaseNum)
       {
           int recordCount = outpatientEmergencyDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, RecordTypeId, DiseaseName, DiseaseNum);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string RecordTypeId, string DiseaseName, string DiseaseNum)
       {
           return outpatientEmergencyDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, RecordTypeId, DiseaseName, DiseaseNum);
       }
       #endregion

       #region Common分页
       public List<Model.OutpatientEmergencyModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string RecordTypeId, string DiseaseName, string DiseaseNum,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<OutpatientEmergencyModel> list = outpatientEmergencyDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, RecordTypeId, DiseaseName, DiseaseNum, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string RecordTypeId, string DiseaseName, string DiseaseNum)
       {
           int recordCount = outpatientEmergencyDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, RecordTypeId, DiseaseName, DiseaseNum);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string RecordTypeId, string DiseaseName, string DiseaseNum)
       {
           return outpatientEmergencyDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, RecordTypeId, DiseaseName, DiseaseNum);
       }
       #endregion

       public bool UpdateCheckByTeacher(OutpatientEmergencyModel model)
       {
           return outpatientEmergencyDAL.UpdateCheckByTeacher(model);
       }
    }
}
