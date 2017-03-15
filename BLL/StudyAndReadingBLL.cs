using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class StudyAndReadingBLL
    {
       StudyAndReadingDAL studyAndReadingDAL = new StudyAndReadingDAL();

       public bool Add(StudyAndReadingModel model)
       {

           return studyAndReadingDAL.Add(model);
       }
       public StudyAndReadingModel GetModelById(string Id)
       {
           return studyAndReadingDAL.GetModelById(Id);
       }
       public bool Update(StudyAndReadingModel model, string id)
       {
           return studyAndReadingDAL.Update(model, id);
       }
       public List<StudyAndReadingModel> GetListById(string Id)
       {
           return studyAndReadingDAL.GetListById(Id);
       }
       #region 分页
       public List<Model.StudyAndReadingModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
           string ActivityForm, string ActivityDate, string LanguageType, string SuperiorDoctor,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<StudyAndReadingModel> list = studyAndReadingDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, ActivityForm, ActivityDate, LanguageType, SuperiorDoctor, start, end);
           return list;
       }

       public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
           string ActivityForm, string ActivityDate, string LanguageType, string SuperiorDoctor)
       {
           int recordCount = studyAndReadingDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ActivityForm, ActivityDate, LanguageType, SuperiorDoctor);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string ActivityForm, string ActivityDate, string LanguageType, string SuperiorDoctor)
       {
           return studyAndReadingDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ActivityForm, ActivityDate, LanguageType, SuperiorDoctor);
       }
       #endregion

       #region Common分页
       public List<Model.StudyAndReadingModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string ActivityForm, string ActivityDate, string LanguageType, string SuperiorDoctor,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<StudyAndReadingModel> list = studyAndReadingDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ActivityForm, ActivityDate, LanguageType, SuperiorDoctor, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string ActivityForm, string ActivityDate, string LanguageType, string SuperiorDoctor)
       {
           int recordCount = studyAndReadingDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ActivityForm, ActivityDate, LanguageType, SuperiorDoctor);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ActivityForm, string ActivityDate, string LanguageType, string SuperiorDoctor)
       {
           return studyAndReadingDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ActivityForm, ActivityDate, LanguageType, SuperiorDoctor);
       }
       #endregion

       public bool UpdateCheckByTeacher(StudyAndReadingModel model)
       {
           return studyAndReadingDAL.UpdateCheckByTeacher(model);
       }
    }
}
