<%@ WebHandler Language="C#" Class="Add" %>

using System;
using System.Web;
using Model;
using System.Web.Script.Serialization;
using BLL;
using System.Web.SessionState;
using Common;
using System.Collections.Generic;

public class Add : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        AdviceFeedbackModel adviceFeedbackModel = new AdviceFeedbackModel();
        AdviceFeedbackBLL adviceFeedbackBLL = new AdviceFeedbackBLL();
        adviceFeedbackModel.Id = Guid.NewGuid().ToString();
        adviceFeedbackModel.StudentsRealName = context.Request["StudentsRealName"];
        adviceFeedbackModel.StudentsName = context.Request["StudentsName"];
        adviceFeedbackModel.TrainingBaseCode = context.Request["TrainingBaseCode"];
        adviceFeedbackModel.TrainingBaseName = context.Request["TrainingBaseName"];
        adviceFeedbackModel.ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        adviceFeedbackModel.ProfessionalBaseName = context.Request["ProfessionalBaseName"];
        adviceFeedbackModel.DeptCode = context.Request["RotaryDept"];
        adviceFeedbackModel.DeptName = context.Request["DeptName"];
        adviceFeedbackModel.RegisterDate = context.Request["RegisterDate"];
        adviceFeedbackModel.Writor = context.Request["Writor"];
        adviceFeedbackModel.TeacherCheck = "未通过";
        adviceFeedbackModel.KzrCheck = "未通过";
        adviceFeedbackModel.BaseCheck = "未通过";
        adviceFeedbackModel.ManagerCheck = "未通过";
        adviceFeedbackModel.TeacherId = context.Request["Teacher"];
        adviceFeedbackModel.TeacherName = context.Request["TeacherName"];

        adviceFeedbackModel.FeedbackInformation = context.Request["FeedbackInformation"];
        adviceFeedbackModel.ManagerHandle = "未处理";
        if (adviceFeedbackBLL.Add(adviceFeedbackModel))
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