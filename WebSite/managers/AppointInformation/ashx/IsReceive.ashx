<%@ WebHandler Language="C#" Class="IsReceive" %>

using System;
using System.Web;
using BLL;
using Model;
using Common;

public class IsReceive : IHttpHandler {
    TeachersAppointInformationBLL bll = new TeachersAppointInformationBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string id = CommonFunc.SafeGetStringFromObj(context.Request["id"]);
        string check = CommonFunc.SafeGetStringFromObj(context.Request["check"]);
        if (check == "未接收")
        {
            check = "已接收";
        }
        else
        {
            return;
        }
        
        if (bll.UpdateIsReceive(id,check))
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