using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class PublishArticalRecordsBLL
    {
        PublishArticalRecordsDAL publishArticalRecordsDAL=new PublishArticalRecordsDAL();
        public bool Add(PublishArticalRecordsModel model)
        {
            return publishArticalRecordsDAL.Add(model);
        }

        public List<PublishArticalRecordsModel> GetListById(string Id)
        {
            return publishArticalRecordsDAL.GetListById(Id);
        }
        public bool Update(PublishArticalRecordsModel model)
        {
            return publishArticalRecordsDAL.Update(model);
        }

        #region 分页
        public List<Model.PublishArticalRecordsModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
            string ArticalTitle, string ArticalCategory, string Author, string PublishDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<PublishArticalRecordsModel> list = publishArticalRecordsDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, ArticalTitle, ArticalCategory, Author,PublishDate, start, end);
            return list;
        }

        public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
            string ArticalTitle, string ArticalCategory, string Author, string PublishDate)
        {
            int recordCount = publishArticalRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ArticalTitle, ArticalCategory, Author, PublishDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
           string ArticalTitle, string ArticalCategory, string Author, string PublishDate)
        {
            return publishArticalRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ArticalTitle, ArticalCategory, Author, PublishDate);
        }
        #endregion


        #region Common分页
        public List<Model.PublishArticalRecordsModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ArticalTitle, string ArticalCategory, string Author, string PublishDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<PublishArticalRecordsModel> list = publishArticalRecordsDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ArticalTitle, ArticalCategory, Author, PublishDate, start, end);
            return list;
        }

        public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ArticalTitle, string ArticalCategory, string Author, string PublishDate)
        {
            int recordCount = publishArticalRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ArticalTitle, ArticalCategory, Author, PublishDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string ArticalTitle, string ArticalCategory, string Author, string PublishDate)
        {
            return publishArticalRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, ArticalTitle, ArticalCategory, Author, PublishDate);
        }
        #endregion

        public bool UpdateCheckByTeacher(PublishArticalRecordsModel model)
        {
            return publishArticalRecordsDAL.UpdateCheckByTeacher(model);
        }
    }
}
