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
        JoinTeachingRecordsModel joinTeachingRecordsModel = new JoinTeachingRecordsModel();
        JoinTeachingRecordsBLL joinTeachingRecordsBLL = new JoinTeachingRecordsBLL();
        joinTeachingRecordsModel.Id = context.Request["Id"]; ;
        joinTeachingRecordsModel.StudentsRealName = context.Request["StudentsRealName"];
        joinTeachingRecordsModel.StudentsName = context.Request["StudentsName"];
        joinTeachingRecordsModel.TrainingBaseCode = context.Request["TrainingBaseCode"];
        joinTeachingRecordsModel.TrainingBaseName = context.Request["TrainingBaseName"];
        joinTeachingRecordsModel.ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        joinTeachingRecordsModel.ProfessionalBaseName = context.Request["ProfessionalBaseName"];
        joinTeachingRecordsModel.DeptCode = context.Request["RotaryDept"];
        joinTeachingRecordsModel.DeptName = context.Request["DeptName"];
        joinTeachingRecordsModel.RegisterDate = context.Request["RegisterDate"];
        joinTeachingRecordsModel.Writor = context.Request["Writor"];
        
        joinTeachingRecordsModel.TeacherId = context.Request["Teacher"];
        joinTeachingRecordsModel.TeacherName = context.Request["TeacherName"];
        joinTeachingRecordsModel.Comment = context.Request["Comment"];

        joinTeachingRecordsModel.TeachingObject = context.Request["TeachingObject"];
        joinTeachingRecordsModel.StudentsNum = context.Request["StudentsNum"];
        joinTeachingRecordsModel.TeachingContent = context.Request["TeachingContent"];
        joinTeachingRecordsModel.HeadTeacher = context.Request["HeadTeacher"];
        joinTeachingRecordsModel.TeachingDate = context.Request["TeachingDate"];
        if (joinTeachingRecordsBLL.Update(joinTeachingRecordsModel))
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