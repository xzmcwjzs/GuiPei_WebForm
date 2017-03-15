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
        JoinResearchRecordsModel joinResearchRecordsModel = new JoinResearchRecordsModel();
        JoinResearchRecordsBLL joinResearchRecordsBLL = new JoinResearchRecordsBLL();
        joinResearchRecordsModel.Id = context.Request["Id"]; ;
        joinResearchRecordsModel.StudentsRealName = context.Request["StudentsRealName"];
        joinResearchRecordsModel.StudentsName = context.Request["StudentsName"];
        joinResearchRecordsModel.TrainingBaseCode = context.Request["TrainingBaseCode"];
        joinResearchRecordsModel.TrainingBaseName = context.Request["TrainingBaseName"];
        joinResearchRecordsModel.ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        joinResearchRecordsModel.ProfessionalBaseName = context.Request["ProfessionalBaseName"];
        joinResearchRecordsModel.DeptCode = context.Request["RotaryDept"];
        joinResearchRecordsModel.DeptName = context.Request["DeptName"];
        joinResearchRecordsModel.RegisterDate = context.Request["RegisterDate"];
        joinResearchRecordsModel.Writor = context.Request["Writor"];
        joinResearchRecordsModel.TeacherId = context.Request["Teacher"];
        joinResearchRecordsModel.TeacherName = context.Request["TeacherName"];
        joinResearchRecordsModel.Comment = context.Request["Comment"];

        joinResearchRecordsModel.ResearchTitle = context.Request["ResearchTitle"];
        joinResearchRecordsModel.ResearchManager = context.Request["ResearchManager"];
        joinResearchRecordsModel.JoinRole = context.Request["JoinRole"];
        joinResearchRecordsModel.Others = context.Request["Others"];
        joinResearchRecordsModel.Progress = context.Request["Progress"];
        joinResearchRecordsModel.ResearchDate = context.Request["ResearchDate"];
        if (joinResearchRecordsBLL.Update(joinResearchRecordsModel))
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