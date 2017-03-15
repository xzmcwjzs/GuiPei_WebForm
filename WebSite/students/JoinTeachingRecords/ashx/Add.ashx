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
        JoinTeachingRecordsModel joinTeachingRecordsModel = new JoinTeachingRecordsModel();
        JoinTeachingRecordsBLL joinTeachingRecordsBLL = new JoinTeachingRecordsBLL();
        joinTeachingRecordsModel.Id = Guid.NewGuid().ToString();
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
        joinTeachingRecordsModel.TeacherCheck = "未通过";
        joinTeachingRecordsModel.KzrCheck = "未通过";
        joinTeachingRecordsModel.BaseCheck = "未通过";
        joinTeachingRecordsModel.ManagerCheck = "未通过";
        joinTeachingRecordsModel.TeacherId = context.Request["Teacher"];
        joinTeachingRecordsModel.TeacherName = context.Request["TeacherName"];
        joinTeachingRecordsModel.Comment = context.Request["Comment"];

        joinTeachingRecordsModel.TeachingObject = context.Request["TeachingObject"];
        joinTeachingRecordsModel.StudentsNum = context.Request["StudentsNum"];
        joinTeachingRecordsModel.TeachingContent = context.Request["TeachingContent"];
        joinTeachingRecordsModel.HeadTeacher = context.Request["HeadTeacher"];
        joinTeachingRecordsModel.TeachingDate = context.Request["TeachingDate"];
        if (joinTeachingRecordsBLL.Add(joinTeachingRecordsModel))
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