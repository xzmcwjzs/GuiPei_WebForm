﻿<%@ WebHandler Language="C#" Class="BigMedicalRecordsList" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Common;

public class BigMedicalRecordsList : IHttpHandler {
    BigMedicalRecordsBLL bigMedicalRecordsBLL = new BigMedicalRecordsBLL();

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
        string ProfessionalBaseName = CommonFunc.SafeGetStringFromObj(context.Request["ProfessionalBaseName"]);
        string DeptName = CommonFunc.SafeGetStringFromObj(context.Request["DeptName"]);
        string TeachersRealName = CommonFunc.SafeGetStringFromObj(context.Request["TeachersRealName"]); 
        string PatientNo = context.Request["PatientNo"];
        string InhospitalNo = context.Request["InhospitalNo"];
        string PatientName = context.Request["PatientName"];
        int pageCount = bigMedicalRecordsBLL.CommonGetPageCount(pageSize, StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, PatientNo, InhospitalNo, PatientName);
        int recordCount = bigMedicalRecordsBLL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, PatientNo, InhospitalNo, PatientName);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.BigMedicalRecordsModel> list = new BLL.BigMedicalRecordsBLL().CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, PatientNo, InhospitalNo,PatientName, pageIndex, pageSize);

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