<%@ WebHandler Language="C#" Class="GetTeachers" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class GetTeachers : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        LoginBLL bll = new LoginBLL();
        LoginModel model = new LoginModel();
        
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        string DeptCode = context.Request["DeptCode"];
        string type = "teachers";
        string jsonStr;
        DataTable dt = bll.GetTeachersDtByDeptCode(TrainingBaseCode, ProfessionalBaseCode, DeptCode, type);
             
        if (dt == null)
        {
            jsonStr = "";
        }else{
            jsonStr = Common.JsonHelper.ToJson(dt);
        }
        
        context.Response.Write(jsonStr);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}