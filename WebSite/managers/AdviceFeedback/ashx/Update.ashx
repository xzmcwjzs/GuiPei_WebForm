<%@ WebHandler Language="C#" Class="Update" %>

using System;
using System.Web;
using Model;
using System.Web.Script.Serialization;
using BLL;
using System.Web.SessionState;
using Common;
using System.Collections.Generic;

public class Update : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        AdviceFeedbackModel adviceFeedbackModel = new AdviceFeedbackModel();
        AdviceFeedbackBLL adviceFeedbackBLL = new AdviceFeedbackBLL();
        adviceFeedbackModel.Id = context.Request["Id"]; ;


        adviceFeedbackModel.ManagerReply = context.Request["ManagerReply"];
        adviceFeedbackModel.ManagerName = context.Request["ManagerName"];

        adviceFeedbackModel.ManagerDate = context.Request["ManagerDate"];
        adviceFeedbackModel.ManagerHandle = "已处理";
        if (adviceFeedbackBLL.ManagerReply(adviceFeedbackModel))
        {
            context.Response.Write("updateSuccess");
        }
        else
        {
            context.Response.Write("updateError");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}