<%@ WebHandler Language="C#" Class="BasesAdd" %>

using System;
using System.Web;
using Model;
using BLL;
using Common;

public class BasesAdd : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        LoginBLL bll = new LoginBLL();
        LoginModel model = new LoginModel();

        model.id = Guid.NewGuid().ToString();
        model.name = context.Request["BasesName"].ToString();
        model.real_name = context.Request["BasesRealName"].ToString();
        model.password = context.Request["BasesPassword"].ToString();
        model.training_base_code = context.Request["BasesTrainingBaseCode"].ToString();
        model.training_base_name = context.Request["BasesTrainingBaseName"].ToString();
        model.professional_base_code = context.Request["BasesProfessionalBaseCode"].ToString();
        model.professional_base_name = context.Request["BasesProfessionalBaseName"].ToString();
        
        model.type = "bases";
        model.LoginState = "0";
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