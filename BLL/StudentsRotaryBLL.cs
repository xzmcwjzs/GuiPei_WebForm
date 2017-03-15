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
   public class StudentsRotaryBLL
    {
       StudentsRotaryDAL studentsRotaryDAL = new StudentsRotaryDAL();
       public bool InsertStudentsRotary(StudentsRotaryModel model) {
           return studentsRotaryDAL.InsertStudentsRotary(model);
       }

       public List<Model.StudentsRotaryModel> getRotaryTimeList(string name, string training_base_code, string professional_base_code)
       {
           return studentsRotaryDAL.getRotaryTimeList(name,training_base_code,professional_base_code);
       }

       public List<Model.StudentsRotaryModel> GetPagedList(string students_name, string training_base_code,
         string rotary_dept, string instructor,string rotary_begin_time,string rotary_end_time,
        int pageIndex, int pageSize, out int rowCount, out int pageCount)
       {
           return studentsRotaryDAL.GetPagedList(students_name, training_base_code, 
               rotary_dept, instructor, rotary_begin_time, rotary_end_time,
               pageIndex, pageSize, out rowCount, out pageCount);
       }

       public Model.StudentsRotaryModel GetModelById(string id) {
           return studentsRotaryDAL.GetModelById(id);
       }

       public bool UpdateRotary(Model.StudentsRotaryModel model,string id) {
           return studentsRotaryDAL.UpdateRotary(model,id);
       }

       public bool UpdateQuestStatus(string status,string id)
       {
           return studentsRotaryDAL.UpdateQuestStatus(status,id);
       }
       public string GetApplication(string id)
       {
           return studentsRotaryDAL.GetApplication(id);
       }

       public bool UpdateApplication(string appli, string id)
       {
           return studentsRotaryDAL.UpdateApplication(appli,id);
       }

       public string GetQuestionnaire(string id)
       {
           return studentsRotaryDAL.GetQuestionnaire(id);
       }
       public DataTable GetDtByNT(string name, string training_base_code)
       {
           return studentsRotaryDAL.GetDtByNT(name, training_base_code);
       }

       public bool UpdateOutdeptStatusByT(string status, string id)
       {
           return studentsRotaryDAL.UpdateOutdeptStatusByT(status,id);
       }

    }
}
