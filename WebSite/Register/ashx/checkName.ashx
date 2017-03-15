<%@ WebHandler Language="C#" Class="checkName" %>

using System;
using System.Web;
using BLL;

public class checkName : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        string name = context.Request["name"];
        LoginBLL bll = new LoginBLL();
        bool result = bll.checkName(name);
        if (result)
        {
            context.Response.Write("1");
        }
        else
        {
            context.Response.Write("0");
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}