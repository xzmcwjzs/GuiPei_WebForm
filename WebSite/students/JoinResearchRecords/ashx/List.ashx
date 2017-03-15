<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Common;

public class List : IHttpHandler {
    JoinResearchRecordsBLL joinResearchRecordsBLL = new JoinResearchRecordsBLL();

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string DeptName = context.Request["DeptName"];
        string ResearchTitle = context.Request["ResearchTitle"];
        string ResearchManager = context.Request["ResearchManager"];
        string JoinRole = context.Request["JoinRole"];
        string ResearchDate = context.Request["ResearchDate"];

        int pageCount = joinResearchRecordsBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, ResearchTitle, ResearchManager, JoinRole, ResearchDate);
        int recordCount = joinResearchRecordsBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ResearchTitle, ResearchManager, JoinRole, ResearchDate);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.JoinResearchRecordsModel> list = new BLL.JoinResearchRecordsBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, ResearchTitle, ResearchManager, JoinRole, ResearchDate, pageIndex, pageSize);

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