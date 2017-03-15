<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Common;

public class List : IHttpHandler {
    MedicalErrorBLL medicalErrorBLL = new MedicalErrorBLL();

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string DeptName = context.Request["DeptName"];
        string ErrorCategory = context.Request["ErrorCategory"];
        string ErrorDate = context.Request["ErrorDate"];

        int pageCount = medicalErrorBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, ErrorCategory, ErrorDate);
        int recordCount = medicalErrorBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, ErrorCategory, ErrorDate);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.MedicalErrorModel> list = new BLL.MedicalErrorBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, ErrorCategory, ErrorDate, pageIndex, pageSize);

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