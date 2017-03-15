<%@ WebHandler Language="C#" Class="SurgeryRecordsList" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using Common;

public class SurgeryRecordsList : IHttpHandler {
    SurgeryRecordsBLL surgeryRecordsBLL = new SurgeryRecordsBLL();
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
        string SurgeryName = context.Request["SurgeryName"];
        string IntraoperativePosition = context.Request["IntraoperativePosition"];
        string Emergency = context.Request["Emergency"];
        string SurgeryDate = context.Request["SurgeryDate"];
        string SurgeryIsStop = context.Request["SurgeryIsStop"];
        string ProfessionalBaseName = CommonFunc.SafeGetStringFromObj(context.Request["ProfessionalBaseName"]);
        string DeptName = CommonFunc.SafeGetStringFromObj(context.Request["DeptName"]);
        string TeachersRealName = CommonFunc.SafeGetStringFromObj(context.Request["TeachersRealName"]);

        int pageCount = surgeryRecordsBLL.CommonGetPageCount(pageSize, StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, SurgeryName, IntraoperativePosition, Emergency, SurgeryDate, SurgeryIsStop);
        int recordCount = surgeryRecordsBLL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, SurgeryName, IntraoperativePosition, Emergency, SurgeryDate, SurgeryIsStop);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.SurgeryRecordsModel> list = new BLL.SurgeryRecordsBLL().CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName, PatientName, CaseId, SurgeryName, IntraoperativePosition, Emergency, SurgeryDate, SurgeryIsStop, pageIndex, pageSize);

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