<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using Common;

public class List : IHttpHandler {
    RotaryScheduleBLL bll = new RotaryScheduleBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string TrainingTime = context.Request["TrainingTime"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];

        int pageCount = bll.GetPageCount(pageSize, TrainingBaseCode,ProfessionalBaseCode,TrainingTime);
        int recordCount = bll.GetRecordCount(TrainingBaseCode, ProfessionalBaseCode, TrainingTime);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.RotaryScheduleModel> list = new BLL.RotaryScheduleBLL().GetPagedList(TrainingBaseCode,ProfessionalBaseCode,TrainingTime, pageIndex, pageSize);

        string strJsonArr = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

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