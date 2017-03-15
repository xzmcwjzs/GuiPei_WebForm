<%@ WebHandler Language="C#" Class="GetRotaryInfo" %>

using System;
using System.Web;
using BLL;
using Model;
using Common;
using System.Data;

public class GetRotaryInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        string TrainingTime = context.Request["TrainingTime"];
        RotaryScheduleBLL bll = new RotaryScheduleBLL();
        string jsonRes;
        DataTable dt = new DataTable();
        dt = bll.GetDtByTTP(TrainingTime, TrainingBaseCode, ProfessionalBaseCode);
        if (dt == null)
        {
            jsonRes = "";
        }
        else
        {
            jsonRes = JsonHelper.ToJson(dt);
        }
        context.Response.Write(jsonRes);
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}