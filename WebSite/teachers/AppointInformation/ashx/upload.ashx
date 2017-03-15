<%@ WebHandler Language="C#" Class="upload" %>

using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

public class upload : IHttpHandler {
    private const string filePath = "/UploadFile/teachers/";
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        HttpPostedFile file = context.Request.Files["uploadFile"];

        if (file != null && file.ContentLength > 0)
        {
            if (!Directory.Exists(context.Server.MapPath(filePath)))
            {
                Directory.CreateDirectory(context.Server.MapPath(filePath));
            }

            string fileName = Path.GetFileName(file.FileName);
            string strExt = Path.GetExtension(fileName);
            string[] strExts = { ".doc", ".docx", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf", ".PDF", ".rar", ".zip" };
            if (strExts.Contains(strExt))
            { 
                if (File.Exists(context.Server.MapPath(filePath) + fileName))
                {
                     File.Delete(context.Server.MapPath(filePath) + fileName);
                }
                
                file.SaveAs(context.Server.MapPath(filePath) + fileName);

              string strRes = "{\"fileName\":\"" + fileName + "\",\"filePath\":\" " + filePath + "\"}";
              context.Response.Write(strRes);
            }
            else
            {
                context.Response.Write("{'fileName':'0'}");
            }
            
          }
        else
        {
             context.Response.Write("{'fileName':'1'}");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}