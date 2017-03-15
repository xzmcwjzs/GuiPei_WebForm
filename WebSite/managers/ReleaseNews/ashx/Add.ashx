<%@ WebHandler Language="C#" Class="Add" %>

using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Model;
using System.Web.Script.Serialization;
using BLL;
using Common;

public class Add : IHttpHandler {
    private const string filePath = "/UploadFile/managers/";
    private string fileName = string.Empty;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        HttpPostedFile file = context.Request.Files["UploadFile"];

        if (file != null && file.ContentLength > 0)
        {
            if (!Directory.Exists(context.Server.MapPath(filePath)))
            {
                Directory.CreateDirectory(context.Server.MapPath(filePath));
            }

            fileName = Path.GetFileName(file.FileName);
            string strExt = Path.GetExtension(fileName);
            string[] strExts = { ".doc", ".docx", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf", ".rar", ".zip" };
            if (strExts.Contains(strExt))
            {
                if (File.Exists(context.Server.MapPath(filePath) + fileName))
                {
                    File.Delete(context.Server.MapPath(filePath) + fileName);
                }

                file.SaveAs(context.Server.MapPath(filePath) + fileName);

            }
            else
            {
                context.Response.Write("errorFormat");
                context.Response.End();
            }

        }

        ReleaseNewsBLL releaseNewsBLL = new ReleaseNewsBLL();
        ReleaseNewsModel releaseNewsModel = new ReleaseNewsModel();
        releaseNewsModel.Id = Guid.NewGuid().ToString();
        releaseNewsModel.TrainingBaseCode = context.Request["TrainingBaseCode"];
        releaseNewsModel.TrainingBaseName = context.Request["TrainingBaseName"];
        releaseNewsModel.ManagersName = context.Request["ManagersName"];
        releaseNewsModel.ManagersRealName = context.Request["ManagersRealName"];
        releaseNewsModel.Writor = context.Request["Writor"];
        releaseNewsModel.RegisterDate = context.Request["RegisterDate"];
        releaseNewsModel.NewsTitle = context.Request["NewsTitle"];
        releaseNewsModel.FileName = fileName;
        releaseNewsModel.FilePath = filePath;

        releaseNewsModel.NewsContent = context.Request["NewsContent"];
        releaseNewsModel.Students = context.Request["Students"];
        releaseNewsModel.Teachers = context.Request["Teachers"];
        releaseNewsModel.Bases = context.Request["Bases"];


        if (releaseNewsBLL.Add(releaseNewsModel))
        {
            context.Response.Write("addSuccess");
        }
        else
        {
            context.Response.Write("addError");
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}