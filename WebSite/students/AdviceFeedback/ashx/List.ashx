<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Common;

public class List : IHttpHandler {
    AdviceFeedbackBLL adviceFeedbackBLL = new AdviceFeedbackBLL();

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string DeptName = context.Request["DeptName"];
        string ManagerHandle = context.Request["ManagerHandle"];
        string RegisterDate = context.Request["RegisterDate"];

        int pageCount = adviceFeedbackBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, ManagerHandle,RegisterDate);
        int recordCount = adviceFeedbackBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ManagerHandle, RegisterDate);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.AdviceFeedbackModel> list = new BLL.AdviceFeedbackBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, ManagerHandle, RegisterDate, pageIndex, pageSize);

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