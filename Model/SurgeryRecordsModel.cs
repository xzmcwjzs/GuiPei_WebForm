using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class SurgeryRecordsModel
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
        private string _patientname;
        private string _caseid;
        private string _surgeryname;
        private string _intraoperativeposition;
        private string _roomid;
        private string _maindiagnosis;
        private string _secondarydiagnosis;
        private string _emergency;
        private string _surgerydate;
        private string _surgeryscale;
        private string _doctorincharge;
        private string _assistant;
        private string _nurse;
        private string _anesthesiamethod;
        private string _anesthetist;
        private string _surgeryisstop;
        private string _stopreason;
        private string _comment;
        private string _teacherid;
        private string _teachername;
        /// <summary>
        /// 
        /// </summary>
        ///
        public string TeacherId
        {
            set { _teacherid = value; }
            get { return _teacherid; }
        }
        public string TeacherName
        {
            set { _teachername = value; }
            get { return _teachername; }
        }
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
        public string PatientName
        {
            set { _patientname = value; }
            get { return _patientname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CaseId
        {
            set { _caseid = value; }
            get { return _caseid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SurgeryName
        {
            set { _surgeryname = value; }
            get { return _surgeryname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IntraoperativePosition
        {
            set { _intraoperativeposition = value; }
            get { return _intraoperativeposition; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoomId
        {
            set { _roomid = value; }
            get { return _roomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainDiagnosis
        {
            set { _maindiagnosis = value; }
            get { return _maindiagnosis; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SecondaryDiagnosis
        {
            set { _secondarydiagnosis = value; }
            get { return _secondarydiagnosis; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Emergency
        {
            set { _emergency = value; }
            get { return _emergency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SurgeryDate
        {
            set { _surgerydate = value; }
            get { return _surgerydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SurgeryScale
        {
            set { _surgeryscale = value; }
            get { return _surgeryscale; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DoctorInCharge
        {
            set { _doctorincharge = value; }
            get { return _doctorincharge; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Assistant
        {
            set { _assistant = value; }
            get { return _assistant; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Nurse
        {
            set { _nurse = value; }
            get { return _nurse; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AnesthesiaMethod
        {
            set { _anesthesiamethod = value; }
            get { return _anesthesiamethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Anesthetist
        {
            set { _anesthetist = value; }
            get { return _anesthetist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SurgeryIsStop
        {
            set { _surgeryisstop = value; }
            get { return _surgeryisstop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StopReason
        {
            set { _stopreason = value; }
            get { return _stopreason; }
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
