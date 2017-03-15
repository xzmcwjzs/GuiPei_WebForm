<%@ WebHandler Language="C#" Class="OutDeptExamList" %>

using System;
using System.Web;
using BLL;
using DAL;
using Common;
using System.Web.Script.Serialization;

public class OutDeptExamList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        OutDeptExamBLL outDeptExamBLL = new OutDeptExamBLL();

        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;

        string ProfessionalBaseName = CommonFunc.SafeGetStringFromObj(context.Request["ProfessionalBaseName"]);
        string DeptName = CommonFunc.SafeGetStringFromObj(context.Request["DeptName"]);
        string TeachersRealName = CommonFunc.SafeGetStringFromObj(context.Request["TeachersRealName"]);

        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];

        string StudentsRealName = context.Request["StudentsRealName"];
        string RotaryBeginTime = context.Request["RotaryBeginTime"];
        string RotaryEndTime = context.Request["RotaryEndTime"];
        string TotalScore = context.Request["TotalScore"];
        string IsPass = context.Request["IsPass"];

        int pageCount = outDeptExamBLL.CommonGetPageCount(pageSize, StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, ProfessionalBaseName, DeptName, TeachersRealName, RotaryBeginTime, RotaryEndTime, TotalScore, IsPass);
        int recordCount = outDeptExamBLL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, ProfessionalBaseName, DeptName, TeachersRealName, RotaryBeginTime, RotaryEndTime, TotalScore, IsPass);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.OutDeptExamModel> list = new BLL.OutDeptExamBLL().CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, ProfessionalBaseName, DeptName, TeachersRealName, RotaryBeginTime, RotaryEndTime, TotalScore, IsPass, pageIndex, pageSize);

        string strJsonArr = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        string strRes = "{'data':" + strJsonArr + ",'recordCount':" + recordCount + ",'pageCount':" + pageCount + "}";

        context.Response.Write(strRes);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}