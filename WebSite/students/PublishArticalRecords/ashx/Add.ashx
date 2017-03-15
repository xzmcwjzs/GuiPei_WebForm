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
        PublishArticalRecordsModel publishArticalRecordsModel = new PublishArticalRecordsModel();
        PublishArticalRecordsBLL publishArticalRecordsBLL = new PublishArticalRecordsBLL();
        publishArticalRecordsModel.Id = Guid.NewGuid().ToString();
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
        publishArticalRecordsModel.TeacherCheck = "未通过";
        publishArticalRecordsModel.KzrCheck = "未通过";
        publishArticalRecordsModel.BaseCheck = "未通过";
        publishArticalRecordsModel.ManagerCheck = "未通过";
        publishArticalRecordsModel.TeacherId = context.Request["Teacher"];
        publishArticalRecordsModel.TeacherName = context.Request["TeacherName"];
        publishArticalRecordsModel.Comment = context.Request["Comment"];

        publishArticalRecordsModel.ArticalTitle = context.Request["ArticalTitle"];
        publishArticalRecordsModel.ArticalCategory = context.Request["ArticalCategory"];
        publishArticalRecordsModel.PublishJournal = context.Request["PublishJournal"];
        publishArticalRecordsModel.Author = context.Request["Author"];
        publishArticalRecordsModel.PublishDate = context.Request["PublishDate"];
        if (publishArticalRecordsBLL.Add(publishArticalRecordsModel))
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