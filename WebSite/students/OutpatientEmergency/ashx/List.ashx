<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;

public class List : IHttpHandler {
    OutpatientEmergencyBLL outpatientEmergencyBLL = new OutpatientEmergencyBLL();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string DeptName = context.Request["DeptName"];
        string RecordType = context.Request["RecordType"];
        string DiseaseName = context.Request["DiseaseName"];
        string DiseaseNum = context.Request["DiseaseNum"];

        int pageCount = outpatientEmergencyBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, RecordType,DiseaseName,DiseaseNum);
        int recordCount = outpatientEmergencyBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, RecordType, DiseaseName, DiseaseNum);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.OutpatientEmergencyModel> list = new BLL.OutpatientEmergencyBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, RecordType, DiseaseName, DiseaseNum, pageIndex, pageSize);

        string strJsonArr = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        string strRes = "{'data':" + strJsonArr + ",'recordCount':" + recordCount + ",'pageCount':" + pageCount + "}";

        context.Response.Write(strRes);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}