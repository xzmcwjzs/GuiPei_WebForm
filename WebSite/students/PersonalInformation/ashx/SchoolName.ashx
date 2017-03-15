<%@ WebHandler Language="C#" Class="SchoolName" %>

using System;
using System.Web;
using BLL;
using DAL;
using Common;
using System.Data;
using System.Data.SqlClient;

public class SchoolName : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        SchoolInformationBLL schoolInformationBLL = new SchoolInformationBLL();

        DataTable dt = schoolInformationBLL.GetDtSchoolName();
        string jsonStr = JsonHelper.ToJson(dt);
        context.Response.Write(jsonStr);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}