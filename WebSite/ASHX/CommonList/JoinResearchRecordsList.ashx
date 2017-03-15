<%@ WebHandler Language="C#" Class="JoinResearchRecordsList" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Common;

public class JoinResearchRecordsList : IHttpHandler {
    JoinResearchRecordsBLL joinResearchRecordsBLL = new JoinResearchRecordsBLL();

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
        string ResearchTitle = context.Request["ResearchTitle"];
        string ResearchManager = context.Request["ResearchManager"];
        string JoinRole = context.Request["JoinRole"];
        string ResearchDate = context.Request["ResearchDate"];
        string ProfessionalBaseName = CommonFunc.SafeGetStringFromObj(context.Request["ProfessionalBaseName"]);
        string DeptName = CommonFunc.SafeGetStringFromObj(context.Request["DeptName"]);
        string TeachersRealName = CommonFunc.SafeGetStringFromObj(context.Request["TeachersRealName"]); 

        int pageCount = joinResearchRecordsBLL.CommonGetPageCount(pageSize, StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, ResearchTitle, ResearchManager, JoinRole, ResearchDate);
        int recordCount = joinResearchRecordsBLL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, ResearchTitle, ResearchManager, JoinRole, ResearchDate);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.JoinResearchRecordsModel> list = new BLL.JoinResearchRecordsBLL().CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName,ProfessionalBaseName, DeptName,TeachersRealName, ResearchTitle, ResearchManager, JoinRole, ResearchDate, pageIndex, pageSize);

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