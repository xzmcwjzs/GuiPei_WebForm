using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class DiseaseRegister2Model
    {
        private string _id= "newid";
		private string _students_name;
		private string _students_real_name;
		private string _training_base_name;
		private string _professional_base_name;
		private string _dept_name;
		private string _disease_name;
		private string _required_num;
		private string _real_num;
		private string _master_degree;
		private string _patient_name;
		private string _case_num;
		private string _main_diagnosis;
		private string _secondary_diagnosis;
		private string _is_charge;
		private string _is_rescue;
		private string _cure_measure;
		private string _visit_date;
		private string _comment;
		private string _writor;
		private string _register_date;
		private string _training_base_code;
		private string _professional_base_code;
		private string _dept_code;
		private string _teacher_check;
		private string _kzr_check;
		private string _base_check;
		private string _manage_check;
        private string _condition;
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

        public string condition
        {
            set { _condition = value; }
            get { return _condition; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string students_name
		{
			set{ _students_name=value;}
			get{return _students_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string students_real_name
		{
			set{ _students_real_name=value;}
			get{return _students_real_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string training_base_name
		{
			set{ _training_base_name=value;}
			get{return _training_base_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string professional_base_name
		{
			set{ _professional_base_name=value;}
			get{return _professional_base_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dept_name
		{
			set{ _dept_name=value;}
			get{return _dept_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string disease_name
		{
			set{ _disease_name=value;}
			get{return _disease_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string required_num
		{
			set{ _required_num=value;}
			get{return _required_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string real_num
		{
			set{ _real_num=value;}
			get{return _real_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string master_degree
		{
			set{ _master_degree=value;}
			get{return _master_degree;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string patient_name
		{
			set{ _patient_name=value;}
			get{return _patient_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string case_num
		{
			set{ _case_num=value;}
			get{return _case_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string main_diagnosis
		{
			set{ _main_diagnosis=value;}
			get{return _main_diagnosis;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string secondary_diagnosis
		{
			set{ _secondary_diagnosis=value;}
			get{return _secondary_diagnosis;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string is_charge
		{
			set{ _is_charge=value;}
			get{return _is_charge;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string is_rescue
		{
			set{ _is_rescue=value;}
			get{return _is_rescue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cure_measure
		{
			set{ _cure_measure=value;}
			get{return _cure_measure;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string visit_date
		{
			set{ _visit_date=value;}
			get{return _visit_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string writor
		{
			set{ _writor=value;}
			get{return _writor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string register_date
		{
			set{ _register_date=value;}
			get{return _register_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string training_base_code
		{
			set{ _training_base_code=value;}
			get{return _training_base_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string professional_base_code
		{
			set{ _professional_base_code=value;}
			get{return _professional_base_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dept_code
		{
			set{ _dept_code=value;}
			get{return _dept_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string teacher_check
		{
			set{ _teacher_check=value;}
			get{return _teacher_check;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kzr_check
		{
			set{ _kzr_check=value;}
			get{return _kzr_check;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string base_check
		{
			set{ _base_check=value;}
			get{return _base_check;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string manage_check
		{
			set{ _manage_check=value;}
			get{return _manage_check;}
		}
		
    }
}
