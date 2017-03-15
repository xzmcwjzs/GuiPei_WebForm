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
    [Serializable]
   public class StudentsRotaryInformation2BLL
    {
        StudentsRotaryInformation2DAL dal = new StudentsRotaryInformation2DAL();

        public bool Add(int length, StudentsRotaryInformation2Model studentsRotaryInformation2Model, List<string> DeptCodeList, List<string> DeptNameList, List<string> BeginTimeList, List<string> EndTimeList, List<string> DaysList, List<string> TeachersNameList, List<string> TeachersRealNameList)
        {
            return dal.Add(length, studentsRotaryInformation2Model, DeptCodeList, DeptNameList, BeginTimeList, EndTimeList, DaysList, TeachersNameList, TeachersRealNameList);
        }

        public DataTable GetDtByNT(string Name, string TrainingBaseCode)
        {
            return dal.GetDtByNT(Name, TrainingBaseCode);
        }


        public bool UpdateApplication(StudentsRotaryInformation2Model model)
        {
            return dal.UpdateApplication(model);
        }

        public StudentsRotaryInformation2Model GetModelById(string Id)
        {
            return dal.GetModelById(Id);
        }

        public bool UpdateQuestStatus(string status, string id)
        {
            return dal.UpdateQuestStatus(status, id);
        }

        public bool UpdateOutdeptStatusByT(string status, string id)
        {
            return dal.UpdateOutdeptStatusByT(status, id);
        }

        public bool AddOne(StudentsRotaryInformation2Model model)
        { 
            return dal.AddOne(model);
        }
    }
}
