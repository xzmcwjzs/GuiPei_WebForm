using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{

    public class SurgeryRecordsBLL
    {
        SurgeryRecordsDAL surgeryRecordsDAL = new SurgeryRecordsDAL();
        public bool Add(SurgeryRecordsModel model)
        {
            return surgeryRecordsDAL.Add(model);
        }
        public SurgeryRecordsModel GetModelById(string Id)
        {
            return surgeryRecordsDAL.GetModelById(Id);
        }
        public bool Update(SurgeryRecordsModel model, string id)
        {
            return surgeryRecordsDAL.Update(model, id);
        }

        #region 分页
        public List<Model.SurgeryRecordsModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
           string PatientName, string CaseId, string SurgeryName, string IntraoperativePosition, string Emergency, string SurgeryDate, string SurgeryIsStop,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<SurgeryRecordsModel> list = surgeryRecordsDAL.GetPagedList(StudentsName, TrainingBaseCode, DeptName, PatientName, CaseId, SurgeryName, IntraoperativePosition,Emergency,SurgeryDate,SurgeryIsStop, start, end);
            return list;
        }

        public int GetPageCount(int pageSize, string StudentsName, string TrainingBaseCode, string DeptName,
           string PatientName, string CaseId, string SurgeryName, string IntraoperativePosition, string Emergency, string SurgeryDate, string SurgeryIsStop)
        {
            int recordCount = surgeryRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, PatientName, CaseId, SurgeryName, IntraoperativePosition, Emergency, SurgeryDate, SurgeryIsStop);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
           string PatientName, string CaseId, string SurgeryName, string IntraoperativePosition, string Emergency, string SurgeryDate, string SurgeryIsStop)
        {
            return surgeryRecordsDAL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, PatientName, CaseId, SurgeryName, IntraoperativePosition, Emergency, SurgeryDate, SurgeryIsStop);
        }
        #endregion

        #region Common分页
        public List<Model.SurgeryRecordsModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string PatientName, string CaseId, string SurgeryName, string IntraoperativePosition, string Emergency, string SurgeryDate, string SurgeryIsStop,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<SurgeryRecordsModel> list = surgeryRecordsDAL.CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, SurgeryName, IntraoperativePosition, Emergency, SurgeryDate, SurgeryIsStop, start, end);
            return list;
        }

        public int CommonGetPageCount(int pageSize, string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string PatientName, string CaseId, string SurgeryName, string IntraoperativePosition, string Emergency, string SurgeryDate, string SurgeryIsStop)
        {
            int recordCount = surgeryRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, SurgeryName, IntraoperativePosition, Emergency, SurgeryDate, SurgeryIsStop);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
           string PatientName, string CaseId, string SurgeryName, string IntraoperativePosition, string Emergency, string SurgeryDate, string SurgeryIsStop)
        {
            return surgeryRecordsDAL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, SurgeryName, IntraoperativePosition, Emergency, SurgeryDate, SurgeryIsStop);
        }
        #endregion

        public bool UpdateCheckByTeacher(SurgeryRecordsModel model)
        {
            return surgeryRecordsDAL.UpdateCheckByTeacher(model);
        }
    }
}
