using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class DiseaseRegisterModel
    {
        #region Model
        private string _id = "newid";
        private string _professional_base_code;
        private string _professional_base_name;
        private string _dept_code;
        private string _dept_name;
        private string _dept_time;
        private string _is_required;
        private string _disease_code;
        private string _disease_name;
        private string _required_num;
        private string _master_degree;
        private string _manage_patient;
        private string _full_manage;
        private string _outpatient;
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
        /// <summary>
        /// 
        /// </summary>
        public string disease_code
        {
            set { _disease_code = value; }
            get { return _disease_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string disease_name
        {
            set { _disease_name = value; }
            get { return _disease_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string required_num
        {
            set { _required_num = value; }
            get { return _required_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string master_degree
        {
            set { _master_degree = value; }
            get { return _master_degree; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string manage_patient
        {
            set { _manage_patient = value; }
            get { return _manage_patient; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string full_manage
        {
            set { _full_manage = value; }
            get { return _full_manage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string outpatient
        {
            set { _outpatient = value; }
            get { return _outpatient; }
        }
        #endregion Model

    }
}
