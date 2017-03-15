using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class LoginModel
    {
        private string _id = "newid";
        private string _name;
        private string _password;
        private string _real_name;
        private string _training_base_name;
        private string _training_base_code;
        private string _professional_base_name;
        private string _professional_base_code;
        private string _dept_name;
        private string _dept_code;
        private string _type;
        private string _loginstate;
        private string _registerdate;
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
        public string password
        {
            set { _password = value; }
            get { return _password; }
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
        public string training_base_name
        {
            set { _training_base_name = value; }
            get { return _training_base_name; }
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
        public string professional_base_name
        {
            set { _professional_base_name = value; }
            get { return _professional_base_name; }
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
        public string dept_name
        {
            set { _dept_name = value; }
            get { return _dept_name; }
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
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginState
        {
            set { _loginstate = value; }
            get { return _loginstate; }
        }

        public string RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
        }

    }
}
