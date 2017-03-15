using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class NeiKeOptionModel
    {
        private string _id = "newid";
        private string _subjectname;
        private string _subjectcode;
        private string _question;
        private string _questiontype;
        private string _optiona;
        private string _optionb;
        private string _optionc;
        private string _optiond;
        private string _optione;
        private string _correctanswer;
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
        public string Question
        {
            set { _question = value; }
            get { return _question; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuestionType
        {
            set { _questiontype = value; }
            get { return _questiontype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OptionA
        {
            set { _optiona = value; }
            get { return _optiona; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OptionB
        {
            set { _optionb = value; }
            get { return _optionb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OptionC
        {
            set { _optionc = value; }
            get { return _optionc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OptionD
        {
            set { _optiond = value; }
            get { return _optiond; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OptionE
        {
            set { _optione = value; }
            get { return _optione; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CorrectAnswer
        {
            set { _correctanswer = value; }
            get { return _correctanswer; }
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
