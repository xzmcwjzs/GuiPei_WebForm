<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Common;

public class List : IHttpHandler {
    PublishArticalRecordsBLL publishArticalRecordsBLL = new PublishArticalRecordsBLL();

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string DeptName = context.Request["DeptName"];
        string ArticalTitle = context.Request["ArticalTitle"];
        string ArticalCategory = context.Request["ArticalCategory"];
        string Author = context.Request["Author"];
        string PublishDate = context.Request["PublishDate"];
        int pageCount = publishArticalRecordsBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, ArticalTitle, ArticalCategory, Author, PublishDate);
        int recordCount = publishArticalRecordsBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ArticalTitle, ArticalCategory, Author, PublishDate);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.PublishArticalRecordsModel> list = new BLL.PublishArticalRecordsBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, ArticalTitle, ArticalCategory, Author, PublishDate, pageIndex, pageSize);

        string strJsonArr = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        string strRes = "{'data':" + strJsonArr + ",'recordCount':" + recordCount + ",'pageCount':" + pageCount + "}";

        context.Response.Write(strRes);
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}