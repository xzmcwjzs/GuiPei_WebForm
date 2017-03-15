using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class OutDeptExamModel
    {
        #region Model
       private string _id= "newid";
		private string _students_name;
		private string _students_real_name;
		private string _sex;
		private string _training_base_code;
		private string _training_base_name;
		private string _high_education;
		private string _high_education_time;
		private string _professional_base_code;
		private string _professional_base_name;
		private string _rotary_dept_code;
		private string _rotary_dept_name;
		private string _rotary_begin_time;
		private string _rotary_end_time;
		private string _instructor;
		private string _instructor_tag;
		private string _kqqk;
		private string _gztd;
		private string _ydyf;
		private string _llsp;
		private string _zdzx;
		private string _blsx;
		private string _clbrnl;
		private string _sjcznl;
		private string _czjn;
		private string _zdsp;
		private string _djnl;
		private string _total_score;
		private string _instructor_date;
		private string _is_pass;
		private string _dept_manager;
		private string _dept_manager_date;
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
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
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
		public string training_base_name
		{
			set{ _training_base_name=value;}
			get{return _training_base_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string high_education
		{
			set{ _high_education=value;}
			get{return _high_education;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string high_education_time
		{
			set{ _high_education_time=value;}
			get{return _high_education_time;}
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
		public string professional_base_name
		{
			set{ _professional_base_name=value;}
			get{return _professional_base_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rotary_dept_code
		{
			set{ _rotary_dept_code=value;}
			get{return _rotary_dept_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rotary_dept_name
		{
			set{ _rotary_dept_name=value;}
			get{return _rotary_dept_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rotary_begin_time
		{
			set{ _rotary_begin_time=value;}
			get{return _rotary_begin_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rotary_end_time
		{
			set{ _rotary_end_time=value;}
			get{return _rotary_end_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string instructor
		{
			set{ _instructor=value;}
			get{return _instructor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string instructor_tag
		{
			set{ _instructor_tag=value;}
			get{return _instructor_tag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kqqk
		{
			set{ _kqqk=value;}
			get{return _kqqk;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gztd
		{
			set{ _gztd=value;}
			get{return _gztd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ydyf
		{
			set{ _ydyf=value;}
			get{return _ydyf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string llsp
		{
			set{ _llsp=value;}
			get{return _llsp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zdzx
		{
			set{ _zdzx=value;}
			get{return _zdzx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string blsx
		{
			set{ _blsx=value;}
			get{return _blsx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string clbrnl
		{
			set{ _clbrnl=value;}
			get{return _clbrnl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sjcznl
		{
			set{ _sjcznl=value;}
			get{return _sjcznl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string czjn
		{
			set{ _czjn=value;}
			get{return _czjn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zdsp
		{
			set{ _zdsp=value;}
			get{return _zdsp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string djnl
		{
			set{ _djnl=value;}
			get{return _djnl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string total_score
		{
			set{ _total_score=value;}
			get{return _total_score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string instructor_date
		{
			set{ _instructor_date=value;}
			get{return _instructor_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string is_pass
		{
			set{ _is_pass=value;}
			get{return _is_pass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dept_manager
		{
			set{ _dept_manager=value;}
			get{return _dept_manager;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dept_manager_date
		{
			set{ _dept_manager_date=value;}
			get{return _dept_manager_date;}
		}
		
        #endregion
    }
}
