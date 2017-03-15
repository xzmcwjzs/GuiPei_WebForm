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
   public class StudentsPersonalInformation2BLL
    {
       StudentsPersonalInformation2DAL dal = new StudentsPersonalInformation2DAL();

       public bool CheckInfo(string name)
       {
           return dal.GetDt(name) == null ? false : true;
       }

       public bool Add(StudentsPersonalInformation2Model model)
       {
           return dal.Add(model);
       }

       public bool Update(StudentsPersonalInformation2Model model)
       {
           return dal.Update(model);
       }

       public DataTable GetDt(string Name)
       {
           return dal.GetDt(Name);
       }


       public Model.StudentsPersonalInformation2Model GetModelByNameTBCode(string Name, string TrainingBaseCode)
       {
           return dal.GetModelByNameTBCode(Name, TrainingBaseCode);
       }

       public Model.StudentsPersonalInformation2Model GetModelById(string id)
       {

           return dal.GetModelById(id);
       }


       #region Common分页
       public List<Model.StudentsPersonalInformation2Model> CommonGetPagedList(string TrainingBaseCode, string ProfessionalBaseCode,
           string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
           string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
        int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<StudentsPersonalInformation2Model> list = dal.CommonGetPagedList(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string TrainingBaseCode, string ProfessionalBaseCode,
           string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
           string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime)
       {
           int recordCount = dal.CommonGetRecordCount(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string TrainingBaseCode, string ProfessionalBaseCode,
           string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
           string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime)
       {
           return dal.CommonGetRecordCount(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime);
       }
       #endregion

       public DataTable GetDtByNT(string Name, string TrainingBaseCode)
       {
           return dal.GetDtByNT(Name, TrainingBaseCode);
       }


       public DataTable StaticsPB(string TrainingBaseCode)
       { 
           return dal.StaticsPB(TrainingBaseCode);
       }

       public DataTable StaticsSU(string TrainingBaseCode)
       {
           return dal.StaticsSU(TrainingBaseCode);
       }
       public DataTable StaticsCU(string TrainingBaseCode)
       {
           return dal.StaticsCU(TrainingBaseCode);
       }
       public DataTable StaticsIT(string TrainingBaseCode)
       {
           return dal.StaticsIT(TrainingBaseCode);
       }
       public DataTable StaticsTT(string TrainingBaseCode)
       {
           return dal.StaticsTT(TrainingBaseCode);
       }
    }
}
