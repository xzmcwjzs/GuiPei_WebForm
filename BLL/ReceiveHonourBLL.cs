using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class ReceiveHonourBLL
    {
        ReceiveHonourDAL receiveHonourDAL=new ReceiveHonourDAL();

        public bool Add(ReceiveHonourModel model)
        {
            return receiveHonourDAL.Add(model);
        }
        public List<ReceiveHonourModel> GetListById(string Id)
        {
            return receiveHonourDAL.GetListById(Id);
        }
        public bool Update(ReceiveHonourModel model)
        {
            return receiveHonourDAL.Update(model);
        }
        #region 分页
        public List<Model.ReceiveHonourModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
            string HonourName, string HonourDepartment, string HonourDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<ReceiveHonourModel> list = receiveHonourDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, HonourName, HonourDepartment, HonourDate, start, end);
            return list;
        }

        public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
            string HonourName, string HonourDepartment, string HonourDate)
        {
            int recordCount = receiveHonourDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, HonourName, HonourDepartment, HonourDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string HonourName, string HonourDepartment, string HonourDate)
        {
            return receiveHonourDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, HonourName, HonourDepartment, HonourDate);
        }
        #endregion

        #region Common分页
        public List<Model.ReceiveHonourModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string HonourName, string HonourDepartment, string HonourDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<ReceiveHonourModel> list = receiveHonourDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, HonourName, HonourDepartment, HonourDate, start, end);
            return list;
        }

        public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string HonourName, string HonourDepartment, string HonourDate)
        {
            int recordCount = receiveHonourDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, HonourName, HonourDepartment, HonourDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string HonourName, string HonourDepartment, string HonourDate)
        {
            return receiveHonourDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, HonourName, HonourDepartment, HonourDate);
        }
        #endregion
        public bool UpdateCheckByTeacher(ReceiveHonourModel model)
        {
            return receiveHonourDAL.UpdateCheckByTeacher(model);
        }
    }
}
