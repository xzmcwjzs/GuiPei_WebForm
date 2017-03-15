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
   public class OutDeptExamBLL
    {
       OutDeptExamDAL outDeptExamDAL = new OutDeptExamDAL();
       #region Insert
       public bool Insert(Model.OutDeptExamModel model)
       {
           return outDeptExamDAL.Insert(model);
       } 
       #endregion

       #region SelectRotaryTimeModel
       public Model.OutDeptExamModel SelectRotaryTimeModel(string students_name, string training_base_code, string rotary_dept_code)
       {
           return outDeptExamDAL.SelectRotaryTimeModel(students_name, training_base_code, rotary_dept_code);
       } 
       #endregion

       #region GetModelListExam
       public List<OutDeptExamModel> GetModelListExam(string training_base_code, string rotary_dept_code, string instructor, string instructor_tag,string students_name,string rotary_begin_time,string rotary_end_time,string total_score,string is_pass, int pageIndex, int pageSize, out int rowCount, out int pageCount)
       {
           DataTable dt = outDeptExamDAL.GetListExam(training_base_code, rotary_dept_code, instructor, instructor_tag, students_name, rotary_begin_time, rotary_end_time, total_score, is_pass, pageIndex, pageSize, out rowCount, out pageCount);
           return DataTableToList(dt);
       }

       public List<OutDeptExamModel> DataTableToList(DataTable dt)
       {
           List<OutDeptExamModel> modelList = new List<OutDeptExamModel>();
           int rowsCount = dt.Rows.Count;
           if (rowsCount > 0)
           {
               OutDeptExamModel model;
               for (int n = 0; n < rowsCount; n++)
               {
                   model = outDeptExamDAL.DataRowToModel2(dt.Rows[n]);
                   if (model != null)
                   {
                       modelList.Add(model);
                   }
               }
           }
           return modelList;
       } 
       #endregion

       #region SelectById
       public OutDeptExamModel SelectById(string id)
       {
           return outDeptExamDAL.SelectById(id);
       } 
       #endregion

       #region UpdateById
       public bool UpdateById(OutDeptExamModel model,string id)
       {
           return outDeptExamDAL.UpdateById(model,id);
       } 
       #endregion

       #region Common分页
       public List<Model.OutDeptExamModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string TotalScore, string IsPass,
        int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<OutDeptExamModel> list = outDeptExamDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, ProfessionalBaseName, DeptName, TeachersRealName, RotaryBeginTime, RotaryEndTime, TotalScore, IsPass, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string TotalScore, string IsPass)
       {
           int recordCount = outDeptExamDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, ProfessionalBaseName, DeptName, TeachersRealName, RotaryBeginTime, RotaryEndTime, TotalScore, IsPass);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string TotalScore, string IsPass)
       {
           return outDeptExamDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, ProfessionalBaseName, DeptName, TeachersRealName, RotaryBeginTime, RotaryEndTime, TotalScore, IsPass);
       }
       #endregion
    }
}
