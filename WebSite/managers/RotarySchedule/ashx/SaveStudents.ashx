<%@ WebHandler Language="C#" Class="SaveStudents" %>

using System;
using System.Web;
using BLL;
using Model;


public class SaveStudents : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        RotaryScheduleBLL bll = new RotaryScheduleBLL();
        RotaryScheduleModel model = new RotaryScheduleModel();
        
        string Id = context.Request["id"];
        string StudentsNameList = context.Request["StudentsNameList"];
        string StudentsRealNameList = context.Request["StudentsRealNameList"];

        model.Id = Id;
        model.Tag1 = StudentsNameList;
        model.Tag2 = StudentsRealNameList;

        if (bll.UpdateStudents(model))
        {
            context.Response.Write("学员分配信息保存成功");
        }
        else
        {
            context.Response.Write("学员分配信息保存失败");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}