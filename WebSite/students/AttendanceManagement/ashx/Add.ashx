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
        AttendanceManagementModel attendanceManagementModel = new AttendanceManagementModel();
        AttendanceManageBLL attendanceManageBLL = new AttendanceManageBLL();
        attendanceManagementModel.Id = Guid.NewGuid().ToString();
        attendanceManagementModel.StudentsRealName = context.Request["StudentsRealName"];
        attendanceManagementModel.StudentsName = context.Request["StudentsName"];
        attendanceManagementModel.TrainingBaseCode = context.Request["TrainingBaseCode"];
        attendanceManagementModel.TrainingBaseName = context.Request["TrainingBaseName"];
        attendanceManagementModel.ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        attendanceManagementModel.ProfessionalBaseName = context.Request["ProfessionalBaseName"];
        attendanceManagementModel.DeptCode = context.Request["RotaryDept"];
        attendanceManagementModel.DeptName = context.Request["DeptName"];
        attendanceManagementModel.RegisterDate = context.Request["RegisterDate"];
        attendanceManagementModel.Writor = context.Request["Writor"];
        attendanceManagementModel.TeacherCheck = "未通过";
        attendanceManagementModel.KzrCheck = "未通过";
        attendanceManagementModel.BaseCheck = "未通过";
        attendanceManagementModel.ManagerCheck = "未通过";
        attendanceManagementModel.TeacherId = context.Request["Teacher"];
        attendanceManagementModel.TeacherName = context.Request["TeacherName"];
        attendanceManagementModel.Comment = context.Request["Comment"];

        attendanceManagementModel.AttendanceCategory = context.Request["AttendanceCategory"];
        attendanceManagementModel.FirstDate = context.Request["FirstDate"];
        attendanceManagementModel.LastDate = context.Request["LastDate"];
        attendanceManagementModel.Days = context.Request["Days"];
        attendanceManagementModel.Details = context.Request["Details"];
        if (attendanceManageBLL.Add(attendanceManagementModel))
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