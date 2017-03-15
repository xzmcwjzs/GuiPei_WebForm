<%@ WebHandler Language="C#" Class="StudentsAdd" %>

using System;
using System.Web;
using Model;
using BLL;
using Common;

public class StudentsAdd : IHttpHandler
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        LoginBLL bll = new LoginBLL();
        LoginModel model = new LoginModel();

        model.id = Guid.NewGuid().ToString();
        model.name = context.Request["StudentsName"].ToString();
        model.real_name = context.Request["StudentsRealName"].ToString();
        model.password = context.Request["StudentsPassword"].ToString();
        model.training_base_code = context.Request["StudentsTrainingBaseCode"].ToString();
        model.training_base_name = context.Request["StudentsTrainingBaseName"].ToString();
        model.type = "students";
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