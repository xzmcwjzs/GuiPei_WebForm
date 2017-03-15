<%@ WebHandler Language="C#" Class="GetPassword" %>

using System;
using System.Web;
using BLL;

public class GetPassword : IHttpHandler {
    LoginBLL bll = new LoginBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string Name=context.Request["Name"];
        string RealName=context.Request["RealName"];
        string password = bll.GetPassword(Name, RealName);
        context.Response.Write(password);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}