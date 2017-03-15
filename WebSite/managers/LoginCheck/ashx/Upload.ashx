<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

public class Upload : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string type = context.Request.QueryString["type"];
        HttpPostedFile file=null;

        if (type == "bases")
        {
           file = context.Request.Files["basesFile"];
        }
        else if (type == "teachers")
        {
            file = context.Request.Files["teachersFile"];
        }
        else if (type == "students")
        {
            file = context.Request.Files["studentsFile"];
        }
        

        if (file == null)
        {
            context.Response.Write("1");
        }
        else
        {
            string fileName = Path.GetFileName(file.FileName);
            string strExt = Path.GetExtension(fileName);
            if (strExt == ".xlsx")
            {
                string dir = "/UserInformation/"+DateTime.Now.Year+"/"+DateTime.Now.Month+"/"+DateTime.Now.Day+"/";
                if (!Directory.Exists(context.Server.MapPath(dir)))
                {
                    Directory.CreateDirectory(context.Server.MapPath(dir));
                }

                string newFileName = Guid.NewGuid().ToString();
                string fullDir = dir + newFileName + strExt;
                file.SaveAs(context.Server.MapPath(fullDir));
                context.Response.Write(fullDir);
            }
            else
            {
                context.Response.Write("0");
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}