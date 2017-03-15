<%@ WebHandler Language="C#" Class="Handle" %>

using System;
using System.Web;
using Common;
using Model;
using BLL;

public class Handle : IHttpHandler {
    InDeptFellingBLL bll = null;
    InDeptFellingModel model = null;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string id =CommonFunc.SafeGetStringFromObj(context.Request["id"]);
        string check = CommonFunc.SafeGetStringFromObj(context.Request["check"]);
        if (check == "未通过")
        {
            check = "已通过";
        }
        else
        {
            check = "未通过";
        }
        bll = new InDeptFellingBLL();
        model = new InDeptFellingModel();
        model.id=id;
        model.teacher_status=check;
        if (bll.UpdateCheckByTeacher(model))
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