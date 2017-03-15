<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Common;

public class List : IHttpHandler,IRequiresSessionState {
    BigMedicalRecordsBLL bigMedicalRecordsBLL = new BigMedicalRecordsBLL();
    
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
       
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string DeptName = context.Request["DeptName"];
        string TeacherName = context.Request["TeacherName"];
        string RegisterDate = context.Request["RegisterDate"];
        string PatientNo = context.Request["PatientNo"];
        string InhospitalNo = context.Request["InhospitalNo"];

        int pageCount = bigMedicalRecordsBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, TeacherName, RegisterDate, PatientNo, InhospitalNo);
        int recordCount = bigMedicalRecordsBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, TeacherName, RegisterDate, PatientNo, InhospitalNo);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.BigMedicalRecordsModel> list = new BLL.BigMedicalRecordsBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, TeacherName, RegisterDate, PatientNo, InhospitalNo, pageIndex, pageSize);

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