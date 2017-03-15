using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class StudyAndReadingModel
    {
        private string _id = "newid";
        private string _studentsrealname;
        private string _studentsname;
        private string _trainingbasecode;
        private string _trainingbasename;
        private string _professionalbasecode;
        private string _professionalbasename;
        private string _deptcode;
        private string _deptname;
        private string _registerdate;
        private string _writor;
        private string _teachercheck;
        private string _kzrcheck;
        private string _basecheck;
        private string _managercheck;
        private string _teacherid;
        private string _teachername;
        private string _activityform;
        private string _activitycontent;
        private string _activitydate;
        private string _languagetype;
        private string _classhour;
        private string _mainspeaker;
        private string _superiordoctor;
        private string _comment;
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
        public string StudentsRealName
        {
            set { _studentsrealname = value; }
            get { return _studentsrealname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StudentsName
        {
            set { _studentsname = value; }
            get { return _studentsname; }
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
        public string DeptCode
        {
            set { _deptcode = value; }
            get { return _deptcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeptName
        {
            set { _deptname = value; }
            get { return _deptname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Writor
        {
            set { _writor = value; }
            get { return _writor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeacherCheck
        {
            set { _teachercheck = value; }
            get { return _teachercheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KzrCheck
        {
            set { _kzrcheck = value; }
            get { return _kzrcheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BaseCheck
        {
            set { _basecheck = value; }
            get { return _basecheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManagerCheck
        {
            set { _managercheck = value; }
            get { return _managercheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeacherId
        {
            set { _teacherid = value; }
            get { return _teacherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeacherName
        {
            set { _teachername = value; }
            get { return _teachername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ActivityForm
        {
            set { _activityform = value; }
            get { return _activityform; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ActivityContent
        {
            set { _activitycontent = value; }
            get { return _activitycontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ActivityDate
        {
            set { _activitydate = value; }
            get { return _activitydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LanguageType
        {
            set { _languagetype = value; }
            get { return _languagetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassHour
        {
            set { _classhour = value; }
            get { return _classhour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainSpeaker
        {
            set { _mainspeaker = value; }
            get { return _mainspeaker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SuperiorDoctor
        {
            set { _superiordoctor = value; }
            get { return _superiordoctor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Comment
        {
            set { _comment = value; }
            get { return _comment; }
        }
    }
}
