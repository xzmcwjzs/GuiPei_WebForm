<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Common;

public class List : IHttpHandler {
    JoinStudyActivitiesBLL joinStudyActivitiesBLL = new JoinStudyActivitiesBLL();

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string DeptName = context.Request["DeptName"];
        string ActivityForm = context.Request["ActivityForm"];
        string MainSpeaker = context.Request["MainSpeaker"];
        string ActivityDate = context.Request["ActivityDate"];

        int pageCount = joinStudyActivitiesBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, ActivityForm, MainSpeaker, ActivityDate);
        int recordCount = joinStudyActivitiesBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ActivityForm, MainSpeaker, ActivityDate);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.JoinStudyActivitiesModel> list = new BLL.JoinStudyActivitiesBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, ActivityForm, MainSpeaker, ActivityDate, pageIndex, pageSize);

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