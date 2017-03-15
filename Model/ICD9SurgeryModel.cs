using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class ICD9SurgeryModel
    {
        private string _id = "newid";
        private string _icd9;
        private string _surgeryname;
        private string _property;
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
        public string ICD9
        {
            set { _icd9 = value; }
            get { return _icd9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SurgeryName
        {
            set { _surgeryname = value; }
            get { return _surgeryname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Property
        {
            set { _property = value; }
            get { return _property; }
        }
    }
}
