using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class SkillRequirement2BLL
    {
       SkillRequirement2DAL skillRequirement2DAL = new SkillRequirement2DAL();
       public bool Add(SkillRequirement2Model model)
       {
           return skillRequirement2DAL.Add(model);
       }

       public List<SkillRequirement2Model> GetListById(string Id)
       {
           return skillRequirement2DAL.GetListById(Id);
       }

       public bool Update(SkillRequirement2Model model)
       {
           return skillRequirement2DAL.Update(model);
       }

       #region 分页
       public List<Model.SkillRequirement2Model> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName, string SkillName, string RequiredNum, string MasterDegree,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<SkillRequirement2Model> list = skillRequirement2DAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, SkillName, RequiredNum, MasterDegree, start, end);
           return list;
       }

       public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName, string SkillName, string RequiredNum, string MasterDegree)
       {
           int recordCount = skillRequirement2DAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, SkillName, RequiredNum, MasterDegree);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName, string SkillName, string RequiredNum, string MasterDegree)
       {
           return skillRequirement2DAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, SkillName, RequiredNum, MasterDegree);
       }
       #endregion

       #region Common分页
       public List<Model.SkillRequirement2Model> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
 string SkillName, string RequiredNum, string MasterDegree,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<SkillRequirement2Model> list = skillRequirement2DAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, SkillName, RequiredNum, MasterDegree, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
 string SkillName, string RequiredNum, string MasterDegree)
       {
           int recordCount = skillRequirement2DAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, SkillName, RequiredNum, MasterDegree);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
string SkillName, string RequiredNum, string MasterDegree)
       {
           return skillRequirement2DAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, SkillName, RequiredNum, MasterDegree);
       }
       #endregion


       public bool UpdateCheckByTeacher(SkillRequirement2Model model)
       {
           return skillRequirement2DAL.UpdateCheckByTeacher(model);
       }
    }
}
