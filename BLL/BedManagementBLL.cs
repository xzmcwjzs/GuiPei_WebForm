using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
   public  class BedManagementBLL
    {
       BedManagementDAL bedManagementDAL = new BedManagementDAL();
       public bool Add(BedManagementModel model)
       {
           return bedManagementDAL.Add(model);
       }
       public bool Update(BedManagementModel model, string id)
       {
           return bedManagementDAL.Update(model, id);
       }

       public BedManagementModel GetModelById(string id)
       {
           return bedManagementDAL.GetModelById(id);
       }

        #region 分页
       public List<Model.BedManagementModel> GetPagedList(string students_name, string training_base_code, string dept_name,
           string patient_name, string bed_id, string bed_status, string room_id, string building_id,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<BedManagementModel> list = bedManagementDAL.GetPagedList(students_name, training_base_code, dept_name,patient_name,bed_id,bed_status,room_id,building_id, start, end);
           return list;
       }

       public int GetPageCount(int pageSize, string name, string training_base_code, string dept_name,
           string patient_name, string bed_id, string bed_status, string room_id, string building_id)
       {
           int recordCount = bedManagementDAL.GetRecordCount(name, training_base_code, dept_name, patient_name, bed_id, bed_status, room_id, building_id);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int GetRecordCount(string name, string training_base_code, string dept_name,
           string patient_name, string bed_id, string bed_status, string room_id, string building_id)
       {
           return bedManagementDAL.GetRecordCount(name, training_base_code, dept_name, patient_name, bed_id, bed_status, room_id, building_id);
       } 
        #endregion

       #region Common分页
       public List<Model.BedManagementModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
           string patient_name, string bed_id, string bed_status, string room_id, string building_id,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<BedManagementModel> list = bedManagementDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName,TeachersRealName, patient_name, bed_id, bed_status, room_id, building_id, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
           string patient_name, string bed_id, string bed_status, string room_id, string building_id)
       {
           int recordCount = bedManagementDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName,TeachersRealName, patient_name, bed_id, bed_status, room_id, building_id);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
           string patient_name, string bed_id, string bed_status, string room_id, string building_id)
       {
           return bedManagementDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName,TeachersRealName, patient_name, bed_id, bed_status, room_id, building_id);
       }
       #endregion
       public bool UpdateCheckByTeacher(BedManagementModel model)
       {
           return bedManagementDAL.UpdateCheckByTeacher(model);
       }
    }
}
