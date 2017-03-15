<%@ WebHandler Language="C#" Class="DownloadWord" %>

using System;
using System.Web;

public class DownloadWord : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string filename = context.Request["filename"];
        //string filename = "个人轮转表-王杰.doc";
        string filePath = context.Request.MapPath("/RotaryWord/"+filename);
        filename = HttpUtility.UrlEncode(filename);
        context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"",filename));
        context.Response.WriteFile(filePath);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}