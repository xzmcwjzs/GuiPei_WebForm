using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    
   public class TeachersAppointInformationModel
    {
        private string _id = "newid";
        private string _teachers_name;
        private string _teachers_real_name;
        private string _appoint_begin_time;
        private string _appoint_end_time;
        private string _training_content;
        private string _total_num;
        private string _class_num;
        private string _each_class_num;
        private string _comment;
        private string _is_pass;
        private string _type;
        private string _training_base_code;
        private string _training_base_name;
        private string _professional_base_code;
        private string _professional_base_name;
        private string _dept_code;
        private string _dept_name;
        private string _register_date;
        private string _filename;
        private string _filepath;
        private string _isreceive;
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
        public string teachers_name
        {
            set { _teachers_name = value; }
            get { return _teachers_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string teachers_real_name
        {
            set { _teachers_real_name = value; }
            get { return _teachers_real_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appoint_begin_time
        {
            set { _appoint_begin_time = value; }
            get { return _appoint_begin_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appoint_end_time
        {
            set { _appoint_end_time = value; }
            get { return _appoint_end_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string training_content
        {
            set { _training_content = value; }
            get { return _training_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string total_num
        {
            set { _total_num = value; }
            get { return _total_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string class_num
        {
            set { _class_num = value; }
            get { return _class_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string each_class_num
        {
            set { _each_class_num = value; }
            get { return _each_class_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string comment
        {
            set { _comment = value; }
            get { return _comment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string is_pass
        {
            set { _is_pass = value; }
            get { return _is_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
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
        public string dept_code
        {
            set { _dept_code = value; }
            get { return _dept_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dept_name
        {
            set { _dept_name = value; }
            get { return _dept_name; }
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
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsReceive
        {
            set { _isreceive = value; }
            get { return _isreceive; }
        }
    }
}
