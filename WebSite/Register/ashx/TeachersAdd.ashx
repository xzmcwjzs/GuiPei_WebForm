<%@ WebHandler Language="C#" Class="TeachersAdd" %>

using System;
using System.Web;
using Model;
using BLL;
using Common;

public class TeachersAdd : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        LoginBLL bll = new LoginBLL();
        LoginModel model = new LoginModel();

        model.id = Guid.NewGuid().ToString();
        model.name = context.Request["TeachersName"].ToString();
        model.real_name = context.Request["TeachersRealName"].ToString();
        model.password = context.Request["TeachersPassword"].ToString();
        model.training_base_code = context.Request["TeachersTrainingBaseCode"].ToString();
        model.training_base_name = context.Request["TeachersTrainingBaseName"].ToString();
        model.professional_base_code = context.Request["TeachersProfessionalBaseCode"].ToString();
        model.professional_base_name = context.Request["TeachersProfessionalBaseName"].ToString();
        model.dept_code = context.Request["TeachersDeptCode"].ToString();
        model.dept_name = context.Request["TeachersDeptName"].ToString();
        model.type = "teachers";
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