using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class StudentsPersonalInformationModel
    {
        #region Model
        private string _id = "newid";
        private string _name;
        private string _real_name;
        private string _sex;
        private string _age;
        private string _datebirth;
        private string _minzu;
        private string _province;
        private string _city;
        private string _area;
        private string _detail_address;
        private string _id_number;
        private string _telephon;
        private string _mail;
        private string _bk_school;
        private string _bk_major;
        private string _graduation_time;
        private string _high_education;
        private string _high_school;
        private string _high_major;
        private string _high_education_time;
        private string _identity_type;
        private string _send_unit;
        private string _training_base_province_code;
        private string _training_base_province_name;
        private string _training_base_code;
        private string _training_base_name;
        private string _collaborative_unit;
        private string _professional_base_name;
        private string _professional_base_code;
        private string _training_time;
        private string _plan_training_time;
        private string _writor;
        private string _register_date;
        private string _urgent;
        private string _urgent_telephon;
        private string _image_path;
        private string _province_code;
        private string _city_code;
        private string _area_code;
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
        public string real_name
        {
            set { _real_name = value; }
            get { return _real_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string datebirth
        {
            set { _datebirth = value; }
            get { return _datebirth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string minzu
        {
            set { _minzu = value; }
            get { return _minzu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string detail_address
        {
            set { _detail_address = value; }
            get { return _detail_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string id_number
        {
            set { _id_number = value; }
            get { return _id_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string telephon
        {
            set { _telephon = value; }
            get { return _telephon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mail
        {
            set { _mail = value; }
            get { return _mail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bk_school
        {
            set { _bk_school = value; }
            get { return _bk_school; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bk_major
        {
            set { _bk_major = value; }
            get { return _bk_major; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string graduation_time
        {
            set { _graduation_time = value; }
            get { return _graduation_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string high_education
        {
            set { _high_education = value; }
            get { return _high_education; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string high_school
        {
            set { _high_school = value; }
            get { return _high_school; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string high_major
        {
            set { _high_major = value; }
            get { return _high_major; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string high_education_time
        {
            set { _high_education_time = value; }
            get { return _high_education_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string identity_type
        {
            set { _identity_type = value; }
            get { return _identity_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string send_unit
        {
            set { _send_unit = value; }
            get { return _send_unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string training_base_province_code
        {
            set { _training_base_province_code = value; }
            get { return _training_base_province_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string training_base_province_name
        {
            set { _training_base_province_name = value; }
            get { return _training_base_province_name; }
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
        public string collaborative_unit
        {
            set { _collaborative_unit = value; }
            get { return _collaborative_unit; }
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
        public string training_time
        {
            set { _training_time = value; }
            get { return _training_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string plan_training_time
        {
            set { _plan_training_time = value; }
            get { return _plan_training_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string writor
        {
            set { _writor = value; }
            get { return _writor; }
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
        public string urgent
        {
            set { _urgent = value; }
            get { return _urgent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string urgent_telephon
        {
            set { _urgent_telephon = value; }
            get { return _urgent_telephon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string image_path
        {
            set { _image_path = value; }
            get { return _image_path; }
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
        public string city_code
        {
            set { _city_code = value; }
            get { return _city_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string area_code
        {
            set { _area_code = value; }
            get { return _area_code; }
        }
        #endregion Model
    }
}
