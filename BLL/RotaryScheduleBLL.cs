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
  public  class RotaryScheduleBLL
    {
      RotaryScheduleDAL dal = new RotaryScheduleDAL();

      public bool Add(int SelectLength, RotaryScheduleModel model, List<string> BeginTimeList, List<string> EndTimeList, List<string> DaysList, List<string> DeptCodeList, List<string> DeptNameList, List<string> SchemeOrder)
      {

          return dal.Add(SelectLength, model, BeginTimeList, EndTimeList, DaysList, DeptCodeList, DeptNameList, SchemeOrder);
      }

      public bool CheckScheme(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
      {
          return dal.GetModel(TrainingTime, TrainingBaseCode, ProfessionalBaseCode) == null ? false : true;
      }


      public List<RotaryScheduleModel> GetSchemeList(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
      {
          return dal.GetSchemeList(TrainingTime, TrainingBaseCode, ProfessionalBaseCode);
      }

      public bool UpdateStudents(RotaryScheduleModel model)
      {
          return dal.UpdateStudents(model);
      }


      #region 分页
      public List<Model.RotaryScheduleModel> GetPagedList(string TrainingBaseCode, string ProfessionalBaseCode, string TrainingTime,
      int pageIndex, int pageSize)
      {
          int start = (pageIndex - 1) * pageSize + 1;
          int end = pageIndex * pageSize;
          List<RotaryScheduleModel> list = dal.GetPagedList(TrainingBaseCode, ProfessionalBaseCode, TrainingTime, start, end);
          return list;
      }

      public int GetPageCount(int pageSize, string TrainingBaseCode, string ProfessionalBaseCode, string TrainingTime)
      {
          int recordCount = dal.GetRecordCount(TrainingBaseCode, ProfessionalBaseCode, TrainingTime);
          int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
          return pageCount;
      }
      public int GetRecordCount(string TrainingBaseCode, string ProfessionalBaseCode, string TrainingTime)
      {
          return dal.GetRecordCount(TrainingBaseCode, ProfessionalBaseCode, TrainingTime);
      }
      #endregion


      public DataTable GetDtByTTP(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
      {
          return dal.GetDtByTTP(TrainingTime, TrainingBaseCode, ProfessionalBaseCode);
      }

      public bool Delete(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
      {
          return dal.Delete(TrainingTime, TrainingBaseCode, ProfessionalBaseCode);
      }

    }
}
