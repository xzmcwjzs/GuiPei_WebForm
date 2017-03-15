using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   [Serializable]
   public class StudentsModel
    {
        #region Model
        private string _students_id = "newid";
        private string _students_name;
        private string _students_real_name;
        private string _students_password;
        private string _training_base_code;
        private string _training_base_name;
        /// <summary>
        /// 
        /// </summary>
        public string students_id
        {
            set { _students_id = value; }
            get { return _students_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string students_name
        {
            set { _students_name = value; }
            get { return _students_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string students_real_name
        {
            set { _students_real_name = value; }
            get { return _students_real_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string students_password
        {
            set { _students_password = value; }
            get { return _students_password; }
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
        #endregion Model

    }
}
