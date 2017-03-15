using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

namespace BLL
{
   public class BasicRotaryViewBLL
    {
       BasicRotaryViewDAL basicRotaryViewDAL = new BasicRotaryViewDAL();
 //       public List<Model.BasicRotaryViewModel> GetPagedListBasic(string training_base_code,string dept_code,string instructor,string instructor_tag,string name,string  sex,string  minzu,string high_education,string  high_school,string  identity_type,string  send_unit,string  collaborative_unit,string  training_time,string  plan_training_time,
 //int pageIndex, int pageSize, out int rowCount, out int pageCount)
 //       {
 //           return basicRotaryViewDAL.GetPagedListBasic(training_base_code, dept_code, instructor, instructor_tag, name, sex, minzu, high_education, high_school, identity_type, send_unit, collaborative_unit, training_time, plan_training_time,
 //pageIndex, pageSize, out rowCount, out pageCount);
 //       }
       #region Basic分页
       public List<Model.BasicRotaryViewModel> GetPagedListBasic(string training_base_code, string dept_code, string instructor_tag,
            string name, string sex, string minzu, string high_education, string high_school, string identity_type, string send_unit, string collaborative_unit, string training_time, string plan_training_time,
        int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<BasicRotaryViewModel> list = basicRotaryViewDAL.GetPagedListBasic(training_base_code, dept_code, instructor_tag, name, sex, minzu, high_education, high_school, identity_type, send_unit, collaborative_unit, training_time, plan_training_time,start,end);
           return list;
       }

       public int GetPageCountBasic(int pageSize, string training_base_code, string dept_code, string instructor_tag,
            string name, string sex, string minzu, string high_education, string high_school, string identity_type, string send_unit, string collaborative_unit, string training_time, string plan_training_time)
       {
           int recordCount = basicRotaryViewDAL.GetRecordCountBasic(training_base_code, dept_code, instructor_tag, name, sex, minzu, high_education, high_school, identity_type, send_unit, collaborative_unit, training_time, plan_training_time);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int GetRecordCountBasic(string training_base_code, string dept_code, string instructor_tag,
            string name, string sex, string minzu, string high_education, string high_school, string identity_type, string send_unit, string collaborative_unit, string training_time, string plan_training_time)
       {
           return basicRotaryViewDAL.GetRecordCountBasic(training_base_code, dept_code, instructor_tag, name, sex, minzu, high_education, high_school, identity_type, send_unit, collaborative_unit, training_time, plan_training_time);
       }
       #endregion
        public List<Model.BasicRotaryViewModel> GetPagedListRotary(string training_base_code, string dept_code, string instructor, string instructor_tag,string name,string sex, string high_education,string identity_type, string send_unit, string collaborative_unit,string training_time,string plan_training_time,string rotary_begin_time,string rotary_end_time,string outdept_status,
          int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            return basicRotaryViewDAL.GetPagedListRotary(training_base_code, dept_code, instructor, instructor_tag,name, sex, high_education,identity_type, send_unit, collaborative_unit, training_time, plan_training_time,rotary_begin_time,rotary_end_time,outdept_status, pageIndex, pageSize, out rowCount, out pageCount);

        }

        public Model.BasicRotaryViewModel GetModelByGP_Students_Rotary_id(string GP_Students_Rotary_id)
        {
            return basicRotaryViewDAL.GetModelByGP_Students_Rotary_id(GP_Students_Rotary_id);
        }

        #region GetModelList
        public List<Model.BasicRotaryViewModel> GetModelListByGP_Students_Rotary_id(string strWhere)
        {
            DataSet ds = basicRotaryViewDAL.GetListByGP_Students_Rotary_id(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.BasicRotaryViewModel> DataTableToList(DataTable dt)
        {
            List<Model.BasicRotaryViewModel> modelList = new List<Model.BasicRotaryViewModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.BasicRotaryViewModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = basicRotaryViewDAL.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        } 
        #endregion

        #region Common分页
        public List<Model.BasicRotaryViewModel> CommonGetPagedList(string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
            string DeptName, string ProfessionalBaseName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string OutdeptStatus,
         int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<BasicRotaryViewModel> list = basicRotaryViewDAL.CommonGetPagedList(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime,DeptName,ProfessionalBaseName,TeachersRealName,RotaryBeginTime,RotaryEndTime,OutdeptStatus, start, end);
            return list;
        }

        public int CommonGetPageCount(int pageSize, string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
            string DeptName, string ProfessionalBaseName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string OutdeptStatus)
        {
            int recordCount = basicRotaryViewDAL.CommonGetRecordCount(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime, DeptName, ProfessionalBaseName, TeachersRealName, RotaryBeginTime, RotaryEndTime, OutdeptStatus);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int CommonGetRecordCount(string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
            string DeptName, string ProfessionalBaseName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string OutdeptStatus)
        {
            return basicRotaryViewDAL.CommonGetRecordCount(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime, DeptName, ProfessionalBaseName, TeachersRealName, RotaryBeginTime, RotaryEndTime, OutdeptStatus);
        }
        #endregion
    }
}
