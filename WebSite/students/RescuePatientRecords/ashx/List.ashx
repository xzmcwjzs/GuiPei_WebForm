<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;

public class List : IHttpHandler {
    RescuePatientRecordsBLL rescuePatientRecordsBLL = new RescuePatientRecordsBLL();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string DeptName = context.Request["DeptName"];
        string PatientName = context.Request["PatientName"];
        string CaseId = context.Request["CaseId"];
        string DiseaseName = context.Request["DiseaseName"];
        string Condition = context.Request["Condition"];

        int pageCount = rescuePatientRecordsBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, PatientName, CaseId, DiseaseName, Condition);
        int recordCount = rescuePatientRecordsBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, PatientName, CaseId, DiseaseName, Condition);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.RescuePatientRecordsModel> list = new BLL.RescuePatientRecordsBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, PatientName, CaseId, DiseaseName, Condition, pageIndex, pageSize);

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