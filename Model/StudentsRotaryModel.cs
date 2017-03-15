using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class StudentsRotaryModel
    {
        #region Model
        private string _id = "newid";
        private string _name;
        private string _real_name;
        private string _rotary_begin_time;
        private string  _rotary_end_time;
        private string _training_base_code;
        private string _training_base_name;
        private string _professional_base_code;
        private string _professional_base_name;
        private string _rotary_dept_code;
        private string _rotary_dept_name;
        private string _instructor;
        private string _instructor_tag;
        private string  _register_date;
        private string _writor;
        private string _outdept_status;
        private string _outdept_application;
        private string _questionnaire_status;
        /// <summary>
        /// 
        /// </summary>
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
        public string  rotary_begin_time
        {
            set { _rotary_begin_time = value; }
            get { return _rotary_begin_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rotary_end_time
        {
            set { _rotary_end_time = value; }
            get { return _rotary_end_time; }
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
        /// <summary>
        /// 
        /// </summary>
        public string instructor
        {
            set { _instructor = value; }
            get { return _instructor; }
        }

        public string instructor_tag
        {
            set { _instructor_tag = value; }
            get { return _instructor_tag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  register_date
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

        public string outdept_status {
            set { _outdept_status = value; }
            get { return _outdept_status; }
        }
        public string outdept_application
        {
            set { _outdept_application = value; }
            get { return _outdept_application; }
        }
        public string questionnaire_status {
            set { _questionnaire_status = value; }
            get { return _questionnaire_status; }
        }
        #endregion Model
    }
}
