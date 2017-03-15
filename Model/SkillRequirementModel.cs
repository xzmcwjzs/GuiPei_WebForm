using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class SkillRequirementModel
    {
        private string _id = "newid";
        private string _professionalbasecode;
        private string _professionalbasename;
        private string _deptcode;
        private string _deptname;
        private string _depttime;
        private string _isrequired;
        private string _skillcode;
        private string _skillname;
        private string _requirednum;
        private string _masterdegree;
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
        public string IsRequired
        {
            set { _isrequired = value; }
            get { return _isrequired; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SkillCode
        {
            set { _skillcode = value; }
            get { return _skillcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SkillName
        {
            set { _skillname = value; }
            get { return _skillname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RequiredNum
        {
            set { _requirednum = value; }
            get { return _requirednum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MasterDegree
        {
            set { _masterdegree = value; }
            get { return _masterdegree; }
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
