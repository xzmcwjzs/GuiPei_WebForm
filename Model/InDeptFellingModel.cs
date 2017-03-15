using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class InDeptFellingModel
    {
        #region Model
        private string _id = "newid";
        private string _name;
        private string _real_name;
        private string _training_base_code;
        private string _training_base_name;
        private string _professional_base_code;
        private string _professional_base_name;
        private string _rotary_dept_code;
        private string _rotary_dept_name;
        private string _indept_felling;
        private string _register_date;
        private string _writor;
        private string _teacher_status;
        private string _kzr_status;
        private string _base_status;
        private string _manager_status;
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
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string real_name
        {
            set { _real_name = value; }
            get { return _real_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string training_base_code
        {
            set { _training_base_code = value; }
            get { return _training_base_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string training_base_name
        {
            set { _training_base_name = value; }
            get { return _training_base_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string professional_base_code
        {
            set { _professional_base_code = value; }
            get { return _professional_base_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string professional_base_name
        {
            set { _professional_base_name = value; }
            get { return _professional_base_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rotary_dept_code
        {
            set { _rotary_dept_code = value; }
            get { return _rotary_dept_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rotary_dept_name
        {
            set { _rotary_dept_name = value; }
            get { return _rotary_dept_name; }
        }

        public string indept_felling
        {
            set { _indept_felling = value; }
            get { return _indept_felling; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string register_date
        {
            set { _register_date = value; }
            get { return _register_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string writor
        {
            set { _writor = value; }
            get { return _writor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string teacher_status
        {
            set { _teacher_status = value; }
            get { return _teacher_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kzr_status
        {
            set { _kzr_status = value; }
            get { return _kzr_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string base_status
        {
            set { _base_status = value; }
            get { return _base_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string manager_status
        {
            set { _manager_status = value; }
            get { return _manager_status; }
        }
        #endregion Model
    }
}
