<%@ WebHandler Language="C#" Class="GetRotaryInfo2" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Data;
using System.Collections.Generic;

public class GetRotaryInfo2 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string Name = context.Request["Name"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];

        StudentsRotaryInformation2BLL bll = new StudentsRotaryInformation2BLL();
        DataTable dt = new DataTable();
        string strRes;

        dt = bll.GetDtByNT(Name, TrainingBaseCode);
        if (dt == null)
        {
            strRes = "";
        }
        else
        {
            strRes = Common.JsonHelper.ToJson(dt);
        }
        context.Response.Write(strRes);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}