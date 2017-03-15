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
        PublishArticalRecordsModel publishArticalRecordsModel = new PublishArticalRecordsModel();
        PublishArticalRecordsBLL publishArticalRecordsBLL = new PublishArticalRecordsBLL();
        publishArticalRecordsModel.Id = context.Request["Id"]; ;
        publishArticalRecordsModel.StudentsRealName = context.Request["StudentsRealName"];
        publishArticalRecordsModel.StudentsName = context.Request["StudentsName"];
        publishArticalRecordsModel.TrainingBaseCode = context.Request["TrainingBaseCode"];
        publishArticalRecordsModel.TrainingBaseName = context.Request["TrainingBaseName"];
        publishArticalRecordsModel.ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        publishArticalRecordsModel.ProfessionalBaseName = context.Request["ProfessionalBaseName"];
        publishArticalRecordsModel.DeptCode = context.Request["RotaryDept"];
        publishArticalRecordsModel.DeptName = context.Request["DeptName"];
        publishArticalRecordsModel.RegisterDate = context.Request["RegisterDate"];
        publishArticalRecordsModel.Writor = context.Request["Writor"];

        publishArticalRecordsModel.TeacherId = context.Request["Teacher"];
        publishArticalRecordsModel.TeacherName = context.Request["TeacherName"];
        publishArticalRecordsModel.Comment = context.Request["Comment"];

        publishArticalRecordsModel.ArticalTitle = context.Request["ArticalTitle"];
        publishArticalRecordsModel.ArticalCategory = context.Request["ArticalCategory"];
        publishArticalRecordsModel.PublishJournal = context.Request["PublishJournal"];
        publishArticalRecordsModel.Author = context.Request["Author"];
        publishArticalRecordsModel.PublishDate = context.Request["PublishDate"];
        if (publishArticalRecordsBLL.Update(publishArticalRecordsModel))
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