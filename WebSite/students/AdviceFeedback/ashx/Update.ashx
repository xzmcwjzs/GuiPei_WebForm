<%@ WebHandler Language="C#" Class="Update" %>

using System;
using System.Web;
using Model;
using System.Web.Script.Serialization;
using BLL;
using System.Web.SessionState;
using Common;
using System.Collections.Generic;

public class Update : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        AdviceFeedbackModel adviceFeedbackModel = new AdviceFeedbackModel();
        AdviceFeedbackBLL adviceFeedbackBLL = new AdviceFeedbackBLL();
        adviceFeedbackModel.Id = context.Request["Id"]; ;
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
        
        adviceFeedbackModel.TeacherId = context.Request["Teacher"];
        adviceFeedbackModel.TeacherName = context.Request["TeacherName"];

        adviceFeedbackModel.FeedbackInformation = context.Request["FeedbackInformation"];
        if (adviceFeedbackBLL.Update(adviceFeedbackModel))
        {
            context.Response.Write("updateSuccess");
        }
        else
        {
            context.Response.Write("updateError");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}