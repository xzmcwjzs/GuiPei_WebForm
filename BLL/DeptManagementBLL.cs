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
  public  class DeptManagementBLL
    {
      DeptManagementDAL dal = new DeptManagementDAL();

      public bool Add(int length,DeptManagementModel model, List<string> DeptNameList, List<string> DeptCodeList, List<string> DeptTimeList, List<string> RealTimeList, List<string> IsRequiredList)
      {
          return dal.Add(length,model, DeptNameList, DeptCodeList, DeptTimeList, RealTimeList, IsRequiredList);
      }

      public bool CheckDept(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
      {
          return dal.GetModel(TrainingTime,TrainingBaseCode,ProfessionalBaseCode) == null ? false : true;
      }

      public bool Delete(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
      {
          return dal.Delete(TrainingTime, TrainingBaseCode, ProfessionalBaseCode);
      }

      public List<DeptManagementModel> GetDeptList(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
      {
          return dal.GetDeptList(TrainingTime, TrainingBaseCode, ProfessionalBaseCode);
      }


      public bool UpdateTeachers(int length, List<string> IdList, List<string> TeachersNameList, List<string> TeachersRealNameList)
      {
          return dal.UpdateTeachers(length, IdList, TeachersNameList, TeachersRealNameList);
      }


      public DataTable GetTeachersDt(string TrainingTime, string TrainingBaseCode, string ProfessionalBaseCode)
      {
          return dal.GetTeachersDt(TrainingTime, TrainingBaseCode, ProfessionalBaseCode);
      }

    }

}
