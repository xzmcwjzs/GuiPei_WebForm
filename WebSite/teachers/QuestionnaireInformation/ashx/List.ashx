<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class List : IHttpHandler {

    QuestionnaireBLL questionnaireBLL = new QuestionnaireBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        string DeptCode = context.Request["DeptCode"];
        string RealName = context.Request["RealName"];
        
        int pageIndex = context.Request["pageIndex"] != null ? int.Parse(context.Request["pageIndex"]) : 1;
        int pageSize = 5;
        int pageCount = questionnaireBLL.GetPageCount(pageSize,TrainingBaseCode,ProfessionalBaseCode,DeptCode,RealName);
        int recordCount = questionnaireBLL.GetRecordCount(TrainingBaseCode,ProfessionalBaseCode,DeptCode,RealName);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
        List<QuestionnaireModel> list = questionnaireBLL.GetPageAdviceList(pageIndex,pageSize,TrainingBaseCode,ProfessionalBaseCode,DeptCode,RealName);

        string strJsonArr = new JavaScriptSerializer().Serialize(list);

        string strRes = "{'data':" + strJsonArr + ",'recordCount':" + recordCount + ",'pageCount':" + pageCount + "}";

        context.Response.Write(strRes);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}