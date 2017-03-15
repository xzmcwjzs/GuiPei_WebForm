using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class TrainingTeachingActivitiesBLL
    {
        TrainingTeachingActivitiesDAL trainingTeachingActivitiesDAL = new TrainingTeachingActivitiesDAL();

        public bool Add(TrainingTeachingActivitiesModel model)
        {
            return trainingTeachingActivitiesDAL.Add(model);
        }
        public TrainingTeachingActivitiesModel GetModelById(string Id)
        {
            return trainingTeachingActivitiesDAL.GetModelById(Id);
 
        }
        public bool Update(TrainingTeachingActivitiesModel model, string id)
        {
            return trainingTeachingActivitiesDAL.Update(model, id);
        }

        #region 分页
        public List<Model.TrainingTeachingActivitiesModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
            string ActivityFormId, string MainSpeaker, string ClassHour, string ActivityDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<TrainingTeachingActivitiesModel> list = trainingTeachingActivitiesDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, ActivityFormId, MainSpeaker, ClassHour, ActivityDate, start, end);
            return list;
        }

        public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
            string ActivityFormId, string MainSpeaker, string ClassHour, string ActivityDate)
        {
            int recordCount = trainingTeachingActivitiesDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ActivityFormId, MainSpeaker, ClassHour, ActivityDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
             string ActivityFormId, string MainSpeaker, string ClassHour, string ActivityDate)
        {
            return trainingTeachingActivitiesDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ActivityFormId, MainSpeaker, ClassHour, ActivityDate);
        }
        #endregion
        #region Common分页
        public List<Model.TrainingTeachingActivitiesModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ActivityFormId, string MainSpeaker, string ClassHour, string ActivityDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<TrainingTeachingActivitiesModel> list = trainingTeachingActivitiesDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ActivityFormId, MainSpeaker, ClassHour, ActivityDate, start, end);
            return list;
        }

        public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ActivityFormId, string MainSpeaker, string ClassHour, string ActivityDate)
        {
            int recordCount = trainingTeachingActivitiesDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ActivityFormId, MainSpeaker, ClassHour, ActivityDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
             string ActivityFormId, string MainSpeaker, string ClassHour, string ActivityDate)
        {
            return trainingTeachingActivitiesDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ActivityFormId, MainSpeaker, ClassHour, ActivityDate);
        }
        #endregion

        public bool UpdateCheckByTeacher(TrainingTeachingActivitiesModel model)
        {
            return trainingTeachingActivitiesDAL.UpdateCheckByTeacher(model);
        }
    }
}
