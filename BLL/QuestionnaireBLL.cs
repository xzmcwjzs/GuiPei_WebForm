using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public class QuestionnaireBLL
    {
       QuestionnaireDAL questionnaireDAL=new QuestionnaireDAL();
       public bool InsertQuestionnaire(Model.QuestionnaireModel model)
       {
           return questionnaireDAL.InsertQuestionnaire(model);
       }
       /// <summary>
       /// 获取分页数据
       /// </summary>
       /// <param name="pageIndex">当前页码值</param>
       /// <param name="pageSize">每页显示数据</param>
       /// <returns></returns>
       public List<QuestionnaireModel> GetPageAdviceList(int pageIndex, int pageSize,string TrainingBaseCode,string ProfessionalBaseCode,string DeptCode,string RealName)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<QuestionnaireModel> list = questionnaireDAL.GetPageAdviceList(start, end, TrainingBaseCode, ProfessionalBaseCode, DeptCode, RealName);
           return list;
       }
       /// <summary>
       /// 获取总的页数
       /// </summary>
       /// <returns></returns>
       public int GetPageCount(int pageSize, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string RealName)
       {
           int recordCount = questionnaireDAL.GetRecordCount(TrainingBaseCode,ProfessionalBaseCode,DeptCode,RealName);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount/pageSize));

           return pageCount;
       }

       public int GetRecordCount(string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string RealName)
       {
           return questionnaireDAL.GetRecordCount(TrainingBaseCode, ProfessionalBaseCode, DeptCode, RealName);
       }


       public List<QuestionnaireModel> GetPageAdviceListM(int pageIndex, int pageSize, string TrainingBaseCode)
       {
           int start = (pageIndex - 1) * pageSize + 1;
           int end = pageIndex * pageSize;
           List<QuestionnaireModel> list = questionnaireDAL.GetPageAdviceListM(start, end, TrainingBaseCode);
           return list;
       }
       
       public int GetPageCountM(int pageSize, string TrainingBaseCode)
       {
           int recordCount = questionnaireDAL.GetRecordCountM(TrainingBaseCode);
           int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));

           return pageCount;
       }

       public int GetRecordCountM(string TrainingBaseCode)
       {
           return questionnaireDAL.GetRecordCountM(TrainingBaseCode);
       }
    }
}
