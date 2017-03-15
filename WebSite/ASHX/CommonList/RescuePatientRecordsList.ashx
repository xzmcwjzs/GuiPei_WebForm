<%@ WebHandler Language="C#" Class="RescuePatientRecordsList" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using Common;

public class RescuePatientRecordsList : IHttpHandler {
    RescuePatientRecordsBLL rescuePatientRecordsBLL = new RescuePatientRecordsBLL();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsRealName = context.Request["StudentsRealName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        string DeptCode = context.Request["DeptCode"];
        string TeachersName = context.Request["TeachersName"];

        string PatientName = context.Request["PatientName"];
        string CaseId = context.Request["CaseId"];
        string DiseaseName = context.Request["DiseaseName"];
        string Condition = context.Request["Condition"];
        string ProfessionalBaseName = CommonFunc.SafeGetStringFromObj(context.Request["ProfessionalBaseName"]);
        string DeptName = CommonFunc.SafeGetStringFromObj(context.Request["DeptName"]);
        string TeachersRealName = CommonFunc.SafeGetStringFromObj(context.Request["TeachersRealName"]); 

        int pageCount = rescuePatientRecordsBLL.CommonGetPageCount(pageSize, StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, PatientName, CaseId, DiseaseName, Condition);
        int recordCount = rescuePatientRecordsBLL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, PatientName, CaseId, DiseaseName, Condition);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.RescuePatientRecordsModel> list = new BLL.RescuePatientRecordsBLL().CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, DiseaseName, Condition, pageIndex, pageSize);

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