<%@ WebHandler Language="C#" Class="ManagersAdd" %>

using System;
using System.Web;
using Model;
using BLL;
using Common;

public class ManagersAdd : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        LoginBLL bll = new LoginBLL();
        LoginModel model = new LoginModel();

        model.id = Guid.NewGuid().ToString();
        model.name = context.Request["ManagersName"].ToString();
        model.real_name = context.Request["ManagersRealName"].ToString();
        model.password = context.Request["ManagersPassword"].ToString();
        model.training_base_code = context.Request["ManagersTrainingBaseCode"].ToString();
        model.training_base_name = context.Request["ManagersTrainingBaseName"].ToString();
        
        model.type = "managers";
        model.LoginState = "1";
        model.RegisterDate = DateTime.Now.Year.ToString();
        if (bll.Add(model))
        {
            context.Response.Write("addSuccess");
        }
        else
        {
            context.Response.Write("addError");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}