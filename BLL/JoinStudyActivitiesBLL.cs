using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public  class JoinStudyActivitiesBLL
    {
       JoinStudyActivitiesDAL joinStudyActivitiesDAL = new JoinStudyActivitiesDAL();
       public bool Add(JoinStudyActivitiesModel model)
       {
           return joinStudyActivitiesDAL.Add(model);
       }

       public List<JoinStudyActivitiesModel> GetListById(string Id)
       {
           return joinStudyActivitiesDAL.GetListById(Id);
       }
       public bool Update(JoinStudyActivitiesModel model)
       {
           return joinStudyActivitiesDAL.Update(model);
       }
       #region 分页
       public List<Model.JoinStudyActivitiesModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
           string ActivityForm, string MainSpeaker, string ActivityDate,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<JoinStudyActivitiesModel> list = joinStudyActivitiesDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, ActivityForm, MainSpeaker, ActivityDate, start, end);
           return list;
       }

       public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
           string ActivityForm, string MainSpeaker, string ActivityDate)
       {
           int recordCount = joinStudyActivitiesDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ActivityForm, MainSpeaker, ActivityDate);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
           string ActivityForm, string MainSpeaker, string ActivityDate)
       {
           return joinStudyActivitiesDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ActivityForm, MainSpeaker, ActivityDate);
       }
       #endregion
       #region Common分页
       public List<Model.JoinStudyActivitiesModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string ActivityForm, string MainSpeaker, string ActivityDate,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<JoinStudyActivitiesModel> list = joinStudyActivitiesDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ActivityForm, MainSpeaker, ActivityDate, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string ActivityForm, string MainSpeaker, string ActivityDate)
       {
           int recordCount = joinStudyActivitiesDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ActivityForm, MainSpeaker, ActivityDate);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string ActivityForm, string MainSpeaker, string ActivityDate)
       {
           return joinStudyActivitiesDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ActivityForm, MainSpeaker, ActivityDate);
       }
       #endregion

       public bool UpdateCheckByTeacher(JoinStudyActivitiesModel model)
       {
           return joinStudyActivitiesDAL.UpdateCheckByTeacher(model);
       }

    }
}
