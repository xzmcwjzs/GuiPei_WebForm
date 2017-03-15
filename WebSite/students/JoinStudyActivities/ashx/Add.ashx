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
        JoinStudyActivitiesModel joinStudyActivitiesModel = new JoinStudyActivitiesModel();
        JoinStudyActivitiesBLL joinStudyActivitiesBLL = new JoinStudyActivitiesBLL();
        joinStudyActivitiesModel.Id = Guid.NewGuid().ToString();
        joinStudyActivitiesModel.StudentsRealName = context.Request["StudentsRealName"];
        joinStudyActivitiesModel.StudentsName = context.Request["StudentsName"];
        joinStudyActivitiesModel.TrainingBaseCode = context.Request["TrainingBaseCode"];
        joinStudyActivitiesModel.TrainingBaseName = context.Request["TrainingBaseName"];
        joinStudyActivitiesModel.ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        joinStudyActivitiesModel.ProfessionalBaseName = context.Request["ProfessionalBaseName"];
        joinStudyActivitiesModel.DeptCode = context.Request["RotaryDept"];
        joinStudyActivitiesModel.DeptName = context.Request["DeptName"];
        joinStudyActivitiesModel.RegisterDate = context.Request["RegisterDate"];
        joinStudyActivitiesModel.Writor = context.Request["Writor"];
        joinStudyActivitiesModel.TeacherCheck = "未通过";
        joinStudyActivitiesModel.KzrCheck = "未通过";
        joinStudyActivitiesModel.BaseCheck = "未通过";
        joinStudyActivitiesModel.ManagerCheck = "未通过";
        joinStudyActivitiesModel.TeacherId = context.Request["Teacher"];
        joinStudyActivitiesModel.TeacherName = context.Request["TeacherName"];
        joinStudyActivitiesModel.Comment = context.Request["Comment"];

        joinStudyActivitiesModel.ActivityForm = context.Request["ActivityForm"];
        joinStudyActivitiesModel.MainSpeaker = context.Request["MainSpeaker"];
        joinStudyActivitiesModel.Location = context.Request["Location"];
        joinStudyActivitiesModel.ActivityDate = context.Request["ActivityDate"];
        joinStudyActivitiesModel.ClassHour = context.Request["ClassHour"];
        joinStudyActivitiesModel.ActivityNum = context.Request["ActivityNum"];
        joinStudyActivitiesModel.ActivityContent = context.Request["ActivityContent"];
        if (joinStudyActivitiesBLL.Add(joinStudyActivitiesModel))
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