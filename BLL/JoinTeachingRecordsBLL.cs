using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
   public  class JoinTeachingRecordsBLL
    {
       JoinTeachingRecordsDAL joinTeachingRecordsDAL = new JoinTeachingRecordsDAL();
       public bool Add(JoinTeachingRecordsModel model)
       {
           return joinTeachingRecordsDAL.Add(model);
       }

       public List<JoinTeachingRecordsModel> GetListById(string Id)
       {
           return joinTeachingRecordsDAL.GetListById(Id);
       }

       public bool Update(JoinTeachingRecordsModel model)
       {
           return joinTeachingRecordsDAL.Update(model);
       }

       #region 分页
       public List<Model.JoinTeachingRecordsModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
           string TeachingObject, string HeadTeacher, string TeachingDate,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<JoinTeachingRecordsModel> list = joinTeachingRecordsDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, TeachingObject, HeadTeacher, TeachingDate, start, end);
           return list;
       }

       public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
           string TeachingObject, string HeadTeacher, string TeachingDate)
       {
           int recordCount = joinTeachingRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, TeachingObject, HeadTeacher, TeachingDate);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
           string TeachingObject, string HeadTeacher, string TeachingDate)
       {
           return joinTeachingRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, TeachingObject, HeadTeacher, TeachingDate);
       }
       #endregion

       #region Common分页
       public List<Model.JoinTeachingRecordsModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string TeachingObject, string HeadTeacher, string TeachingDate,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<JoinTeachingRecordsModel> list = joinTeachingRecordsDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, TeachingObject, HeadTeacher, TeachingDate, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string TeachingObject, string HeadTeacher, string TeachingDate)
       {
           int recordCount = joinTeachingRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, TeachingObject, HeadTeacher, TeachingDate);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string TeachingObject, string HeadTeacher, string TeachingDate)
       {
           return joinTeachingRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, TeachingObject, HeadTeacher, TeachingDate);
       }
       #endregion


       public bool UpdateCheckByTeacher(JoinTeachingRecordsModel model)
       {
            return joinTeachingRecordsDAL.UpdateCheckByTeacher(model);
       }


    }
}
