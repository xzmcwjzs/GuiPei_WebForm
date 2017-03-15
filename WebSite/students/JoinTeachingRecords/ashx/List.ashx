<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Common;

public class List : IHttpHandler {
    JoinTeachingRecordsBLL joinTeachingRecordsBLL = new JoinTeachingRecordsBLL();

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string DeptName = context.Request["DeptName"];
        string TeachingObject = context.Request["TeachingObject"];
        string HeadTeacher = context.Request["HeadTeacher"];
        string TeachingDate = context.Request["TeachingDate"];

        int pageCount = joinTeachingRecordsBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, TeachingObject, HeadTeacher, TeachingDate);
        int recordCount = joinTeachingRecordsBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, TeachingObject, HeadTeacher, TeachingDate);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.JoinTeachingRecordsModel> list = new BLL.JoinTeachingRecordsBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, TeachingObject, HeadTeacher, TeachingDate, pageIndex, pageSize);

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