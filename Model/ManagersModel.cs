using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class ManagersModel
    {
        #region Model
        private string _managers_id = "newid";
        private string _managers_name;
        private string _managers_password;
        private string _managers_real_name;
        private string _training_base_code;
        private string _training_base_name;
        /// <summary>
        /// 
        /// </summary>
        public string managers_id
        {
            set { _managers_id = value; }
            get { return _managers_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string managers_name
        {
            set { _managers_name = value; }
            get { return _managers_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string managers_password
        {
            set { _managers_password = value; }
            get { return _managers_password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string managers_real_name
        {
            set { _managers_real_name = value; }
            get { return _managers_real_name; }
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
