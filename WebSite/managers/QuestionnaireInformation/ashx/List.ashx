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
        
        int pageIndex = context.Request["pageIndex"] != null ? int.Parse(context.Request["pageIndex"]) : 1;
        int pageSize = 5;
        int pageCount = questionnaireBLL.GetPageCountM(pageSize,TrainingBaseCode);
        int recordCount = questionnaireBLL.GetRecordCountM(TrainingBaseCode);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
        List<QuestionnaireModel> list = questionnaireBLL.GetPageAdviceListM(pageIndex,pageSize,TrainingBaseCode);

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