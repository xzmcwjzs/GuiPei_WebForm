using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class BasesModel
    {
        #region Model
        private string _bases_id = "newid";
        private string _bases_name;
        private string _bases_password;
        private string _bases_real_name;
        private string _training_base_code;
        private string _training_base_name;
        private string _professional_base_code;
        private string _professional_base_name;
        /// <summary>
        /// 
        /// </summary>
        public string bases_id
        {
            set { _bases_id = value; }
            get { return _bases_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bases_name
        {
            set { _bases_name = value; }
            get { return _bases_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bases_password
        {
            set { _bases_password = value; }
            get { return _bases_password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bases_real_name
        {
            set { _bases_real_name = value; }
            get { return _bases_real_name; }
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
        #endregion Model
    }
}
