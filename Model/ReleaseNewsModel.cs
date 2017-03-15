using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class ReleaseNewsModel
    {

       private string _id= "newid";
		private string _trainingbasecode;
		private string _trainingbasename;
		private string _managersname;
		private string _managersrealname;
		private string _writor;
		private string _registerdate;
		private string _newstitle;
		private string _newscontent;
		private string _filepath;
		private string _filename;
		private string _students;
		private string _teachers;
		private string _bases;
		private string _tag1;
		private string _tag2;
		private string _tag3;
		/// <summary>
		/// 
		/// </summary>
		public string Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrainingBaseCode
		{
			set{ _trainingbasecode=value;}
			get{return _trainingbasecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrainingBaseName
		{
			set{ _trainingbasename=value;}
			get{return _trainingbasename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ManagersName
		{
			set{ _managersname=value;}
			get{return _managersname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ManagersRealName
		{
			set{ _managersrealname=value;}
			get{return _managersrealname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Writor
		{
			set{ _writor=value;}
			get{return _writor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RegisterDate
		{
			set{ _registerdate=value;}
			get{return _registerdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsTitle
		{
			set{ _newstitle=value;}
			get{return _newstitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsContent
		{
			set{ _newscontent=value;}
			get{return _newscontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilePath
		{
			set{ _filepath=value;}
			get{return _filepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Students
		{
			set{ _students=value;}
			get{return _students;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Teachers
		{
			set{ _teachers=value;}
			get{return _teachers;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Bases
		{
			set{ _bases=value;}
			get{return _bases;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tag1
		{
			set{ _tag1=value;}
			get{return _tag1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tag2
		{
			set{ _tag2=value;}
			get{return _tag2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tag3
		{
			set{ _tag3=value;}
			get{return _tag3;}
		}
    }
}
