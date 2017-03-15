<%@ WebHandler Language="C#" Class="Dept" %>

using System;
using System.Web;
using Model;
using BLL;
using Common;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class Dept : IHttpHandler {
    DeptManagementBLL bll = new DeptManagementBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string TrainingTime = context.Request["TrainingTime"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];

        List<DeptManagementModel> list = bll.GetDeptList(TrainingTime, TrainingBaseCode, ProfessionalBaseCode);

        string strJson = new JavaScriptSerializer().Serialize(list);
        string strRes = "{'data':"+strJson+"}";
        context.Response.Write(strRes);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}