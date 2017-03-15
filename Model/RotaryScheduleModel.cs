using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class RotaryScheduleModel
    {
        private string _id = "newid";
        private string _managersname;
        private string _managersrealname;
        private string _trainingbasecode;
        private string _trainingbasename;
        private string _professionalbasecode;
        private string _professionalbasename;
        private string _begintimelist;
        private string _endtimelist;
        private string _dayslist;
        private string _deptcodelist;
        private string _deptnamelist;
        private string _schemeorder;
        private string _rotarybegintime;
        private string _rotaryendtime;
        private string _totalrealtime;
        private string _trainingtime;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManagersName
        {
            set { _managersname = value; }
            get { return _managersname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManagersRealName
        {
            set { _managersrealname = value; }
            get { return _managersrealname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrainingBaseCode
        {
            set { _trainingbasecode = value; }
            get { return _trainingbasecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrainingBaseName
        {
            set { _trainingbasename = value; }
            get { return _trainingbasename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProfessionalBaseCode
        {
            set { _professionalbasecode = value; }
            get { return _professionalbasecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProfessionalBaseName
        {
            set { _professionalbasename = value; }
            get { return _professionalbasename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BeginTimeList
        {
            set { _begintimelist = value; }
            get { return _begintimelist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EndTimeList
        {
            set { _endtimelist = value; }
            get { return _endtimelist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DaysList
        {
            set { _dayslist = value; }
            get { return _dayslist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeptCodeList
        {
            set { _deptcodelist = value; }
            get { return _deptcodelist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeptNameList
        {
            set { _deptnamelist = value; }
            get { return _deptnamelist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SchemeOrder
        {
            set { _schemeorder = value; }
            get { return _schemeorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RotaryBeginTime
        {
            set { _rotarybegintime = value; }
            get { return _rotarybegintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RotaryEndTime
        {
            set { _rotaryendtime = value; }
            get { return _rotaryendtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TotalRealTime
        {
            set { _totalrealtime = value; }
            get { return _totalrealtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrainingTime
        {
            set { _trainingtime = value; }
            get { return _trainingtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag1
        {
            set { _tag1 = value; }
            get { return _tag1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag2
        {
            set { _tag2 = value; }
            get { return _tag2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag3
        {
            set { _tag3 = value; }
            get { return _tag3; }
        }
    }
}
