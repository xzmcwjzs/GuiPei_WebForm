<%@ WebHandler Language="C#" Class="Download" %>

using System;
using System.Web;

public class Download : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
       
        
        string FilePath = context.Request["FilePath"];
        string FileName = context.Request["FileName"];

        string filePath = context.Request.MapPath(FilePath + FileName);
        context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"",context.Server.UrlEncode(FileName)));
        context.Response.WriteFile(filePath);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}