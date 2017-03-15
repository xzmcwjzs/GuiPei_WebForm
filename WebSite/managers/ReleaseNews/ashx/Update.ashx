<%@ WebHandler Language="C#" Class="Update" %>

using System;
using System.Web;
using BLL;
using Model;

public class Update : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        ReleaseNewsBLL releaseNewsBLL = new ReleaseNewsBLL();
        ReleaseNewsModel releaseNewsModel = new ReleaseNewsModel();
        releaseNewsModel.Id = context.Request["Id"];
        
        releaseNewsModel.Writor = context.Request["Writor"];
        releaseNewsModel.RegisterDate = context.Request["RegisterDate"];
        releaseNewsModel.NewsTitle = context.Request["NewsTitle"];
        
        releaseNewsModel.NewsContent = context.Request["NewsContent"];
        releaseNewsModel.Students = context.Request["Students"];
        releaseNewsModel.Teachers = context.Request["Teachers"];
        releaseNewsModel.Bases = context.Request["Bases"];


        if (releaseNewsBLL.Update(releaseNewsModel))
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