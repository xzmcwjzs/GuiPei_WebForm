<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using Common;
using System.Collections.Generic;

public class List : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        RotaryScheduleBLL bll = new RotaryScheduleBLL();
        string TrainingTime = context.Request["TrainingTime"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];

        List<RotaryScheduleModel> list = bll.GetSchemeList(TrainingTime, TrainingBaseCode, ProfessionalBaseCode);

        string strJson = new JavaScriptSerializer().Serialize(list);
        string strRes = "{'data':" + strJson + "}";
        context.Response.Write(strRes);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}