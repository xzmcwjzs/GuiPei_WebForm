using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class TiKuResultModel
    {
        private string _id = "newid";
        private string _studentsname;
        private string _studentsrealname;
        private string _trainingbasecode;
        private string _trainingbasename;
        private string _subjectname;
        private string _subjectcode;
        private string _totalscore;
        private string _totalnum;
        private string _undonum;
        private string _correctnum;
        private string _errornum;
        private string _registerdate;
        private string _tag1;
        private string _tag2;
        private string _tag3;
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
        public string StudentsName
        {
            set { _studentsname = value; }
            get { return _studentsname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StudentsRealName
        {
            set { _studentsrealname = value; }
            get { return _studentsrealname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrainingBaseCode
        {
            set { _trainingbasecode = value; }
            get { return _trainingbasecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrainingBaseName
        {
            set { _trainingbasename = value; }
            get { return _trainingbasename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubjectName
        {
            set { _subjectname = value; }
            get { return _subjectname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubjectCode
        {
            set { _subjectcode = value; }
            get { return _subjectcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TotalScore
        {
            set { _totalscore = value; }
            get { return _totalscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TotalNum
        {
            set { _totalnum = value; }
            get { return _totalnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UndoNum
        {
            set { _undonum = value; }
            get { return _undonum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CorrectNum
        {
            set { _correctnum = value; }
            get { return _correctnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorNum
        {
            set { _errornum = value; }
            get { return _errornum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag1
        {
            set { _tag1 = value; }
            get { return _tag1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag2
        {
            set { _tag2 = value; }
            get { return _tag2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag3
        {
            set { _tag3 = value; }
            get { return _tag3; }
        }
    }
}
