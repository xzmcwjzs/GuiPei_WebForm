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
        JoinStudyActivitiesModel joinStudyActivitiesModel = new JoinStudyActivitiesModel();
        JoinStudyActivitiesBLL joinStudyActivitiesBLL = new JoinStudyActivitiesBLL();

        joinStudyActivitiesModel.Id = context.Request["Id"]; ;
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
        if (joinStudyActivitiesBLL.Update(joinStudyActivitiesModel))
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