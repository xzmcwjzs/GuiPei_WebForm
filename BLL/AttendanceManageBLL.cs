using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class AttendanceManageBLL
    {
       AttendanceManagementDAL attendanceManagementDAL = new AttendanceManagementDAL();
       public bool Add(AttendanceManagementModel model)
       {
           return attendanceManagementDAL.Add(model);
       }

       public List<AttendanceManagementModel> GetListById(string Id)
       {
           return attendanceManagementDAL.GetListById(Id);
       }

       public bool Update(AttendanceManagementModel model)
       {
           return attendanceManagementDAL.Update(model);
       }
        #region 分页
       public List<Model.AttendanceManagementModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
            string AttendanceCategory, string FirstDate, string LastDate, string Days,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<AttendanceManagementModel> list = attendanceManagementDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, AttendanceCategory, FirstDate, LastDate,Days, start, end);
            return list;
        }

        public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
            string AttendanceCategory, string FirstDate, string LastDate, string Days)
        {
            int recordCount = attendanceManagementDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, AttendanceCategory, FirstDate, LastDate, Days);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string AttendanceCategory, string FirstDate, string LastDate, string Days)
        {
            return attendanceManagementDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, AttendanceCategory, FirstDate, LastDate, Days);
        }
        #endregion

        #region Common分页
        public List<Model.AttendanceManagementModel> CommonGetPagedList(string StudentsRealName,string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
           string AttendanceCategory, string FirstDate, string LastDate, string Days,
         int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<AttendanceManagementModel> list = attendanceManagementDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName,TeachersRealName, AttendanceCategory, FirstDate, LastDate, Days, start, end);
            return list;
        }

        public int CommonGetPageCount(int pageSize,string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
           string AttendanceCategory, string FirstDate, string LastDate, string Days)
        {
            int recordCount = attendanceManagementDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName,DeptName,TeachersRealName, AttendanceCategory, FirstDate, LastDate, Days);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int CommonGetRecordCount(string StudentsRealName,string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
           string AttendanceCategory, string FirstDate, string LastDate, string Days)
        {
            return attendanceManagementDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName,DeptName,TeachersRealName, AttendanceCategory, FirstDate, LastDate, Days);
        }
        #endregion

        public bool UpdateCheckByTeacher(AttendanceManagementModel model)
        {
            return attendanceManagementDAL.UpdateCheckByTeacher(model);
        }
    }
}
