<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using Common;

public class List : IHttpHandler {
    ReleaseNewsBLL releaseNewsBLL = new ReleaseNewsBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string ManagersName = context.Request["ManagersName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string NewsTitle = context.Request["NewsTitle"];

        string RegisterDate = context.Request["RegisterDate"];

        string Type = "Teachers";
        int pageCount = releaseNewsBLL.GetPageCount(pageSize, ManagersName, TrainingBaseCode, NewsTitle, RegisterDate, Type);
        int recordCount = releaseNewsBLL.GetRecordCount(ManagersName, TrainingBaseCode, NewsTitle, RegisterDate, Type);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.ReleaseNewsModel> list = new BLL.ReleaseNewsBLL().GetPagedList(ManagersName, TrainingBaseCode, NewsTitle, RegisterDate,Type, pageIndex, pageSize);

        string strJsonArr = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        string strRes = "{'data':" + strJsonArr + ",'recordCount':" + recordCount + ",'pageCount':" + pageCount + "}";

        context.Response.Write(strRes);
        context.Response.End();
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}