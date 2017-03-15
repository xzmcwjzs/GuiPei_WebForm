using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class BedManagementModel
    {
        private string _id = "newid";
        private string _students_name;
        private string _students_real_name;
        private string _training_base_code;
        private string _training_base_name;
        private string _professional_base_code;
        private string _professional_base_name;
        private string _dept_code;
        private string _dept_name;
        private string _patient_name;
        private string _patient_id;
        private string _bed_id;
        private string _bed_card;
        private string _bed_price;
        private string _bed_status;
        private string _room_id;
        private string _building_id;
        private string _comment;
        private string _writor;
        private string _register_date;
        private string _teacher_check;
        private string _kzr_check;
        private string _base_check;
        private string _manager_check;
        private string _teacherid;
        private string _teachername;
        /// <summary>
        /// 
        /// </summary>
        ///
        public string TeacherId
        {
            set { _teacherid = value; }
            get { return _teacherid; }
        }
        public string TeacherName
        {
            set { _teachername = value; }
            get { return _teachername; }
        }
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
        /// <summary>
        /// 
        /// </summary>
        public string patient_name
        {
            set { _patient_name = value; }
            get { return _patient_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string patient_id
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bed_id
        {
            set { _bed_id = value; }
            get { return _bed_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bed_card
        {
            set { _bed_card = value; }
            get { return _bed_card; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bed_price
        {
            set { _bed_price = value; }
            get { return _bed_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bed_status
        {
            set { _bed_status = value; }
            get { return _bed_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string room_id
        {
            set { _room_id = value; }
            get { return _room_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string building_id
        {
            set { _building_id = value; }
            get { return _building_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string comment
        {
            set { _comment = value; }
            get { return _comment; }
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
        public string teacher_check
        {
            set { _teacher_check = value; }
            get { return _teacher_check; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kzr_check
        {
            set { _kzr_check = value; }
            get { return _kzr_check; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string base_check
        {
            set { _base_check = value; }
            get { return _base_check; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string manager_check
        {
            set { _manager_check = value; }
            get { return _manager_check; }
        }
    }
}
