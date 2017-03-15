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
        MedicalErrorModel medicalErrorModel = new MedicalErrorModel();
        MedicalErrorBLL medicalErrorBLL = new MedicalErrorBLL();
        medicalErrorModel.Id = context.Request["Id"]; ;
        medicalErrorModel.StudentsRealName = context.Request["StudentsRealName"];
        medicalErrorModel.StudentsName = context.Request["StudentsName"];
        medicalErrorModel.TrainingBaseCode = context.Request["TrainingBaseCode"];
        medicalErrorModel.TrainingBaseName = context.Request["TrainingBaseName"];
        medicalErrorModel.ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        medicalErrorModel.ProfessionalBaseName = context.Request["ProfessionalBaseName"];
        medicalErrorModel.DeptCode = context.Request["RotaryDept"];
        medicalErrorModel.DeptName = context.Request["DeptName"];
        medicalErrorModel.RegisterDate = context.Request["RegisterDate"];
        medicalErrorModel.Writor = context.Request["Writor"];
        
        medicalErrorModel.TeacherId = context.Request["Teacher"];
        medicalErrorModel.TeacherName = context.Request["TeacherName"];
        medicalErrorModel.Comment = context.Request["Comment"];

        medicalErrorModel.ErrorCategory = context.Request["ErrorCategory"];
        medicalErrorModel.ErrorDetail = context.Request["ErrorDetail"];
        medicalErrorModel.ErrorDate = context.Request["ErrorDate"];
        if (medicalErrorBLL.Update(medicalErrorModel))
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