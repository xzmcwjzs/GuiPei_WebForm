using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class RotaryInformationJoinBLL
    {
       RotaryInformationJoinDAL dal = new RotaryInformationJoinDAL();

        #region 分页
        public List<Model.RotaryInformationJoinModel> GetPagedList(string training_base_code, string dept_code, string teachers_name,
             string name, string sex,  string high_education, string identity_type, string send_unit, string collaborative_unit, string training_time, string plan_training_time,string rotary_begin_time,string rotary_end_time,string outdept_status,
         int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<RotaryInformationJoinModel> list = dal.GetPagedList(training_base_code, dept_code, teachers_name, name, sex, high_education, identity_type, send_unit, collaborative_unit, training_time, plan_training_time,rotary_begin_time,rotary_end_time,outdept_status, start, end);
            return list;
        }

        public int GetPageCount(int pageSize, string training_base_code, string dept_code, string teachers_name,
             string name, string sex, string high_education, string identity_type, string send_unit, string collaborative_unit, string training_time, string plan_training_time, string rotary_begin_time, string rotary_end_time, string outdept_status)
        {
            int recordCount = dal.GetRecordCount(training_base_code, dept_code, teachers_name, name, sex, high_education, identity_type, send_unit, collaborative_unit, training_time, plan_training_time, rotary_begin_time, rotary_end_time, outdept_status);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int GetRecordCount(string training_base_code, string dept_code, string teachers_name,
             string name, string sex, string high_education, string identity_type, string send_unit, string collaborative_unit, string training_time, string plan_training_time, string rotary_begin_time, string rotary_end_time, string outdept_status)
        {
            return dal.GetRecordCount(training_base_code, dept_code, teachers_name, name, sex, high_education, identity_type, send_unit, collaborative_unit, training_time, plan_training_time, rotary_begin_time, rotary_end_time, outdept_status);
        }
        #endregion

        public Model.RotaryInformationJoinModel GetModelById(string Id)
        {
            return dal.GetModelById(Id);
        }


        #region Common分页
        public List<Model.RotaryInformationJoinModel> CommonGetPagedList(string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
            string DeptName, string ProfessionalBaseName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string OutdeptStatus,
         int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<RotaryInformationJoinModel> list = dal.CommonGetPagedList(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime, DeptName, ProfessionalBaseName, TeachersRealName, RotaryBeginTime, RotaryEndTime, OutdeptStatus, start, end);
            return list;
        }

        public int CommonGetPageCount(int pageSize, string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
            string DeptName, string ProfessionalBaseName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string OutdeptStatus)
        {
            int recordCount = dal.CommonGetRecordCount(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime, DeptName, ProfessionalBaseName, TeachersRealName, RotaryBeginTime, RotaryEndTime, OutdeptStatus);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int CommonGetRecordCount(string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
            string DeptName, string ProfessionalBaseName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string OutdeptStatus)
        {
            return dal.CommonGetRecordCount(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime, DeptName, ProfessionalBaseName, TeachersRealName, RotaryBeginTime, RotaryEndTime, OutdeptStatus);
        }
        #endregion
    }
}
