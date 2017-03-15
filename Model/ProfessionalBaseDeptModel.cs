using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class ProfessionalBaseDeptModel
    {
        #region Model
        private string _id = "newid";
        private string _professional_base_code;
        private string _professional_base_name;
        private string _dept_code;
        private string _dept_name;
        private string _dept_time;
        private string _is_required;
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
        public string dept_time
        {
            set { _dept_time = value; }
            get { return _dept_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string is_required
        {
            set { _is_required = value; }
            get { return _is_required; }
        }
        #endregion Model

    }
}
