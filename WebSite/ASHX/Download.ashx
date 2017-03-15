<%@ WebHandler Language="C#" Class="Download" %>

using System;
using System.Web;

public class Download : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //string filename = context.Request.QueryString["filename"];
        string filename =context.Server.UrlDecode(context.Request.QueryString["filename"]);
        string filePath = context.Request.MapPath("../index/download/" + filename);
        context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"",context.Server.UrlEncode(filename)));
        context.Response.WriteFile(filePath);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}