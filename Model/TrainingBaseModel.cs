using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class TrainingBaseModel
    {
        #region Model
        private string _id = "newid";
        private string _province_code;
        private string _province_name;
        private string _hospital_code;
        private string _hospital_name;
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
        public string province_code
        {
            set { _province_code = value; }
            get { return _province_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string province_name
        {
            set { _province_name = value; }
            get { return _province_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hospital_code
        {
            set { _hospital_code = value; }
            get { return _hospital_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hospital_name
        {
            set { _hospital_name = value; }
            get { return _hospital_name; }
        }
        #endregion Model
    }
}
