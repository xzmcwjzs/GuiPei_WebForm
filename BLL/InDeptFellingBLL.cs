using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class InDeptFellingBLL
    {
       InDeptFellingDAL inDeptFellingDAL = new InDeptFellingDAL();

       public Model.InDeptFellingModel GetModelById(string id) {
           return inDeptFellingDAL.GetModelById(id);
       }
       public bool InsertDeptFelling(InDeptFellingModel model)
       {
           return inDeptFellingDAL.InsertDeptFelling(model);
       }
       public bool UpdateDeptFelling(Model.InDeptFellingModel model, string id) {
           return inDeptFellingDAL.UpdateDeptFelling(model, id);
       }

       #region 分页
       public List<Model.InDeptFellingModel> GetPagedList(string students_name, string training_base_code, string rotary_dept,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<InDeptFellingModel> list = inDeptFellingDAL.GetPagedList(students_name, training_base_code, rotary_dept, start, end);
           return list;
       }

       public int GetPageCount(int pageSize, string name, string training_base_code, string rotary_dept)
       {
           int recordCount = inDeptFellingDAL.GetRecordCount(name, training_base_code, rotary_dept);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int GetRecordCount(string name, string training_base_code, string rotary_dept)
       {
           return inDeptFellingDAL.GetRecordCount(name, training_base_code, rotary_dept);
       } 
       #endregion

       #region Common分页
       public List<Model.InDeptFellingModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
        int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<InDeptFellingModel> list = inDeptFellingDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName)
       {
           int recordCount = inDeptFellingDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName)
       {
           return inDeptFellingDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName);
       }
       #endregion
       public bool UpdateCheckByTeacher(InDeptFellingModel model)
       {
           return inDeptFellingDAL.UpdateCheckByTeacher(model);
       }
    }
}
