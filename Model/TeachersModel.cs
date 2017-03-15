using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class TeachersModel
    {
        #region Model
        private string _teachers_id = "newid";
        private string _teachers_name;
        private string _teachers_password;
        private string _teachers_real_name;
        private string _training_base_code;
        private string _training_base_name;
        private string _professional_base_code;
        private string _professional_base_name;
        private string _dept_code;
        private string _dept_name;
        /// <summary>
        /// 
        /// </summary>
        public string teachers_id
        {
            set { _teachers_id = value; }
            get { return _teachers_id; }
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
        public string teachers_password
        {
            set { _teachers_password = value; }
            get { return _teachers_password; }
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
        #endregion Model
    }
}
