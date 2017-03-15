<%@ WebHandler Language="C#" Class="Del" %>

using System;
using System.Web;
using BLL;
using Common;

public class Del : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        AdviceFeedbackBLL adviceFeedbackBLL = new AdviceFeedbackBLL();
        string id =CommonFunc.SafeGetStringFromObj(context.Request["id"]);
        if (adviceFeedbackBLL.Delete(id))
        {
            context.Response.Write("delSuccess");
        }
        else
        {
            context.Response.Write("delError");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}