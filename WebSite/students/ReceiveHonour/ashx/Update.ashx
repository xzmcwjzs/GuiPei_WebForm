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
        ReceiveHonourModel receiveHonourModel = new ReceiveHonourModel();
        ReceiveHonourBLL receiveHonourBLL = new ReceiveHonourBLL();
        receiveHonourModel.Id = context.Request["Id"]; ;
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
        
        receiveHonourModel.TeacherId = context.Request["Teacher"];
        receiveHonourModel.TeacherName = context.Request["TeacherName"];
        receiveHonourModel.Comment = context.Request["Comment"];

        receiveHonourModel.HonourName = context.Request["HonourName"];
        receiveHonourModel.HonourDepartment = context.Request["HonourDepartment"];
        receiveHonourModel.HonourDetail = context.Request["HonourDetail"];
        receiveHonourModel.HonourDate = context.Request["HonourDate"];
        if (receiveHonourBLL.Update(receiveHonourModel))
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