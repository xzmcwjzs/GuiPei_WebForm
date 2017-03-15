using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    
  public  class TeachersAppointInformationBLL
    {
      TeachersAppointInformationDAL teachersAppointInformationDAL = new TeachersAppointInformationDAL();
      public bool Insert(TeachersAppointInformationModel model)
      {
          return teachersAppointInformationDAL.Insert(model);

      }

      public bool Update(TeachersAppointInformationModel model)
      {
          return teachersAppointInformationDAL.Update(model);
       }

      public TeachersAppointInformationModel SelectModelById(string id)
      {
          return teachersAppointInformationDAL.SelectModelById(id);
      }

        #region GetPageList
      public List<TeachersAppointInformationModel> GetPageList(string training_base_code, string dept_code, string teachers_name, string teachers_real_name, string appoint_begin_time, string appoint_end_time, string is_pass, int pageIndex, int pageSize, out int rowCount, out int pageCount)
       {
           DataTable dt = teachersAppointInformationDAL.GetPageList(training_base_code, dept_code, teachers_name, teachers_real_name, appoint_begin_time, appoint_end_time, is_pass, pageIndex, pageSize, out rowCount, out pageCount);
           return DataTableToList(dt);
       }

      public List<TeachersAppointInformationModel> DataTableToList(DataTable dt)
       {
           List<TeachersAppointInformationModel> modelList = new List<TeachersAppointInformationModel>();
           int rowsCount = dt.Rows.Count;
           if (rowsCount > 0)
           {
               TeachersAppointInformationModel model;
               for (int n = 0; n < rowsCount; n++)
               {
                   model = teachersAppointInformationDAL.DataRowToModel(dt.Rows[n]);
                   if (model != null)
                   {
                       modelList.Add(model);
                   }
               }
           }
           return modelList;
       } 
        #endregion

      #region GetBasesPagedList
      public List<Model.TeachersAppointInformationModel> GetBasesPagedList(string BasesName, string TrainingBaseCode, string ProfessionalBaseCode,
           string AppointBeginTime, string AppointEndTime, string IsPass,
      int pageIndex, int pageSize)
      {
          int start = (pageIndex - 1) * pageSize + 1;
          int end = pageIndex * pageSize;
          List<TeachersAppointInformationModel> list = teachersAppointInformationDAL.GetBasesPagedList(BasesName, TrainingBaseCode, ProfessionalBaseCode, AppointBeginTime, AppointEndTime, IsPass, start, end);
          return list;
      }

      public int GetBasesPageCount(int pageSize, string BasesName, string TrainingBaseCode, string ProfessionalBaseCode,
           string AppointBeginTime, string AppointEndTime, string IsPass)
      {
          int recordCount = teachersAppointInformationDAL.GetBasesRecordCount(BasesName, TrainingBaseCode, ProfessionalBaseCode, AppointBeginTime, AppointEndTime, IsPass);
          int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
          return pageCount;
      }
      public int GetBasesRecordCount(string BasesName, string TrainingBaseCode, string ProfessionalBaseCode,
           string AppointBeginTime, string AppointEndTime, string IsPass)
      {
          return teachersAppointInformationDAL.GetBasesRecordCount(BasesName, TrainingBaseCode, ProfessionalBaseCode, AppointBeginTime, AppointEndTime, IsPass);
      }
      #endregion

      public List<TeachersAppointInformationModel> SelectListById(string id)
      {
          return teachersAppointInformationDAL.SelectListById(id);
      }


      #region managersGetPagedList
      public List<Model.TeachersAppointInformationModel> managersGetPagedList(string TrainingBaseCode, string RealName, string ProfessionalBaseName, string DeptName,
           string AppointBeginTime, string AppointEndTime, string IsPass,
      int pageIndex, int pageSize)
      {
          int start = (pageIndex - 1) * pageSize + 1;
          int end = pageIndex * pageSize;
          List<TeachersAppointInformationModel> list = teachersAppointInformationDAL.managersGetPagedList(TrainingBaseCode,RealName, ProfessionalBaseName,DeptName, AppointBeginTime, AppointEndTime, IsPass, start, end);
          return list;
      }

      public int managersGetPageCount(int pageSize, string TrainingBaseCode, string RealName, string ProfessionalBaseName, string DeptName,
           string AppointBeginTime, string AppointEndTime, string IsPass)
      {
          int recordCount = teachersAppointInformationDAL.managersGetRecordCount(TrainingBaseCode, RealName, ProfessionalBaseName, DeptName, AppointBeginTime, AppointEndTime, IsPass);
          int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
          return pageCount;
      }
      public int managersGetRecordCount(string TrainingBaseCode, string RealName, string ProfessionalBaseName, string DeptName,
           string AppointBeginTime, string AppointEndTime, string IsPass)
      {
          return teachersAppointInformationDAL.managersGetRecordCount(TrainingBaseCode, RealName, ProfessionalBaseName, DeptName, AppointBeginTime, AppointEndTime, IsPass);
      }
      #endregion

      public bool UpdateByManager(TeachersAppointInformationModel model)
      {
          return teachersAppointInformationDAL.UpdateByManager(model);
      }

      public bool UpdateIsReceive(string id, string isReceive)
      {
          return teachersAppointInformationDAL.UpdateIsReceive(id, isReceive);
      }
    }
}
