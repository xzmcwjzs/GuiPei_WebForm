<%@ WebHandler Language="C#" Class="GetPersonalInfo" %>

using System;
using System.Web;
using BLL;
using Model;
using Common;
using System.Data;

public class GetPersonalInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string Name = context.Request["Name"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];

        StudentsPersonalInformation2BLL bll = new StudentsPersonalInformation2BLL();
        DataTable dt = new DataTable();
        string jsonRes;
        dt = bll.GetDtByNT(Name, TrainingBaseCode);
        if (dt == null)
        {
            jsonRes = "";
        }
        else
        {
            jsonRes = Common.JsonHelper.ToJson(dt);
        }
        context.Response.Write(jsonRes);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}