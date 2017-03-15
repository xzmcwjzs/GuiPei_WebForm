<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Common;

public class List : IHttpHandler,IRequiresSessionState {
    StudyAndReadingBLL studyAndReadingBLL = new StudyAndReadingBLL();
    
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
       
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string DeptName = context.Request["DeptName"];
        string ActivityForm = context.Request["ActivityForm"];
        string ActivityDate = context.Request["ActivityDate"];
        string LanguageType = context.Request["LanguageType"];
        string SuperiorDoctor =context.Request["SuperiorDoctor"];

        int pageCount = studyAndReadingBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, ActivityForm,ActivityDate,LanguageType,SuperiorDoctor);
        int recordCount = studyAndReadingBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ActivityForm,ActivityDate,LanguageType,SuperiorDoctor);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.StudyAndReadingModel> list = new BLL.StudyAndReadingBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, ActivityForm, ActivityDate, LanguageType, SuperiorDoctor, pageIndex, pageSize);

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