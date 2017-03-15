using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class DeptManagementModel
    {
        private string _id = "newid";
        private string _managersname;
        private string _managersrealname;
        private string _trainingbasecode;
        private string _trainingbasename;
        private string _professionalbasecode;
        private string _professionalbasename;
        private string _deptcode;
        private string _deptname;
        private string _depttime;
        private string _realtime;
        private string _isrequired;
        private string _trainingtime;
        private string _totaldepttime;
        private string _totalrealtime;
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
        public string DeptTime
        {
            set { _depttime = value; }
            get { return _depttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RealTime
        {
            set { _realtime = value; }
            get { return _realtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsRequired
        {
            set { _isrequired = value; }
            get { return _isrequired; }
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
        public string TotalDeptTime
        {
            set { _totaldepttime = value; }
            get { return _totaldepttime; }
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
