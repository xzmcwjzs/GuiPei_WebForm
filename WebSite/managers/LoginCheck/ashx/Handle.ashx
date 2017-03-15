<%@ WebHandler Language="C#" Class="Handle" %>

using System;
using System.Web;
using Common;
using Model;
using BLL;

public class Handle : IHttpHandler {
    LoginBLL bll = new LoginBLL();
    LoginModel model = new LoginModel();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string id =CommonFunc.SafeGetStringFromObj(context.Request["id"]);
        string check = CommonFunc.SafeGetStringFromObj(context.Request["check"]);
        if (check == "1")
        {
            check = "0";
        }
        else
        {
            check = "1";
        }
        model.id=id;
        model.LoginState=check;
        if (bll.UpdateLoginState(model))
        {
            context.Response.Write("checkSuccess");
            context.Response.End();
        }
        else
        {
            context.Response.Write("checkError");
            context.Response.End();
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}