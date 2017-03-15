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
        JoinResearchRecordsModel joinResearchRecordsModel = new JoinResearchRecordsModel();
        JoinResearchRecordsBLL joinResearchRecordsBLL = new JoinResearchRecordsBLL();
        joinResearchRecordsModel.Id = Guid.NewGuid().ToString();
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
        joinResearchRecordsModel.TeacherCheck = "未通过";
        joinResearchRecordsModel.KzrCheck = "未通过";
        joinResearchRecordsModel.BaseCheck = "未通过";
        joinResearchRecordsModel.ManagerCheck = "未通过";
        joinResearchRecordsModel.TeacherId = context.Request["Teacher"];
        joinResearchRecordsModel.TeacherName = context.Request["TeacherName"];
        joinResearchRecordsModel.Comment = context.Request["Comment"];

        joinResearchRecordsModel.ResearchTitle = context.Request["ResearchTitle"];
        joinResearchRecordsModel.ResearchManager = context.Request["ResearchManager"];
        joinResearchRecordsModel.JoinRole = context.Request["JoinRole"];
        joinResearchRecordsModel.Others = context.Request["Others"];
        joinResearchRecordsModel.Progress = context.Request["Progress"];
        joinResearchRecordsModel.ResearchDate = context.Request["ResearchDate"];
        
        if (joinResearchRecordsBLL.Add(joinResearchRecordsModel))
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