<%@ WebHandler Language="C#" Class="GetStudents" %>

using System;
using System.Web;
using Common;
using BLL;
using System.Data;
using System.Data.SqlClient;

public class GetStudents : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string TrainingTime = context.Request["TrainingTime"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        
        StudentsPersonalInformationBLL bll = new StudentsPersonalInformationBLL();
        string jsonArr;
        DataTable dt = bll.GetDtByTPT(TrainingBaseCode, ProfessionalBaseCode, TrainingTime);
        if (dt == null)
        {
            jsonArr = "";
            
        }
        else
        {
            jsonArr = JsonHelper.ToJson(dt);

           
        }

        context.Response.Write(jsonArr);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}