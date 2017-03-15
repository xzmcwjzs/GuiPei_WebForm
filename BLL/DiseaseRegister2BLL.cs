using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
   public  class DiseaseRegister2BLL
    {
       DiseaseRegister2DAL diseaseRegister2DAL = new DiseaseRegister2DAL();
       public bool Insert(DiseaseRegister2Model model)
       {
           return diseaseRegister2DAL.Insert(model);
       }

       #region 分页
       public List<Model.DiseaseRegister2Model> GetPagedList(string students_name, string training_base_code, string dept_name, string disease_name, string required_num, string master_degree,
       int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<DiseaseRegister2Model> list = diseaseRegister2DAL.GetPagedList(students_name, training_base_code, dept_name,disease_name,required_num,master_degree, start, end);
           return list;
       }

       public int GetPageCount(int pageSize, string name, string training_base_code, string dept_name, string disease_name, string required_num, string master_degree)
       {
           int recordCount = diseaseRegister2DAL.GetRecordCount(name, training_base_code, dept_name,disease_name,required_num,master_degree);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int GetRecordCount(string name, string training_base_code, string dept_name, string disease_name, string required_num, string master_degree)
       {
           return diseaseRegister2DAL.GetRecordCount(name, training_base_code, dept_name,disease_name,required_num,master_degree);
       }
       #endregion

       public DiseaseRegister2Model GetModelById(string id)
       {
           return diseaseRegister2DAL.GetModelById(id);
       }
       public bool Update(DiseaseRegister2Model model,string id)
       {
           return diseaseRegister2DAL.Update(model, id);
       }

       #region Common分页
       public List<Model.DiseaseRegister2Model> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
          string DiseaseName, string RequiredNum, string MasterDegree,
        int pageIndex, int pageSize)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<DiseaseRegister2Model> list = diseaseRegister2DAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, DiseaseName, RequiredNum, MasterDegree, start, end);
           return list;
       }

       public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
          string DiseaseName, string RequiredNum, string MasterDegree)
       {
           int recordCount = diseaseRegister2DAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, DiseaseName, RequiredNum, MasterDegree);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
           return pageCount;
       }
       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
          string DiseaseName, string RequiredNum, string MasterDegree)
       {
           return diseaseRegister2DAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, DiseaseName, RequiredNum, MasterDegree);
       }
       #endregion
       public bool UpdateCheckByTeacher(DiseaseRegister2Model model)
       {
           return diseaseRegister2DAL.UpdateCheckByTeacher(model);
       }
    }
}
