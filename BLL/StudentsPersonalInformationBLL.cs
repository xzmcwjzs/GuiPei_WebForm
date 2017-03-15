using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    
    public class StudentsPersonalInformationBLL
    {
        StudentsPersonalInformationDAL studentsPersonalInformationDAL = new StudentsPersonalInformationDAL();
        public DataTable GetDataTable(StudentsModel studentsModel)
        {

            return studentsPersonalInformationDAL.GetDataTable(studentsModel);
        }
        public int InsertStudentsPersonalInformation(StudentsPersonalInformationModel studentspersonalinformationModel) {
            return studentsPersonalInformationDAL.InsertStudentsPersonalInformation(studentspersonalinformationModel);
        }
        public DataSet GetDataTableByIdNumber(string id_number)
        {

            return studentsPersonalInformationDAL.GetDataTableByIdNumber(id_number);
        }
        public List<Model.StudentsPersonalInformationModel> GetPagedList(string students_name, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            return studentsPersonalInformationDAL.GetPagedList(students_name,pageIndex,pageSize,out rowCount,out pageCount);
        }

        public Model.StudentsPersonalInformationModel GetModelById(string id)
        {


            return studentsPersonalInformationDAL.GetModelById(id);
        }

        public bool UpdateStudentsPersonalInformation(StudentsPersonalInformationModel model)
        {
            return studentsPersonalInformationDAL.UpdateStudentsPersonalInformation(model);
        }

        
        public Model.StudentsPersonalInformationModel GetModelByNameTBCode(string name, string training_base_code)
        {
            return studentsPersonalInformationDAL.GetModelByNameTBCode(name,training_base_code);
        }
        #region Common分页
        public List<Model.StudentsPersonalInformationModel> CommonGetPagedList(string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
         int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<StudentsPersonalInformationModel> list = studentsPersonalInformationDAL.CommonGetPagedList(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex,MinZu ,HighEducation,HighSchool,IdentityType,SendUnit,CollaborativeUnit,TrainingTime,PlanTrainingTime, start, end);
            return list;
        }

        public int CommonGetPageCount(int pageSize, string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime)
        {
            int recordCount = studentsPersonalInformationDAL.CommonGetRecordCount(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int CommonGetRecordCount(string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime)
        {
            return studentsPersonalInformationDAL.CommonGetRecordCount(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime);
        }
        #endregion

       public DataTable GetDtByTPT(string training_base_code, string professional_base_code, string training_time)
        {
            return studentsPersonalInformationDAL.GetDtByTPT(training_base_code, professional_base_code, training_time);
        }
    }
    
}
