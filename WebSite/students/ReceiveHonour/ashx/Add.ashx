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
        ReceiveHonourModel receiveHonourModel = new ReceiveHonourModel();
        ReceiveHonourBLL receiveHonourBLL = new ReceiveHonourBLL();
        receiveHonourModel.Id = Guid.NewGuid().ToString();
        receiveHonourModel.StudentsRealName = context.Request["StudentsRealName"];
        receiveHonourModel.StudentsName = context.Request["StudentsName"];
        receiveHonourModel.TrainingBaseCode = context.Request["TrainingBaseCode"];
        receiveHonourModel.TrainingBaseName = context.Request["TrainingBaseName"];
        receiveHonourModel.ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        receiveHonourModel.ProfessionalBaseName = context.Request["ProfessionalBaseName"];
        receiveHonourModel.DeptCode = context.Request["RotaryDept"];
        receiveHonourModel.DeptName = context.Request["DeptName"];
        receiveHonourModel.RegisterDate = context.Request["RegisterDate"];
        receiveHonourModel.Writor = context.Request["Writor"];
        receiveHonourModel.TeacherCheck = "未通过";
        receiveHonourModel.KzrCheck = "未通过";
        receiveHonourModel.BaseCheck = "未通过";
        receiveHonourModel.ManagerCheck = "未通过";
        receiveHonourModel.TeacherId = context.Request["Teacher"];
        receiveHonourModel.TeacherName = context.Request["TeacherName"];
        receiveHonourModel.Comment = context.Request["Comment"];

        receiveHonourModel.HonourName = context.Request["HonourName"];
        receiveHonourModel.HonourDepartment = context.Request["HonourDepartment"];
        receiveHonourModel.HonourDetail = context.Request["HonourDetail"];
        receiveHonourModel.HonourDate = context.Request["HonourDate"];
        if (receiveHonourBLL.Add(receiveHonourModel))
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