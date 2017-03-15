<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;

public class List : IHttpHandler {
    TrainingTeachingActivitiesBLL trainingTeachingActivitiesBLL = new TrainingTeachingActivitiesBLL();
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
        string ClassHour = context.Request["ClassHour"];
        string ActivityDate = context.Request["ActivityDate"];

        int pageCount = trainingTeachingActivitiesBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, ActivityForm, MainSpeaker, ClassHour, ActivityDate);
        int recordCount = trainingTeachingActivitiesBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ActivityForm, MainSpeaker, ClassHour, ActivityDate);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.TrainingTeachingActivitiesModel> list = new BLL.TrainingTeachingActivitiesBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, ActivityForm, MainSpeaker, ClassHour, ActivityDate, pageIndex, pageSize);

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